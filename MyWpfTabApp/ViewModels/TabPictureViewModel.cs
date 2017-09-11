using System.Collections.Generic;
using System.ComponentModel;

namespace MyWpfTabApp.ViewModels
{
    class TabPictureViewModel : ITabViewModel, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string header;
        public string Header
        {
            get { return header; }
            set { SetField(ref header, value, nameof(Header)); }
        }

        private string myImageSource;
        public string MyImageSource
        {
            get { return myImageSource; }
            set { SetField(ref myImageSource, value, nameof(MyImageSource)); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public TabPictureViewModel()
        {
            MyImageSource = @"/MyWpfTabApp;component/Resources/MyPicture.jpg";
        }

        /******************************/
        /*     Command Functions      */
        /******************************/
        #region Command Functions
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
}
