namespace SplendorWpfClient.ViewModels
{
    #region

    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using SplendorWpfClient.Annotations;

    #endregion

    public abstract class AbstractViewModel : INotifyPropertyChanged
    {
        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}