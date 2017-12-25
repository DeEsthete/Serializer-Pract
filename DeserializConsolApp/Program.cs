using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DeserializConsolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PC> collectionPC = new List<PC>();

            BinaryFormatter serializer = new BinaryFormatter();

            using (FileStream stream = new FileStream(@"D:\listSerial.txt", FileMode.OpenOrCreate))
            {
                PC[] newPC = serializer.Deserialize(stream) as PC[];
                for (int i = 0; i < newPC.Length; i++)
                {
                    collectionPC.Add(newPC[i]);
                }
            }
            Console.WriteLine("listSerial объект успешно десерилизован!");
            Console.ReadLine();
        }
    }
}