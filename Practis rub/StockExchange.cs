using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practis_rub
{
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

}
