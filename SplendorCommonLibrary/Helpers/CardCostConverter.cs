namespace SplendorCommonLibrary.Helpers
{
    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using SplendorCommonLibrary.Models;
    using SplendorCommonLibrary.Models.ChipsModels;

    public class CardCostConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
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
                switch (color)
                {
                    case Color.Black:
                        result.Add(new BlackChip(property.Value.Value<int>()));
                        break;
                    case Color.Blue:
                        result.Add(new BlueChip(property.Value.Value<int>()));
                        break;
                    case Color.Red:
                        result.Add(new RedChip(property.Value.Value<int>()));
                        break;
                    case Color.Green:
                        result.Add(new GreenChip(property.Value.Value<int>()));
                        break;
                    case Color.Gold:
                        result.Add(new GoldChip(property.Value.Value<int>()));
                        break;
                    case Color.White:
                        result.Add(new WhiteChip(property.Value.Value<int>()));
                        break;
                }
            }

            return result;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Chips);
        }
    }
}