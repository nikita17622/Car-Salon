using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalon
{
    internal class Car
    {
            public int Number { get; set; }
            public string Name { get; set; }
            public decimal Cost { get; set; }
            public int Year_Creation { get; set; }
            public int Speed { get; set; }
            public string FuelType { get; set; }

            public Car(string name, decimal cost, int yearCreation, int speed, string fuelType)
            {
                Name = name;
                Cost = cost;
                Year_Creation = yearCreation;
                Speed = speed;
                FuelType = fuelType;
            }

            public override string ToString()
            {
                return $" №{Number}. Модель : {Name}, стоимость : {Cost:C}, год выпуска : {Year_Creation}, макс. скорость : {Speed}, тип топлива : {FuelType}";
            }
        
    }
}

