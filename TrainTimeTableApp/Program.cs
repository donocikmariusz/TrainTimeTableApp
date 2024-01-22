using LokApp.Data;
using LokApp.Entities;
using LokApp.Repositories;
using System.Globalization;
using TrainTimeTableApp.Repositories.Extensions;

class Program
{
    static void Main(string[] args)
    {
        var trainRepository = new SqlRepository<Train>(new TrainAppDbContext(), TrainAdded);
        trainRepository.ItemAdded += TrainRepositoryOnItemAdded;

        static void TrainRepositoryOnItemAdded(object? sender, Train e)
        {
            Console.WriteLine($"Train added => {e.Number} from {sender?.GetType().Name}");
        }

        AddTrain(trainRepository);
        WriteAllToConsole(trainRepository);

        static void TrainAdded(Train item)
        {
            Console.WriteLine($"{item.Number} added");
        }


        static void AddTrain(IRepository<Train> trainRepository)
        {

            var trains = new[]
            {

            new Train { Number = 38103 },
            new Train { Number = 222 },
            new Train { Number = 234 }

            };
            trainRepository.AddBatch(trains);

        }

        /*
        repository.Add(new Train
        {
            Id = 1,
            Number = 38103,
            From = "Warszawa",
            ArrivalTime = new DateTime(1, 1, 1, 5, 34, 0),
            To = "Kraków",
            DepartureTime = new DateTime(1, 1, 1, 5, 55, 0),
            Platform = "3",
            Track = "5"
        });
        */

    }


    static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}




