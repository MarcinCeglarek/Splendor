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

        private static readonly Color Black = Colors.Black;

        private static readonly Color Blue = Colors.RoyalBlue;

        private static readonly Color Gold = Colors.Gold;

        private static readonly Color Green = Colors.LimeGreen;

        private static readonly Color Red = Colors.OrangeRed;

        private static readonly Color White = Colors.WhiteSmoke;

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