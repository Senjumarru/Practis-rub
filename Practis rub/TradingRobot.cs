using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practis_rub
{
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

}
