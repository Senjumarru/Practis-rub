using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practis_rub
{
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

}
