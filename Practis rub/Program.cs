using System;
using System.Collections.Generic;

//Паттерн Стратегия
/*
public interface ICostCalculationStrategy
{
    decimal CalculateCost(decimal distance, string serviceClass, int passengers, bool hasDiscount);
}

public class AirplaneCostCalculationStrategy : ICostCalculationStrategy
{
    public decimal CalculateCost(decimal distance, string serviceClass, int passengers, bool hasDiscount)
    {
        decimal baseCost = distance * 0.5m;
        decimal serviceMultiplier = serviceClass == "Business" ? 2.0m : 1.0m;
        decimal discount = hasDiscount ? 0.9m : 1.0m;
        return baseCost * serviceMultiplier * passengers * discount;
    }
}

public class TrainCostCalculationStrategy : ICostCalculationStrategy
{
    public decimal CalculateCost(decimal distance, string serviceClass, int passengers, bool hasDiscount)
    {
        decimal baseCost = distance * 0.3m;
        decimal serviceMultiplier = serviceClass == "Business" ? 1.5m : 1.0m;
        decimal discount = hasDiscount ? 0.85m : 1.0m;
        return baseCost * serviceMultiplier * passengers * discount;
    }
}

public class BusCostCalculationStrategy : ICostCalculationStrategy
{
    public decimal CalculateCost(decimal distance, string serviceClass, int passengers, bool hasDiscount)
    {
        decimal baseCost = distance * 0.2m;
        decimal serviceMultiplier = serviceClass == "Business" ? 1.2m : 1.0m;
        decimal discount = hasDiscount ? 0.8m : 1.0m;
        return baseCost * serviceMultiplier * passengers * discount;
    }
}

public class TravelBookingContext
{
    private ICostCalculationStrategy _strategy;

    public void SetStrategy(ICostCalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal CalculateCost(decimal distance, string serviceClass, int passengers, bool hasDiscount)
    {
        return _strategy.CalculateCost(distance, serviceClass, passengers, hasDiscount);
    }
}
*/

//Паттерн Наблюдатель

public interface IObserver
{
    void Update(string stockSymbol, decimal stockPrice);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer, string stockSymbol);
    void RemoveObserver(IObserver observer, string stockSymbol);
    void NotifyObservers(string stockSymbol);
}

public class StockExchange : ISubject
{
    private Dictionary<string, decimal> _stocks = new Dictionary<string, decimal>();
    private Dictionary<string, List<IObserver>> _observers = new Dictionary<string, List<IObserver>>();

    public void RegisterObserver(IObserver observer, string stockSymbol)
    {
        if (!_observers.ContainsKey(stockSymbol))
        {
            _observers[stockSymbol] = new List<IObserver>();
        }
        _observers[stockSymbol].Add(observer);
    }

    public void RemoveObserver(IObserver observer, string stockSymbol)
    {
        if (_observers.ContainsKey(stockSymbol))
        {
            _observers[stockSymbol].Remove(observer);
        }
    }

    public void NotifyObservers(string stockSymbol)
    {
        if (_observers.ContainsKey(stockSymbol))
        {
            foreach (var observer in _observers[stockSymbol])
            {
                observer.Update(stockSymbol, _stocks[stockSymbol]);
            }
        }
    }

    public void UpdateStockPrice(string stockSymbol, decimal newPrice)
    {
        _stocks[stockSymbol] = newPrice;
        NotifyObservers(stockSymbol);
    }
}

public class Trader : IObserver
{
    public void Update(string stockSymbol, decimal stockPrice)
    {
        Console.WriteLine($"Трейдер: Цена акции {stockSymbol} изменилась на {stockPrice} руб.");
    }
}

public class TradingRobot : IObserver
{
    private decimal _threshold;

    public TradingRobot(decimal threshold)
    {
        _threshold = threshold;
    }

    public void Update(string stockSymbol, decimal stockPrice)
    {
        if (stockPrice >= _threshold)
        {
            Console.WriteLine($"Робот: Покупка акции {stockSymbol} по цене {stockPrice} руб.");
        }
        else
        {
            Console.WriteLine($"Робот: Продажа акции {stockSymbol} по цене {stockPrice} руб.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Стратегия
        /*
        var travelContext = new TravelBookingContext();

        Console.WriteLine("Выберите тип транспорта: самолет, поезд, автобус");
        string transport = Console.ReadLine();

        Console.WriteLine("Введите расстояние (км): ");
        decimal distance = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Выберите класс обслуживания: эконом, бизнес");
        string serviceClass = Console.ReadLine();

        Console.WriteLine("Введите количество пассажиров: ");
        int passengers = int.Parse(Console.ReadLine());

        Console.WriteLine("Есть ли скидка? (да/нет): ");
        bool hasDiscount = Console.ReadLine().ToLower() == "да";

        switch (transport)
        {
            case "самолет":
                travelContext.SetStrategy(new AirplaneCostCalculationStrategy());
                break;
            case "поезд":
                travelContext.SetStrategy(new TrainCostCalculationStrategy());
                break;
            case "автобус":
                travelContext.SetStrategy(new BusCostCalculationStrategy());
                break;
            default:
                Console.WriteLine("Неверный тип транспорта.");
                return;
        }

        decimal cost = travelContext.CalculateCost(distance, serviceClass, passengers, hasDiscount);
        Console.WriteLine($"Стоимость поездки: {cost} руб.");
        */
        // Наблюдатель 

        StockExchange stockExchange = new StockExchange();

        Trader trader = new Trader();
        TradingRobot robot = new TradingRobot(100);

        stockExchange.RegisterObserver(trader, "AAPL");
        stockExchange.RegisterObserver(robot, "AAPL");

        stockExchange.UpdateStockPrice("AAPL", 95);
        stockExchange.UpdateStockPrice("AAPL", 105);
    }
}
