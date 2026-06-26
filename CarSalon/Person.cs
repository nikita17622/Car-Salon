using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalon
{
    internal class Person
    {
        private static int _id = 1;
        private int _age = 1;
        private string _name;
        private decimal _balance;
        private static int count_noId = 1;

        public int Id { get; private set; }

        public int Age
        {
            get => _age;
            set
            {
                if (value > 17) _age = value;
                else throw new ArgumentException("Возраст должен быть 18 лет или больше");
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) _name = "User - " + count_noId++;
                else _name = value;
            }
        }

        public decimal Balance
        {
            get => _balance;
            set
            {
                if (value >= 0) _balance = value;
                else throw new ArgumentException($"Отрицательный баланс! ({value})");
            }
        }

        public Car Have_Car { get; set; }

        public Person(int age, string name, decimal balance, Car have_car)
        {
            Id = _id++;
            Age = age;
            Name = name;
            Balance = balance;
            Have_Car = have_car;
        }

        public void ShowPersonData()
        {
            Console.WriteLine($"Имя : {Name}, id : {Id}, возраст : {Age}, баланс : {Balance:C}, автомобиль : {(Have_Car == null ? "-----" : Have_Car.Name)}");
        }

        public void BuyCar(int number, List<Car> cars)
        {
            foreach (var car in cars)
            {
                if (car.Number == number)
                {
                    if (Balance >= car.Cost)
                    {
                        Balance -= car.Cost;
                        Have_Car = car;
                        Console.WriteLine($"\nПоздравляем! Вы купили {car.Name}!");
                        ShowPersonData();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"\nНедостаточно средств. Вам не хватает {(car.Cost - Balance):C}");
                        return;
                    }
                }
            }
            Console.WriteLine("\nВы выбрали несуществующий транспорт.");
        }

        public void BuyMoto(int number, List<Moto> motos)
        {
            foreach (var moto in motos)
            {
                if (moto.Number == number)
                {
                    if (Balance >= moto.Cost)
                    {
                        Balance -= moto.Cost;
                        Have_Car = moto;
                        Console.WriteLine($"\nПоздравляем! Вы купили мотоцикл {moto.Name}!");
                        ShowPersonData();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"\nНедостаточно средств. Вам не хватает {(moto.Cost - Balance):C}");
                        return;
                    }
                }
            }
            Console.WriteLine("\nВы выбрали несуществующий мотоцикл.");
        }

        public void SellCar()
        {
            if (Have_Car is null)
            {
                Console.WriteLine("\nУ вас нет транспорта для продажи!");
                return;
            }

            decimal returnAmount = 0.85m * Have_Car.Cost;
            Console.WriteLine($"\nПри возврате {Have_Car.Name}, вам вернут 85% ранее заплаченной суммы: {returnAmount:C}");
            Balance += returnAmount;
            Console.WriteLine($"{Have_Car.Name} возвращен!");
            Have_Car = null;
            ShowPersonData();
        }

    }
}

