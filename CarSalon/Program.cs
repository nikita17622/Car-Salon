using System;
using System.Collections.Generic;
using CarSalon;


namespace Auto
{

    internal class Program
    {
            static void Main(string[] args)
            {
                List<Person> users = new List<Person>();
                List<Car> cars = new List<Car>();
                List<Moto> motos = new List<Moto>();

            // Инициализация автосалона
             Services.InitializeSalon(cars, motos);

                int choice;
                do
                {
                Services.ShowMenu();

                    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > 5)
                    {
                        Console.Write("Некорректный ввод! Выберите 0-5: ");
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            users.Add(Services.AddPerson());
                            Console.WriteLine("\nНажмите Enter для продолжения...");
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            if (users.Count == 0)
                            {
                                Console.WriteLine(" Сначала добавьте пользователя!");
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
                                Console.WriteLine(" Сначала добавьте пользователя!");
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
                            Services.ShowAllUsers(users);
                            Console.WriteLine("Нажмите Enter для продолжения...");
                            Console.ReadLine();
                            break;

                        case 5:
                            Console.Clear();
                            Services.ShowSalon(cars, motos);
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
    
