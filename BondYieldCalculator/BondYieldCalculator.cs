using System;
using System.ComponentModel.Composition;

namespace BondYieldCalculator.Lib
{
    [Export(typeof(IBondYieldCalculator))]
    public class BondYieldCalculator : IBondYieldCalculator
    {
        public double CalcPrice(double coupon, int years, double face, double rate)
        {
            double price = 0.0;

            for (int ii = 1; ii <= years; ii++)
            {
                price = price + coupon * 1000.0 / Math.Pow(1 + rate, ii);
            }

            return price + face / Math.Pow(1.0 + rate, years);
        }

        public double CalcYield(double coupon, int years, double face, double price)
        {
            double payment = coupon * face;
            double delta = 1.0;
            double accuracy = 0.0000001;
            double threshold = 1.0E-15;

            var yield = (payment + (face - price) / years) / ((face + price) / 2.0);
            double estPrice = CalcPrice(coupon, years, face, yield);

            while (Math.Abs(estPrice - price) > accuracy)
            {
                yield = estPrice > price ? yield + delta : yield - delta;
                estPrice = CalcPrice(coupon, years, face, yield);

                delta = delta / 2.0;
                if (delta < threshold) // This is a terminal condition
                    return 0.0; // can be changed as required.
            }

            return yield;
        }
    }
}
