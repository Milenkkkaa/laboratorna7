using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class House : IComparable
    {
        public double width { get; set; }
        public double length { get; set; }
        public double height { get; set; }
        public int room { get; set; }
        public int floor { get; set; }
        public double value { get; set; }
        public double price { get; set; }
        public bool hasForniture { get; set; }
        public double getCost()
        {

            return (width * length) * price;
        }
        public double heating()
        {
            return Heating;
        }
        public double GetCost
        {
            get
            {
                return getCost();
            }
            set
            {
            }
        }
        public double Heating
        {
            get
            {
                return heating();
            }
            set
            {
            }
        }
        public House()
        {

        }
        public House(double Width, double Length,
            double Height, int Room, int Floor,
            double Value, double Price, bool HasForniture,
            double GetCost, double Heating)
        {
            width = Width;
            length = Length;
            height = Height;
            room = Room;
            floor = Floor;
            value = Value;
            price = Price;
            hasForniture = HasForniture;
        }
        public string Info()
        {
            return price + ", " + width + ", " + length + ", " + height;
        }
       public int CompareTo(object obj)
        {
            if (obj == null) return 1; 
            House house = obj as House;
            if (house == null) throw new ArgumentException("Object is not a House");
            return this.price.CompareTo(house.price); 
        }
    }
}
