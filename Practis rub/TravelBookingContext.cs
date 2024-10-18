using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practis_rub
{
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

}
