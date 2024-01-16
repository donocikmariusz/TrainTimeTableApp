using LokApp.Data;
using LokApp.Entities;
using LokApp.Repositories;
using System.Globalization;
class Program
{
    static void Main(string[] args)
    {
        var trainRepository = new SqlRepository<Train>(new TrainAppDbContext());
        AddTrain(trainRepository);
        AddTrainWithName(trainRepository);
        WriteAllToConsole(trainRepository);

        static void AddTrain(IRepository<Train> trainRepository)
        {
            trainRepository.Add(new Train
            {
                Id = 1,
                Number = 38103,
                From = "Warszawa",
                ArrivalTime = new DateTime(1, 1, 1, 5, 34, 0),
                To = "Kraków",
                DepartureTime = new DateTime(1, 1, 1, 5, 55, 0),
                Platform = "3",
                Track = "5"
            }); ;
            trainRepository.Save();
        }

        static void AddTrainWithName(IWriteRepository<TrainWithName> trainWithNameRepository)
        {
            trainWithNameRepository.Add(new TrainWithName
            {
                Id = 2,
                Number = 222,
                From = "Gdynia",
                ArrivalTime = new DateTime(1, 1, 1, 7, 34, 0),
                To = "Bieslko Biała",
                DepartureTime = new DateTime(1, 1, 1, 8, 12, 0),
                Platform = "3",
                Track = "5",
                Name = "SZYNDZIELNIA"
            }); ;
            trainWithNameRepository.Save();
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
}


