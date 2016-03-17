namespace SplendorCore.Helpers
{
    #region

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Security.Cryptography;

    #endregion

    public static class ExtensionMethods
    {
        // From https://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
        #region Public Methods and Operators

        public static List<T> Shuffle<T>(this List<T> list)
        {
            var provider = new RNGCryptoServiceProvider();
            var n = list.Count;
            while (n > 1)
            {
                var box = new byte[1];
                do
                {
                    provider.GetBytes(box);
                }
                while (!(box[0] < n * (byte.MaxValue / n)));
                var k = box[0] % n;
                n--;

                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        #endregion
    }
}