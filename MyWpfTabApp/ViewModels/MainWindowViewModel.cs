using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MyWpfTabApp.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private int selectedTabIndex;
        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set { SetField(ref selectedTabIndex, value, nameof(SelectedTabIndex)); }
        }

        private ITabViewModel selectedTabViewModel;
        public ITabViewModel SelectedTabViewModel
        {
            get { return selectedTabViewModel; }
            set { SetField(ref selectedTabViewModel, value, nameof(SelectedTabViewModel)); }
        }

        private ObservableCollection<ITabViewModel> tabViewModels;
        public ObservableCollection<ITabViewModel> TabViewModels
        {
            get { return tabViewModels; }
            set { SetField(ref tabViewModels, value, nameof(TabViewModels)); }
        }

        public ICommand ExitCommand { get { return new RelayCommand(param => this.ExitCF(), param => this.CanExitCF()); } }
        public ICommand AddPictureTabCommand { get { return new RelayCommand(param => this.AddPictureTabCF(), param => this.CanAddPictureTabCF()); } }
        public ICommand AddTextTabCommand { get { return new RelayCommand(param => this.AddTextTabCF(), param => this.CanAddTextTabCF()); } }
        public ICommand RemoveSelectedTabCommand { get { return new RelayCommand(param => this.RemoveSelectedTabCF(), param => this.CanRemoveSelectedTabCF()); } }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowViewModel()
        {
            TabViewModels = new ObservableCollection<ITabViewModel>
            {
                new TabPictureViewModel() { Header = "Picture" },
                new TabTextViewModel() { Header = "Text" }
            };

            SelectedTabIndex = 0;
        }

        /******************************/
        /*     Command Functions      */
        /******************************/
        #region Command Functions

        /// <summary>
        /// Exit
        /// </summary>
        public void ExitCF()
        {
            App.Current.Shutdown();
        }

        /// <summary>
        /// CanExit
        /// </summary>
        bool CanExitCF()
        {
            return true;
        }

        /// <summary>
        /// AddPictureTabCF
        /// </summary>
        public void AddPictureTabCF()
        {
            TabViewModels.Add(new TabPictureViewModel() { Header = "Picture" });
            SelectedTabIndex = TabViewModels.Count - 1;
        }

        /// <summary>
        /// CanAddPictureTabCF
        /// </summary>
        /// <returns></returns>
        bool CanAddPictureTabCF()
        {
            return true;
        }

        /// <summary>
        /// AddTextTabCF
        /// </summary>
        public void AddTextTabCF()
        {
            TabViewModels.Add(new TabTextViewModel() { Header = "Text" });
            SelectedTabIndex = TabViewModels.Count - 1;
        }

        /// <summary>
        /// CanAddTextTabCF
        /// </summary>
        /// <returns></returns>
        bool CanAddTextTabCF()
        {
            return true;
        }

        /// <summary>
        /// RemoveSelectedTabCF
        /// </summary>
        public void RemoveSelectedTabCF()
        {
            TabViewModels.Remove(SelectedTabViewModel);
        }

        /// <summary>
        /// CanRemoveSelectedTabCF
        /// </summary>
        /// <returns></returns>
        bool CanRemoveSelectedTabCF()
        {
            return TabViewModels.Count>0?true:false;
        }

        #endregion
        /******************************/
        /*  EventToCommand Functions  */
        /******************************/
        #region EventToCommand Functions
        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        /// <summary>
        /// SetField
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="p"></param>
        private void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
        #endregion
    }

    class RelayCommand : ICommand
    {
        /// <summary>
        /// Vars
        /// <summary>
        readonly System.Action<object> _execute;
        readonly System.Predicate<object> _canExecute;

        /// <summary>
        /// Constructor
        /// </summary>
        public RelayCommand(System.Action<object> execute) : this(execute, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(System.Action<object> execute, System.Predicate<object> canExecute)
        {
            _execute = execute ?? throw new System.ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        #region ICommand Members

        [System.Diagnostics.DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion // ICommand Members
    }

}
