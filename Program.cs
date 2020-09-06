using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBinarySerialization();
            TestJsonSerialization();

            Console.ReadLine();
        }

        static void TestBinarySerialization()
        {
            Console.WriteLine("********** Serialize as binary *********");
            string fileName = "Binary.dat";
            PakShuka pakShuka = new PakShuka();
            pakShuka.PrintInfo();
            pakShuka.YerevanCitySup();
            pakShuka.ATMs();
            SaveToBinary(pakShuka,fileName);

            Console.WriteLine("\n********** Deserialization *********");
            PakShuka loadPakshuka = LoadFromBinaryFile(fileName);
            loadPakshuka.PrintInfo();
            loadPakshuka.YerevanCitySup();
            loadPakshuka.ATMs();

            //Just for fun changing readonly long type of class, after it's declaration
            Type xType = loadPakshuka.GetType();
            var xVar = xType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            xVar[1].SetValue(loadPakshuka,374747474);
            loadPakshuka.PrintInfo();
        }

        static void TestJsonSerialization()
        {
            Console.WriteLine("\n********** Serialize as JSON *********");
            string fileName = "JSON.txt";
            Tumo tumo = new Tumo();
            tumo.PrintInfo();
            tumo.CinemaStar();
            tumo.ReferenceRooms();
            SaveToJSON(tumo,fileName);

            Console.WriteLine("\n********** Deserialization *********");
            Tumo loadTumo = LoadFromJSONFile(fileName);
            loadTumo.PrintInfo();
            loadTumo.CinemaStar();
            loadTumo.ReferenceRooms();
        }

        static void SaveToBinary(object obj, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, obj);
            }
            Console.WriteLine("\nObject saved in the file in binary format");
        }

        static PakShuka LoadFromBinaryFile(string fileName)
        {
            PakShuka recoveredPakshuka = null;
            FileStream fileStream = new FileStream(fileName,FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                recoveredPakshuka = (PakShuka)formatter.Deserialize(fileStream);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason" + e.Message);
            }
            finally
            {
                fileStream.Close();
            }

            return recoveredPakshuka;
        }

        static void SaveToJSON(object obj, string fileName)
        {
            string jsonString = JsonSerializer.Serialize(obj);
            File.WriteAllText(fileName,jsonString);

            Console.WriteLine("\nObject saved in the file in JSON format");
        }

        static Tumo LoadFromJSONFile(string fileName)
        {
            Tumo recoveredTumo = null;
            string jsonString;

            try
            {
                jsonString = File.ReadAllText(fileName);
                recoveredTumo = JsonSerializer.Deserialize<Tumo>(jsonString);
            }   
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize file. Reason: " + e.Message);
            }

            return recoveredTumo;
        }
        
    }

}
