using System;
using System.Collections.Generic;
using System.Text;

namespace BadMarketVuZ.Food.HealthyFood
{
    internal interface IHealthyFood : IFood
    {
        public int BenefitFactor { get; }
        
    }
}
