namespace SplendorFormsClient
{
    #region

    using System.Windows.Media;

    #endregion

    public class FormsClientConstants
    {
        #region Static Fields

        public static ColorInfo Black = new ColorInfo("White", "#FF000000");

        public static ColorInfo Blue = new ColorInfo("White", "#FF0000FF");

        public static ColorInfo Green = new ColorInfo("White", "#FF00FF00");

        public static ColorInfo Red = new ColorInfo("White", "#FFFF0000");

        public static ColorInfo White = new ColorInfo("White", "#FFFFFFFF");

        #endregion

        public class ColorInfo
        {
            #region Fields

            private Brush brush;

            #endregion

            #region Constructors and Destructors

            public ColorInfo(string name, string hexValue)
            {
                this.Name = name;
                this.HexValue = hexValue;
            }

            #endregion

            #region Public Properties

            public Brush Brush
            {
                get
                {
                    return this.brush ?? (this.brush = (Brush)new BrushConverter().ConvertFromString(this.HexValue));
                }
            }

            public string HexValue { get; private set; }

            public string Name { get; private set; }

            #endregion
        }
    }
}