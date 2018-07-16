using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using BondYieldCalculator.Lib;

namespace BondYieldCalculator.Wpf.Calculator
{
    [Export]
    public class YieldViewModel : BindableBase
    {
        #region fields

        private readonly IBondYieldCalculator _bondYieldCalculator;
        private double _yield;
        private bool _showYield;
        private string _elapsedTime;

        #endregion  fields

        [ImportingConstructor]
        public YieldViewModel(IBondYieldCalculator bondYieldCalculator)
        {
            _bondYieldCalculator = bondYieldCalculator;
            Name = "Yield Calculator";
            Coupon = 0.1;
            Years = 5;
            Price = 832.4;
            FaceValue = 1000;
            ShouldShowYield = false;
            CalculateCommand = new RelayCommand(Calculate);
            ClearCommand = new RelayCommand(() => ShouldShowYield = false);
        }

        public string Name { get; set; }

        public double Coupon { get; set; }

        public int Years { get; set; }

        public double FaceValue { get; set; }

        public double Price { get; set; }

        public bool ShouldShowYield
        {
            get { return _showYield; }
            set { SetProperty(ref _showYield, value); }
        }

        public double Yield
        {
            get { return _yield; }
            set { SetProperty(ref _yield, value); }
        }

        public string ElapsedTime
        {
            get { return _elapsedTime; }
            set { SetProperty(ref _elapsedTime, value); }
        }
        public ICommand CalculateCommand { get; set; }

        public ICommand ClearCommand { get; set; }

        async void Calculate()
        {
            double coupon = Coupon, faceValue = FaceValue, price = Price;
            int years = Years;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            // You can disable the button here or show progress indicator etc
            Yield = await Task.Run(() =>
            {
                // This takes place on a background thread.
                var result = _bondYieldCalculator.CalcYield(coupon, years, faceValue, price);
                return result;
            });
            // Action here and assignment to Price takes place on UI thread
            sw.Stop();
            ElapsedTime = sw.Elapsed.TotalSeconds.ToString("F5");
            ShouldShowYield = true;
        }
    }
}