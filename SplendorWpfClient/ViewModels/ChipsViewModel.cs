namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.Generic;
    using System.Windows.Media;

    using Color = SplendorCore.Models.Color;

    #endregion

    public class ChipsViewModel : AbstractViewModel
    {
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
            this.BorderColor = new SolidColorBrush(borderColor.HasValue ? GetForeColor(borderColor.Value) : Colors.Black);
        }

        #endregion

        #region Public Properties

        public SolidColorBrush BackColor { get; set; }

        public SolidColorBrush BorderColor { get; set; }

        public SolidColorBrush ForeColor { get; set; }

        public int Value { get; set; }

        #endregion
    }
}