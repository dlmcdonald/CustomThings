using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace CustomThings.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Color SelectedColor { get; set; }

        DelegateCommand _redCommand;
        public DelegateCommand RedCommand =>
            _redCommand ?? (_redCommand = new DelegateCommand(RedCommandExecuted));

        public void RedCommandExecuted()
        {
            SetPaintColor(Color.Red);
        }

        DelegateCommand _greenCommand;
        public DelegateCommand GreenCommand =>
            _greenCommand ?? (_greenCommand = new DelegateCommand(GreenCommandExecuted));

        public void GreenCommandExecuted()
        {
            SetPaintColor(Color.Green);
        }

        DelegateCommand _blueCommand;
        public DelegateCommand BlueCommand =>
            _blueCommand ?? (_blueCommand = new DelegateCommand(BlueCommandExecuted));

        public void BlueCommandExecuted()
        {
            SetPaintColor(Color.Blue);
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = "Custom Controls";
        }

        void SetPaintColor(Color color)
        {
            SelectedColor = color;
        }
    }
}
