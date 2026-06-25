using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalon
{
    internal class Moto : Car
    {
        public int Quantity_Seat { get; set; }
        public int Quantity_Horses { get; set; }

        public Moto(string name, decimal cost, int yearCreation, int speed, string fuelType, 
                    int quantitySeat, int quantityHorses)
            : base(name, cost, yearCreation, speed, fuelType)
        {
            Quantity_Seat = quantitySeat;
            Quantity_Horses = quantityHorses;
        }

        public override string ToString()
        {
            return $" №{Number}. Мотоцикл : {Name}, стоимость : {Cost:C}, год выпуска : {Year_Creation}, макс. скорость : {Speed}, тип топлива : {FuelType}, мест : {Quantity_Seat}, л.с. : {Quantity_Horses}";
        }
    }
}
    

