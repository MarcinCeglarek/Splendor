namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.Generic;
    using System.Windows.Media;

    using Color = SplendorCore.Models.Color;

    #endregion

    public class ChipsViewModel : AbstractViewModel
    {
        #region Fields

        private bool isMouseHover;

        private Color? orginalBorderColor;

        #endregion

        #region Constructors and Destructors

        public ChipsViewModel()
        {
        }

        public ChipsViewModel(Color color, int value)
        {
            this.BackColor = new SolidColorBrush(GetBackColor(color));
            this.ForeColor = new SolidColorBrush(GetForeColor(color));
            this.Value = value;
        }

        public ChipsViewModel(KeyValuePair<Color, int> chips, Color? borderColor = null)
            : this(chips.Key, chips.Value)
        {
            this.orginalBorderColor = borderColor;
        }

        #endregion

        #region Public Properties

        public SolidColorBrush BackColor { get; set; }

        public SolidColorBrush BorderColor
        {
            get
            {
                return this.IsMouseHover
                           ? new SolidColorBrush(Colors.Magenta)
                           : new SolidColorBrush(this.orginalBorderColor.HasValue ? GetForeColor(this.orginalBorderColor.Value) : Colors.Black);
            }
        }

        public SolidColorBrush ForeColor { get; set; }

        public bool IsMouseHover
        {
            get { return this.isMouseHover; }
            set
            {
                this.isMouseHover = value;
                this.OnPropertyChanged("BorderColor");
            }
        }

        public bool IsValuePositive { get { return this.Value > 0; } }

        public int IsValuePositiveOpacity { get { return this.IsValuePositive ? 100 : 0; } }

        public int Value { get; set; }

        #endregion
    }
}