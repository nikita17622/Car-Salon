using System;
using System.Collections.Generic;

namespace Auto
{
    public class Person
    {
        private static int _id = 1;
        private int _age = 1;
        private string _name;
        private decimal _balance;
        static private int count_noId = 1;
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
                else throw new ArgumentException($"Отрицательный баланс! {value}");
            }
        }
        public Car Have_Car { get; set; }

        public Person(int age, string _name, decimal _balance, Car have_car)
        {
            Id = _id++;
            Age = age;
            Name = _name;
            Balance = _balance;
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
                    if (this.Balance >= car.Cost)
                    {
                        this.Balance -= car.Cost;
                        this.Have_Car = car;
                        Console.WriteLine($"\n Поздравляем! Вы купили {car.Name}!");
                        this.ShowPersonData();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"\n Недостаточно средств. Вам не хватает {(car.Cost - this.Balance):C}");
                        return;
                    }
                }
            }
            Console.WriteLine("\n Вы выбрали несуществующий транспорт.");
        }

        // Перегруженный метод для покупки мотоцикла
        public void BuyMoto(int number, List<Moto> motos)
        {
            foreach (var moto in motos)
            {
                if (moto.Number == number)
                {
                    if (this.Balance >= moto.Cost)
                    {
                        this.Balance -= moto.Cost;
                        this.Have_Car = moto; // Мото наследуется от Car, так что можно присвоить
                        Console.WriteLine($"\n Поздравляем! Вы купили мотоцикл {moto.Name}!");
                        this.ShowPersonData();
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"\n Недостаточно средств. Вам не хватает {(moto.Cost - this.Balance):C}");
                        return;
                    }
                }
            }
            Console.WriteLine("\n Вы выбрали несуществующий мотоцикл.");
        }

        public void SellCar()
        {
            if (this.Have_Car is null)
            {
                Console.WriteLine("\n У вас нет транспорта для продажи!");
                return;
            }

            decimal returnAmount = 0.85m * this.Have_Car.Cost;
            Console.WriteLine($"\n При возврате {this.Have_Car.Name}, вам вернут 85% ранее заплаченной суммы: {returnAmount:C}");
            this.Balance += returnAmount;
            Console.WriteLine($" {this.Have_Car.Name} возвращен!");
            this.Have_Car = null;
            this.ShowPersonData();
        }
    }

    public class Car
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Year_Creation { get; set; }
        public int Speed { get; set; }
        public string FuelType { get; set; }

        public Car(string _name, decimal _cost, int year_creation, int _speed, string fuel_type)
        {
            Name = _name;
            Cost = _cost;
            Year_Creation = year_creation;
            Speed = _speed;
            FuelType = fuel_type;
        }

        public override string ToString()
        {
            return $" №{Number}. Модель : {Name}, стоимость : {Cost:C}, год выпуска : {Year_Creation}, макс. скорость : {Speed}, тип топлива : {FuelType}";
        }
    }

    public class Moto : Car
    {
        public int Quantity_Seat { get; set; }
        public int Quantity_Horses { get; set; }

        public Moto(string _name, decimal _cost, int year_creation, int _speed, string fuel_type, int quantity_seat, int quantity_horses)
        : base(_name, _cost, year_creation, _speed, fuel_type)
        {
            Quantity_Seat = quantity_seat;
            Quantity_Horses = quantity_horses;
        }

        public override string ToString()
        {
            return $" №{Number}. Мотоцикл : {Name}, стоимость : {Cost:C}, год выпуска : {Year_Creation}, макс. скорость : {Speed}, тип топлива : {FuelType}, мест : {Quantity_Seat}, л.с. : {Quantity_Horses}";
        }
    }

    internal class Program
    {
        static void InitializeSalon(List<Car> cars, List<Moto> motos)
        {
            // Очищаем списки
            cars.Clear();
            motos.Clear();

            var CarData = new (string _name, decimal _cost, int year_creation, int _speed, string fuel_type)[]
            {
                ("Tesla Model 3", 45000m, 2023, 260, "Электро"),
                ("BMW X5", 65000m, 2023, 250, "Бензин"),
                ("Toyota Camry", 35000m, 2023, 220, "Бензин"),
                ("Honda Civic", 28000m, 2022, 210, "Бензин"),
                ("Mercedes E-Class", 55000m, 2023, 250, "Дизель"),
                ("Kia Sportage", 32000m, 2022, 200, "Бензин"),
                ("Lada Vesta", 15000m, 2023, 180, "Бензин"),
                ("Porsche 911", 120000m, 2023, 320, "Бензин")
            };

            // Добавляем машины с присвоением номера по индексу
            for (int i = 0; i < CarData.Length; i++)
            {
                Car newCar = new Car(CarData[i]._name, CarData[i]._cost, CarData[i].year_creation, CarData[i]._speed, CarData[i].fuel_type);
                newCar.Number = i + 1; // Присваиваем номер вручную
                cars.Add(newCar);
            }

            var MotoData = new (string _name, decimal _cost, int year_creation, int _speed, string fuel_type, int quantity_seat, int quantity_horses)[]
            {
                ("Yamaha R1", 18000m, 2023, 299, "Бензин", 2, 200),
                ("Harley Davidson", 25000m, 2022, 180, "Бензин", 2, 150),
                ("Suzuki GSX-R", 16000m, 2023, 280, "Бензин", 2, 190),
                ("Kawasaki Ninja", 17000m, 2022, 290, "Бензин", 2, 210)
            };

            // Добавляем мотоциклы с присвоением номера по индексу
            for (int i = 0; i < MotoData.Length; i++)
            {
                Moto newMoto = new Moto(MotoData[i]._name, MotoData[i]._cost, MotoData[i].year_creation, MotoData[i]._speed, MotoData[i].fuel_type, MotoData[i].quantity_seat, MotoData[i].quantity_horses);
                newMoto.Number = i + 1; // Присваиваем номер вручную
                motos.Add(newMoto);
            }
        }

        static void ShowSalon(List<Car> cars, List<Moto> motos)
        {
            Console.WriteLine("\n========== МАШИНЫ ==========");
            if (cars.Count == 0)
            {
                Console.WriteLine("Нет доступных машин");
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car.ToString());
                }
            }

            Console.WriteLine("\n========== МОТОЦИКЛЫ ==========");
            if (motos.Count == 0)
            {
                Console.WriteLine("Нет доступных мотоциклов");
            }
            else
            {
                foreach (var moto in motos)
                {
                    Console.WriteLine(moto.ToString());
                }
            }
            Console.WriteLine();
        }

        static Person AddPerson()
        {
            int age;
            string _name;
            decimal _balance;

            Console.WriteLine("\n=== ЗАПОЛНИТЕ ДАННЫЕ О СЕБЕ ===");
            Console.Write("Имя: ");
            _name = Console.ReadLine();

            Console.Write("Возраст: ");
            while (!int.TryParse(Console.ReadLine(), out age) || age < 18)
            {
                Console.Write("Некорректный возраст! Возраст должен быть 18+. Попробуйте снова: ");
            }

            Console.Write("Ваш баланс: ");
            while (!decimal.TryParse(Console.ReadLine(), out _balance) || _balance < 0)
            {
                Console.Write("Некорректный баланс! Введите положительное число: ");
            }

            Person newPerson = new Person(age, _name, _balance, null);
            Console.WriteLine("\n Пользователь успешно создан!");
            newPerson.ShowPersonData();
            return newPerson;
        }

        static void ShowAllUsers(List<Person> users)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\n Список пользователей пуст!");
                return;
            }

            Console.WriteLine("\n========== ВСЕ ПОЛЬЗОВАТЕЛИ ==========");
            for (int i = 0; i < users.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                users[i].ShowPersonData();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<Person> users = new List<Person>();
            List<Car> cars = new List<Car>();
            List<Moto> motos = new List<Moto>();

            // Инициализация автосалона
            InitializeSalon(cars, motos);

            int choice;
            do
            {
                Console.Clear();

                Console.WriteLine("╔═══════════════════════════════════════╗");
                Console.WriteLine("║      АВТОСАЛОН ТОП - МЕНЮ           ║");
                Console.WriteLine("╠═══════════════════════════════════════╣");
                Console.WriteLine("║  1. Добавить нового пользователя    ║");
                Console.WriteLine("║  2. Купить транспорт                ║");
                Console.WriteLine("║  3. Вернуть транспорт               ║");
                Console.WriteLine("║  4. Показать всех пользователей     ║");
                Console.WriteLine("║  5. Показать автосалон              ║");
                Console.WriteLine("║  0. Выход                          ║");
                Console.WriteLine("╚═══════════════════════════════════════╝");
                Console.Write("\nВаш выбор: ");

                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                {
                    Console.Write("Некорректный ввод! Выберите 0-5: ");
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        users.Add(AddPerson());
                        Console.WriteLine("\nНажмите Enter для продолжения...");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        if (users.Count == 0)
                        {
                            Console.WriteLine("❌ Сначала добавьте пользователя!");
                            Console.WriteLine("\nНажмите Enter для продолжения...");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("Выберите пользователя для покупки:");
                        for (int i = 0; i < users.Count; i++)
                        {
                            Console.Write($"{i + 1}. ");
                            users[i].ShowPersonData();
                        }
                        Console.Write("\nНомер пользователя: ");
                        int userIndex;
                        while (!int.TryParse(Console.ReadLine(), out userIndex) || userIndex < 1 || userIndex > users.Count)
                        {
                            Console.Write($"Некорректный номер! Введите от 1 до {users.Count}: ");
                        }
                        userIndex--;

                        // Выбор типа транспорта
                        Console.WriteLine("\nЧто хотите купить?");
                        Console.WriteLine("1. Автомобиль");
                        Console.WriteLine("2. Мотоцикл");
                        Console.Write("Ваш выбор: ");
                        int transportType;
                        while (!int.TryParse(Console.ReadLine(), out transportType) || transportType < 1 || transportType > 2)
                        {
                            Console.Write("Некорректный ввод! Выберите 1 или 2: ");
                        }

                        if (transportType == 1)
                        {
                            // Показываем машины
                            Console.WriteLine("\nСписок доступных автомобилей:");
                            foreach (var car in cars)
                            {
                                Console.WriteLine(car.ToString());
                            }

                            Console.Write("\nВведите номер автомобиля для покупки: ");
                            int carNumber;
                            while (!int.TryParse(Console.ReadLine(), out carNumber))
                            {
                                Console.Write("Введите корректный номер: ");
                            }

                            users[userIndex].BuyCar(carNumber, cars);
                        }
                        else
                        {
                            // Показываем мотоциклы
                            Console.WriteLine("\nСписок доступных мотоциклов:");
                            foreach (var moto in motos)
                            {
                                Console.WriteLine(moto.ToString());
                            }

                            Console.Write("\nВведите номер мотоцикла для покупки: ");
                            int motoNumber;
                            while (!int.TryParse(Console.ReadLine(), out motoNumber))
                            {
                                Console.Write("Введите корректный номер: ");
                            }

                            users[userIndex].BuyMoto(motoNumber, motos);
                        }

                        Console.WriteLine("\nНажмите Enter для продолжения...");
                        Console.ReadLine();
                        break;

                    case 3:
                        Console.Clear();
                        if (users.Count == 0)
                        {
                            Console.WriteLine("❌ Сначала добавьте пользователя!");
                            Console.WriteLine("\nНажмите Enter для продолжения...");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("Выберите пользователя для возврата транспорта:");
                        for (int i = 0; i < users.Count; i++)
                        {
                            Console.Write($"{i + 1}. ");
                            users[i].ShowPersonData();
                        }
                        Console.Write("\nНомер пользователя: ");
                        while (!int.TryParse(Console.ReadLine(), out userIndex) || userIndex < 1 || userIndex > users.Count)
                        {
                            Console.Write($"Некорректный номер! Введите от 1 до {users.Count}: ");
                        }
                        userIndex--;

                        users[userIndex].SellCar();
                        Console.WriteLine("\nНажмите Enter для продолжения...");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.Clear();
                        ShowAllUsers(users);
                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        break;

                    case 5:
                        Console.Clear();
                        ShowSalon(cars, motos);
                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        break;

                    case 0:
                        Console.Clear();
                        Console.WriteLine("До свидания! Спасибо за посещение автосалона Топ!");
                        break;
                }
            } while (choice != 0);
        }
    }
}