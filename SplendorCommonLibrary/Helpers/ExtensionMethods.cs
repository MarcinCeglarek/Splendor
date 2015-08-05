namespace SplendorCommonLibrary.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    public static class ExtensionMethods
    {
        // From https://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
        public static IList<T> Shuffle<T>(this IList<T> list)
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
                while (!(box[0] < n * (Byte.MaxValue / n)));
                var k = box[0] % n;
                n--;

                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}