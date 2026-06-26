using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalon
{
    internal class Services
    {
            public static void InitializeSalon(List<Car> cars, List<Moto> motos)
            {
                cars.Clear();
                motos.Clear();

                var carData = new (string name, decimal cost, int yearCreation, int speed, string fuelType)[]
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

                for (int i = 0; i < carData.Length; i++)
                {
                    Car newCar = new Car(carData[i].name, carData[i].cost, carData[i].yearCreation,
                                        carData[i].speed, carData[i].fuelType);
                    newCar.Number = i + 1;
                    cars.Add(newCar);
                }

                var motoData = new (string name, decimal cost, int yearCreation, int speed, string fuelType,
                                    int quantitySeat, int quantityHorses)[]
                {
                ("Yamaha R1", 18000m, 2023, 299, "Бензин", 2, 200),
                ("Harley Davidson", 25000m, 2022, 180, "Бензин", 2, 150),
                ("Suzuki GSX-R", 16000m, 2023, 280, "Бензин", 2, 190),
                ("Kawasaki Ninja", 17000m, 2022, 290, "Бензин", 2, 210)
                };

                for (int i = 0; i < motoData.Length; i++)
                {
                    Moto newMoto = new Moto(motoData[i].name, motoData[i].cost, motoData[i].yearCreation,
                                           motoData[i].speed, motoData[i].fuelType,
                                           motoData[i].quantitySeat, motoData[i].quantityHorses);
                    newMoto.Number = i + 1;
                    motos.Add(newMoto);
                }
            }

            public static void ShowSalon(List<Car> cars, List<Moto> motos)
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

            public static Person AddPerson()
            {
                int age;
                string name;
                decimal balance;

                Console.WriteLine("\n=== ЗАПОЛНИТЕ ДАННЫЕ О СЕБЕ ===");
                Console.Write("Имя: ");
                name = Console.ReadLine();

                Console.Write("Возраст: ");
                while (!int.TryParse(Console.ReadLine(), out age) || age < 18)
                {
                    Console.Write("Некорректный возраст! Возраст должен быть 18+. Попробуйте снова: ");
                }

                Console.Write("Ваш баланс: ");
                while (!decimal.TryParse(Console.ReadLine(), out balance) || balance < 0)
                {
                    Console.Write("Некорректный баланс! Введите положительное число: ");
                }

                Person newPerson = new Person(age, name, balance, null);
                Console.WriteLine("\n✅ Пользователь успешно создан!");
                newPerson.ShowPersonData();
                return newPerson;
            }

            public static void ShowAllUsers(List<Person> users)
            {
                if (users.Count == 0)
                {
                    Console.WriteLine("\n❌ Список пользователей пуст!");
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

            public static void ShowMenu()
            {
                Console.Clear();
                Console.WriteLine(" ");
                Console.WriteLine("      АВТОСАЛОН ТОП - МЕНЮ           ");
                Console.WriteLine(" ");
                Console.WriteLine("  1. Добавить нового пользователя    ");
                Console.WriteLine("  2. Купить транспорт                ");
                Console.WriteLine("  3. Вернуть транспорт               ");
                Console.WriteLine("  4. Показать всех пользователей     ");
                Console.WriteLine("  5. Показать автосалон              ");
                Console.WriteLine("  0. Выход                           ");

                Console.Write("\nВаш выбор: ");
            }
        }
    }


