namespace CalcService.Model
{
    public class Supplement
    {
        internal string Name { get; set; }
        internal string NormalizedName { get; set; }
        internal bool IsDefault { get; set; }
        internal double Price { get; set; }
        internal double Factor { get; set; }
    }
}
