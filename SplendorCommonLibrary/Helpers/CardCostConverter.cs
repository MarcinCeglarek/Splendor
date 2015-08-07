namespace SplendorCommonLibrary.Helpers
{
    #region

    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using SplendorCommonLibrary.Models;

    #endregion

    public class CardCostConverter : JsonConverter
    {
        #region Public Methods and Operators

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Chips);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var jsonObject = JObject.Load(reader);
            var result = new Chips();

            foreach (var property in jsonObject)
            {
                var color = (Color)Enum.Parse(typeof(Color), property.Key);
                result[color] = property.Value.Value<int>();
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}