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

        public ChipsViewModel(KeyValuePair<Color, int> chips, Color? borderColor = null)
        {
            this.BackColor = new SolidColorBrush(GetBackColor(chips.Key));
            this.ForeColor = new SolidColorBrush(GetForeColor(chips.Key));
            this.BorderColor = new SolidColorBrush(borderColor.HasValue ? GetForeColor(borderColor.Value) : GetForeColor(chips.Key));
            
            this.Value = chips.Value;
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