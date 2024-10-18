using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practis_rub
{
    public interface ISubject
    {
        void RegisterObserver(IObserver observer, string stockSymbol);
        void RemoveObserver(IObserver observer, string stockSymbol);
        void NotifyObservers(string stockSymbol);
    }

}
