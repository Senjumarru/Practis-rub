using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practis_rub
{
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

}
