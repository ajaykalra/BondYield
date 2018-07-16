using System.ComponentModel.Composition;

namespace BondYieldCalculator.Wpf
{
    [Export]
    class MainWindowModel : BindableBase
    {
        private int _selectedTabIndex;

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { SetProperty(ref _selectedTabIndex, value); }
        }
    }
}
