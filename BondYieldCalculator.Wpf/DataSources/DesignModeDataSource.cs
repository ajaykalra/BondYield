using BondYieldCalculator.Wpf.Calculator;

namespace BondYieldCalculator.Wpf.DataSources
{
    public class DesignModeDataSource
    {
        public PriceViewModel PriceVM => new PriceViewModel(null) { Name = "Price Calculator", Years = 8, Coupon = 6, Rate = 0.05, ElapsedTime = "0.00123"};

        public YieldViewModel YieldVM => new YieldViewModel(null) { Name = "Yield Calculator", Years = 8, Coupon = 6, Price = 832.4, ElapsedTime = "0.00123" };
    }
}
