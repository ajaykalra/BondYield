namespace BondYieldCalculator.Lib
{
    public interface IBondYieldCalculator
    {
        double CalcPrice(double coupon, int years, double face, double rate);

        double CalcYield(double coupon, int years, double face, double price);
    }
}
