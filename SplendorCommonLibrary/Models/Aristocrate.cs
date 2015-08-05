namespace SplendorCommonLibrary.Models
{
    using System.Runtime.Serialization;

    using SplendorCommonLibrary.Models.ChipsModels;

    [DataContract]
    public class Aristocrate
    {
        [DataMember]
        public int VictoryPoints { get; set; }

        [DataMember]
        public Chips RequiredCards { get; set; }
    }
}