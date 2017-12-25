using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Serialization_Pract
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NAMEPOSITION = 0, LASTNAMEPOSITION = 1, PHONEPOSITION = 2, YEAROFBIRTH = 3;
            List<Person> collection = new List<Person>();
            #region CSV
            string[] filecsv = File.ReadAllLines(@"C:\name_of_directory\filecsv.csv");
            for (int i = 0; i < filecsv.Length; i++)
            {
                string[] lineTemp = filecsv[i].Split(',');
                Person personTemp = new Person();
                personTemp.Name = lineTemp[NAMEPOSITION];
                personTemp.LastName = lineTemp[LASTNAMEPOSITION];
                personTemp.Phone = lineTemp[PHONEPOSITION];
                personTemp.YearOfBirth = lineTemp[YEAROFBIRTH];
                collection.Add(personTemp);
            }
            #endregion

            Person[] personArray = collection.ToArray();

            #region SOAP
            SoapFormatter Soap = new SoapFormatter();
            using (FileStream stream = new FileStream(@"C:\name_of_directory\SoapPerson.dat", FileMode.OpenOrCreate))
            {
                Soap.Serialize(stream, personArray);
            }
            #endregion
            Console.WriteLine("SOAP успешно записан!");

            #region Json
            //string Json = JsonConvert.SerializeObject(personArray);
            JsonSerializer Json = new JsonSerializer();
            using (StreamWriter fs = new StreamWriter(@"C:\name_of_directory\JsonPerson.txt"))
            {
                using (JsonWriter writer = new JsonTextWriter(fs))
                {
                    Json.Serialize(writer, personArray);
                }
            }

            //    Person[] newPersonArray = JsonConvert.DeserializeObject<Person[]>(Json);
            //byte[] byteArray = Encoding.UTF8.GetBytes(Json);
            //using (FileStream stream = new FileStream(@"C:\name_of_directory\JsonPerson.json", FileMode.OpenOrCreate))
            //{
            //    stream.Write(byteArray, 0, byteArray.Length);
            //}
            #endregion
            Console.WriteLine("Json упсешно записан!");
        }
    }
}
