using LokApp.Entities;
using LokApp.Repositories;
using System.Text.Json;

class FileRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly string _filePath;
    private readonly Action<T>? _itemAddedCallback;
    public event EventHandler<T> ItemAdded;
    public event EventHandler<T> ItemRemoved;
    private int lastUsedId;

    public FileRepository(string filePath, Action<T>? itemAddedCallback = null)
    {
        _filePath = filePath;
        _itemAddedCallback = itemAddedCallback;
        lastUsedId = GetLastUsedId();
    }

    public IEnumerable<T> GetAll()
    {
        return LoadItems();
    }

    public T GetById(int id)
    {
        return LoadItems().Find(item => item.Id == id);
    }

    public void Add(T item)
    {
        List<T> items = LoadItems();
        items.Add(item);
        lastUsedId++;
        item.Id = lastUsedId;
        SaveItems(items);
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        List<T> items = LoadItems();
        items.Remove(item);
        SaveItems(items);
        ItemRemoved?.Invoke(this, item);
    }

    private int GetLastUsedId()
    {
        List<T> items = LoadItems();
        return items.Any() ? items.Max(item => item.Id) : 0;
    }

    public void Save()
    {

    }

    private void SaveItems(List<T> items)
    {
        File.WriteAllText(_filePath, JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true }));
    }

    private List<T> LoadItems()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        return new List<T>();
    }
}
