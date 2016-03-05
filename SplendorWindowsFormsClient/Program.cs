namespace SplendorWindowsFormsClient
{
    #region

    using System;
    using System.Windows.Forms;

    #endregion

    internal static class Program
    {
        #region Public Properties

        public static MainWindow MainWindow { get; private set; }

        #endregion

        #region Methods

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow = new MainWindow();
            Application.Run(MainWindow);
        }

        #endregion
    }
}