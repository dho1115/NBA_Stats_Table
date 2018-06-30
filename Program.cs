using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace NBA_Stats_Sheet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stats KevinDurant = new Stats("Kevin Durant", (decimal)26.4, (decimal)6.8, (decimal)5.4);

            List<Stats> NBAPlayers = new List<Stats>
            {
                new Stats("Kevin Durant", (decimal)26.4, (decimal)6.8, (decimal)5.4),
                new Stats("Julius Randle", (decimal)16.1, (decimal)8.0, (decimal)2.6),                
                new Stats("Rajon Rondo", (decimal)8.3, (decimal)4.0, (decimal)8.2),
                new Stats("Steven Adams", (decimal)13.9, (decimal)9.0, (decimal)1.2),
                new Stats("Andrew Wiggins", (decimal)17.7, (decimal)4.4, (decimal)2.0)
            };

            // ***** SERIALIZER *****

            //XML Serializer converts the TYPE to XML.
            XmlSerializer NBA = new XmlSerializer(typeof(List<Stats>));

            //StreamWriter creates the FILE NAME and FILE DESTINATION.
            StreamWriter sw = new StreamWriter(@"C:\Users\Owner\Desktop\NBAStats.txt");

            NBA.Serialize(sw, NBAPlayers);

            sw.Close();
            sw.Dispose();                     

            // ***** DESERIALIZER *****

            XmlSerializer deserialize = new XmlSerializer(typeof(List<Stats>));
            StreamReader sr = new StreamReader(@"C:\Users\Owner\Desktop\NBAStats.txt");
            object obj = deserialize.Deserialize(sr);
            List<Stats> XMLList = (List<Stats>)obj;

            sr.Close();
            sr.Dispose();

            foreach (var item in XMLList)
            {
                Console.WriteLine(item);
            }                  

            Console.ReadLine();
        }
    }
}
