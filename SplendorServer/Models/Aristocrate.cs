namespace SplendorServer.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Aristocrate
    {
        [DataMember]
        public int VictoryPoints { get; set; }

        [DataMember]
        public Chips RequiredCards { get; set; }
    }
}