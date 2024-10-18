using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practis_rub
{
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

}
