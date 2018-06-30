using System;
using System.IO;
using System.Xml.Serialization;

namespace NBA_Stats_Sheet
{
    class Program
    {
        static void Main(string[] args)
        {
            Stats KevinDurant = new Stats("Kevin Durant", (decimal)26.4, (decimal)6.8, (decimal)5.4);

            //XML Serializer converts the TYPE to XML.
            XmlSerializer KDStats = new XmlSerializer(typeof(Stats));

            //StreamWriter creates the FILE NAME and FILE DESTINATION.
            StreamWriter sw = new StreamWriter(@"C:\Users\Owner\Desktop\NBAStats.txt");

            KDStats.Serialize(sw, KevinDurant);

            sw.Close();
            sw.Dispose();

            XmlSerializer deserialize = new XmlSerializer(typeof(Stats));
            StreamReader sr = new StreamReader(@"C:\Users\Owner\Desktop\NBAStats.txt");
            object obj = deserialize.Deserialize(sr);
            KevinDurant = (Stats)obj;
            sr.Close();
            sr.Dispose();

            
            Console.WriteLine(KevinDurant);

            

            Console.ReadLine();
        }
    }
}
