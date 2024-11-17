using Lab7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lab7
{
    internal class Program
    {
        static List<House> houses;
        static void PrintHouses()
        {
            foreach (House house in houses)
            {
                Console.WriteLine(house.Info().Replace('i', 'i'));
            }
        }
        static void Main(string[] args)
        {
            houses = new List<House>();
            FileStream fs = new FileStream("binary.houses", FileMode.Open);
            BinaryReader reader = new BinaryReader(fs);
            try
            {
                House tempHouse;
                Console.WriteLine("Читаєсо дані з файлу...\n");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    tempHouse = new House();
                    for (int i = 1; i <= 10; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                tempHouse.width = reader.ReadDouble(); break;
                            case 2:
                                tempHouse.length = reader.ReadDouble(); break;
                            case 3:
                                tempHouse.height = reader.ReadDouble(); break;
                            case 4:
                                tempHouse.room = reader.ReadInt32(); break;
                            case 5:
                                tempHouse.floor = reader.ReadInt32(); break;
                            case 6:
                                tempHouse.value = reader.ReadDouble(); break;
                            case 7:
                                tempHouse.price = reader.ReadDouble(); break;
                            case 8:
                                tempHouse.hasForniture = reader.ReadBoolean(); break;
                            case 9:
                                tempHouse.GetCost = reader.ReadDouble(); break;
                            case 10:
                                tempHouse.Heating = reader.ReadDouble(); break;
                                }
                        }
                        houses.Add(tempHouse);
                    }
                }
                catch (Exception ex)
            {
                Console.WriteLine("Сталась помилка: \n{0}", ex.Message);
            }
            finally
            {
                reader.Close();
            }
            Console.WriteLine("Несортований перелік будинків: {0}", houses.Count);
            PrintHouses();
            houses.Sort();
            Console.WriteLine("Сортований перлік будинків: {0}", houses.Count);
            PrintHouses();
            Console.WriteLine("Додаємо новий запис:");
            House house = new House(15, 25, 4, 5, 1, 16, 45000, false, 16875000, 6000);
            houses.Add(house);
            houses.Sort();
            Console.WriteLine("Перелік будинків: {0}", houses.Count());
            PrintHouses();
            Console.WriteLine("Видаляємо останнє значення");
            houses.RemoveAt(houses.Count - 1);
            Console.WriteLine("Перелік будинків: {0}", houses.Count);
            PrintHouses();
            Console.ReadKey();
        }
    }
}
