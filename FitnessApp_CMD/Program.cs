using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp_CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceMenager = new ResourceManager("FitnessApp_CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceMenager.GetString("Hello", culture));
            
            Console.Write(resourceMenager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceMenager.GetString("EnterGender"));
                var gender = Console.ReadLine();

                var birthDate = ParseDateTime("дату рождения (dd.MM.yyyy):");
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("ESC - выход");

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        {
                            var foods = EnterEating();

                            eatingController.Add(foods.Food, foods.Weight);

                            foreach (var item in eatingController.Eating.Foods)
                            {
                                Console.WriteLine($"\t{item.Key} - {item.Value}");
                            }

                            break;
                        }

                    case ConsoleKey.A:
                        {
                            var exercise = EnterExercise();

                            exerciseController.Add(exercise.Activity,
                                                   exercise.Begin,
                                                   exercise.End);

                            foreach (var item in exerciseController.Exercises)
                            {
                                Console.WriteLine($"{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                            }

                            break;
                        }

                    case ConsoleKey.Escape:
                        {
                            Environment.Exit(0);

                            break;
                        }

                    case ConsoleKey.F6:
                        {
                            culture = CultureInfo.CreateSpecificCulture("en-us");

                            Console.WriteLine(resourceMenager.GetString("Hello", culture));
                            break;
                        }

                    case ConsoleKey.F7:
                        {
                            culture = CultureInfo.CreateSpecificCulture("ru-ru");

                            Console.WriteLine(resourceMenager.GetString("Hello", culture));
                            break;
                        }
                }

                Console.ReadKey();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход енергии в минуту");
            var begin = ParseDateTime("начало упражнения (dd.MM.yyyy hh:mm): ");
            var end = ParseDateTime("окончание упражнения (dd.MM.yyyy hh:mm): ");

            var activity = new Activity(name, energy);

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта:");
            var food = Console.ReadLine();

            var calories = ParseDouble("Калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("Вес порции");

            var product = new Food(food, calories, proteins, fats, carbs);

            return (product, weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime date;

            while (true)
            {
                Console.Write($"Введите {value}");

                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }

            return date;
        }

        private static double ParseDouble(string name) 
        {
            while (true)
            {
                Console.Write($"Введите {name}:");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }

    }
}
