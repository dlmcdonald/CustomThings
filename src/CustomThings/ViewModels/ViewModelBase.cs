using System;
using System.Threading.Tasks;
using Prism;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace CustomThings.ViewModels
{
    public class ViewModelBase : BindableBase, IApplicationLifecycleAware, IActiveAware, INavigationAware, IDestructible, IConfirmNavigation, IConfirmNavigationAsync, IPageLifecycleAware
    {
        protected IPageDialogService _pageDialogService { get; }

        protected IDeviceService _deviceService { get; }

        protected INavigationService _navigationService { get; }

        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService,
                             IDeviceService deviceService)
        {
            _pageDialogService = pageDialogService;
            _deviceService = deviceService;
            _navigationService = navigationService;
        }

        protected string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        string _subtitle;
        public string Subtitle
        {
            get => _subtitle;
            set => SetProperty(ref _subtitle, value);
        }

        string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value, onChanged: OnIsBusyChanged);
        }

        bool _isNotBusy;
        public bool IsNotBusy
        {
            get => _isNotBusy;
            set => SetProperty(ref _isNotBusy, value, onChanged: OnIsNotBusyChanged);
        }

        bool _canLoadMore;
        public bool CanLoadMore
        {
            get => _canLoadMore;
            set => SetProperty(ref _canLoadMore, value);
        }

        string _header;
        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        string _footer;
        public string Footer
        {
            get => _footer;
            set => SetProperty(ref _footer, value);
        }

        void OnIsBusyChanged() => IsNotBusy = !IsBusy;

        void OnIsNotBusyChanged() => IsBusy = !IsNotBusy;

        #region IActiveAware

        bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, onChanged: OnIsActiveChanged);
        }

        public event EventHandler IsActiveChanged;

        void OnIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);

            if (IsActive)
            {
                OnIsActive();
            }
            else
            {
                OnIsNotActive();
            }
        }

        protected virtual void OnIsActive() { }

        protected virtual void OnIsNotActive() { }

        #endregion IActiveAware

        #region INavigationAware

        public virtual void OnNavigatingTo(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        #endregion INavigationAware

        #region IDestructible

        public virtual void Destroy() { }

        #endregion IDestructible

        #region IConfirmNavigation

        public virtual bool CanNavigate(INavigationParameters parameters) => true;

        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) =>
            Task.FromResult(CanNavigate(parameters));

        #endregion IConfirmNavigation

        #region IApplicationLifecycleAware

        public virtual void OnResume() { }

        public virtual void OnSleep() { }

        #endregion IApplicationLifecycleAware

        #region IPageLifecycleAware

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        #endregion IPageLifecycleAware
    }
}