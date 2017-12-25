using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializConsolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PC> collectionPC = new List<PC>();
            for (int i = 0; i < 5; i++)
            {
                PC PCTemp = new PC("PC200" + i, "5" + (i*2) + (i*5), "intel i" + i, "Nvidia 9" + i + "0");
                collectionPC.Add(PCTemp);
            }

            PC[] PCArray = collectionPC.ToArray();

            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = new FileStream(@"D:\listSerial.txt", FileMode.Create))
            {
                serializer.Serialize(stream, PCArray);
            }
            Console.WriteLine("'listSerial.txt' успешно записан!");
        }
    }
}
