using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using LokApp.Data;
using LokApp.Entities;
using LokApp.Repositories;
using TrainTimeTableApp.Repositories.Extensions;

class Program
{
    static void Main(string[] args)
    {
        var trainRepository = new FileRepository<Train>("trains.txt");
        trainRepository.ItemAdded += TrainRepositoryOnItemAdded;
        trainRepository.ItemRemoved += TrainRepositoryOnItemRemoved;

        while (true)
        {
            Console.WriteLine("App do wyświetlania tablicowego rozkłądu pociągów: ");
            Console.WriteLine("1. Dodaj pociąg");
            Console.WriteLine("2. Usuń pociąg");
            Console.WriteLine("3. Pokaż wszystkie pociągi");
            Console.WriteLine("0. Wyjdź");

            Console.Write("Wybierz opcję: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTrain(trainRepository);
                    trainRepository.Save();
                    break;
                case "2":
                    RemoveTrain(trainRepository);
                    trainRepository.Save();
                    break;
                case "3":
                    WriteAllToConsole(trainRepository);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }
        }
    }

    static void TrainRepositoryOnItemAdded(object? sender, Train e)
    {
        Console.WriteLine($"Train id {e.Id}, number: {e.Number} from: {e.From} to: {e.To} got from {sender?.GetType().Name}, Date: {DateTime.Now} Train added");
    }

    static void TrainRepositoryOnItemRemoved(object? sender, Train e)
    {
        Console.WriteLine($"Train id {e.Id}, number: {e.Number} from: {e.From} to: {e.To} got from {sender?.GetType().Name}, Date: {DateTime.Now} Train removed");
    }


    static void AddTrain(IRepository<Train> trainRepository)
    {
        Console.Write("Podaj numer pociągu: ");
        var number = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Podaj stację początkową: ");
        var fromStation = Console.ReadLine();

        Console.Write("Podaj stację końcową: ");
        var toStation = Console.ReadLine();

        try
        {
            trainRepository.Add(new Train
            {
                Number = number,
                From = fromStation,
                To = toStation,
            });
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catch: {e.Message}");
        }
    }


    static void RemoveTrain(IRepository<Train> trainRepository)
    {
        Console.Write("Podaj id pociągu do usunięcia: ");
        var id = int.Parse(Console.ReadLine() ?? "0");

        var train = trainRepository.GetById(id);

        if (train != null)
        {
            trainRepository.Remove(train);

        }
        else
        {
            Console.WriteLine($"Pociąg o id {id} nie został znaleziony.");
        }
    }

    static void WriteAllToConsole(IReadRepository<IEntity> repository)
    {
        var items = repository.GetAll();

        if (items.Any())
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("The list is empty.");
        }
    }
}