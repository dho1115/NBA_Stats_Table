using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace NBA_Stats_Sheet
{
    [Serializable]
    public class Stats : ISerializable
    {
        public string Player { get; set; }
        public decimal Points { get; set; }
        public decimal Rebounds { get; set; }
        public decimal Assists { get; set; } 

        public Stats(string play = "", decimal pts = 0, decimal reb = 0, decimal asst = 0)
        {
            Player = play;
            Points = pts;
            Rebounds = reb;
            Assists = asst;
        }

        //The constructor below is what the XML Serializer will read.

        
        public Stats()
        {
            
        } 
        
        public override string ToString()
        {
            return string.Format("Player: {0} \tPoints: {1} \tRebounds: {2} \tAssists:{3}",
                Player, Points, Rebounds, Assists);
        }


        /// <summary>
        /// SERIALIZE data into a separate file.
        /// </summary>
        /// <param name="info">Set up "Key Value" pair.</param>
        /// <param name="context"></param>

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Player: ", Player);
            info.AddValue("Points: ", Points);
            info.AddValue("Rebounds: ", Rebounds);
            info.AddValue("Assists: ", Assists);
        } 

        /// <summary>
        /// DESERIALIZE data into something we can read.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        
        public Stats(SerializationInfo info, StreamingContext context)
        {
            info.GetValue("Player: ", typeof(string));
            info.GetValue("Points: ", typeof(decimal));
            info.GetValue("Rebounds: ", typeof(decimal));
            info.GetValue("Assists: ", typeof(decimal));
        }
    }
}
