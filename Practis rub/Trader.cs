using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practis_rub
{
    public class Trader : IObserver
    {
        public void Update(string stockSymbol, decimal stockPrice)
        {
            Console.WriteLine($"Трейдер: Цена акции {stockSymbol} изменилась на {stockPrice} руб.");
        }
    }

}
