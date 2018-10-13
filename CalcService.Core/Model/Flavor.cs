using System;

namespace CalcService.Model
{
    public class Flavor
    {
        internal string Name { get; set; }
        internal string NormalizedName { get; set; }
        internal bool IsDefault { get; set; }
        internal double Acid { get; set; }
    }
}
