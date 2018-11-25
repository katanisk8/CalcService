namespace CalcService.Core.Model
{
    public class Supplement
    {
        public SuplementType Type { get; set; }
        public double Price { get; set; }
        public double Factor { get; set; }
    }

    public enum SuplementType
    {
        Sugar = 0,
        Acid = 1,
        Water = 2,
        Yeast = 3,
        YeastFood = 4
    }
}