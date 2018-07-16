using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using BondYieldCalculator;
using BondYieldCalculator.Lib;
using BondYieldCalculator.Wpf;

namespace BondYieldCalculator.Wpf.Calculator
{
    [Export]
    public class PriceViewModel : BindableBase
    {
        #region fields

        private readonly IBondYieldCalculator _bondYieldCalculator;
        private double _price;
        private bool _showPrice;
        private string _elapsedTime;

        #endregion  fields

        [ImportingConstructor]
        public PriceViewModel(IBondYieldCalculator bondYieldCalculator)
        {
            _bondYieldCalculator = bondYieldCalculator;
            Name = "Price Calculator";
            Coupon = 0.1;
            Years = 5;
            Rate = 0.15;
            FaceValue = 1000;
            ShouldShowPrice = false;
            CalculateCommand = new RelayCommand(Calculate);
            ClearCommand = new RelayCommand(() => ShouldShowPrice = false);
        }

        public string Name { get; set; }

        public double Coupon { get; set; }

        public int Years { get; set; }

        public double FaceValue { get; set; }

        public double Rate { get; set; }

        public string ElapsedTime
        {
            get { return _elapsedTime; }
            set { SetProperty(ref _elapsedTime, value); }
        }

        public bool ShouldShowPrice
        {
            get {  return _showPrice; }
            set { SetProperty(ref _showPrice, value); }
        }

        public double Price
        {
            get { return _price; }
            set { SetProperty(ref _price, value);}
         }

        public ICommand CalculateCommand { get; set; }

        public ICommand ClearCommand { get; set; }

        async void Calculate()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // You can disable the button here or show progress indicator etc
            Price = await Task.Run(() =>
            {
                // This takes place on a background thread.
                var price = _bondYieldCalculator.CalcPrice(Coupon, Years, FaceValue, Rate);
                //Thread.Sleep(2000); // testing
                return price;
            });
            // Action here and assignment to Price takes place on UI thread
            sw.Stop();
            ElapsedTime = sw.Elapsed.TotalSeconds.ToString("F5");
            ShouldShowPrice = true;
        }
    }
}
