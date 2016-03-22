namespace SplendorWpfClient.ViewModels
{
    #region

    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;

    using SplendorWpfClient.Annotations;

    #endregion

    public abstract class AbstractViewModel : INotifyPropertyChanged
    {
        #region Static Fields

        protected static readonly Color Black = Colors.Black;

        protected static readonly Color Blue = Colors.RoyalBlue;

        protected static readonly Color BorderHover = Colors.Magenta;

        protected static readonly Color BorderPurchasable = Colors.LimeGreen;

        protected static readonly Color BorderReservable = Colors.Red;

        protected static readonly Color Gold = Colors.Gold;

        protected static readonly Color Gray = Colors.Gray;

        protected static readonly Color Green = Colors.ForestGreen;

        protected static readonly Color Red = Colors.DarkRed;

        protected static readonly Color White = Colors.WhiteSmoke;

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected static Color GetBackColor(SplendorCore.Models.Color color)
        {
            switch (color)
            {
                case SplendorCore.Models.Color.Black:
                    return Black;
                case SplendorCore.Models.Color.Blue:
                    return Blue;
                case SplendorCore.Models.Color.Gold:
                    return Gold;
                case SplendorCore.Models.Color.Green:
                    return Green;
                case SplendorCore.Models.Color.Red:
                    return Red;
                case SplendorCore.Models.Color.White:
                    return White;
            }

            throw new NotSupportedException();
        }

        protected static Color GetForeColor(SplendorCore.Models.Color color)
        {
            switch (color)
            {
                case SplendorCore.Models.Color.Black:
                    return White;
                case SplendorCore.Models.Color.Blue:
                    return White;
                case SplendorCore.Models.Color.Gold:
                    return Black;
                case SplendorCore.Models.Color.Green:
                    return White;
                case SplendorCore.Models.Color.Red:
                    return White;
                case SplendorCore.Models.Color.White:
                    return Black;
            }

            throw new NotSupportedException();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                Debug.WriteLine("OnPropertyChanged " + propertyName);
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}