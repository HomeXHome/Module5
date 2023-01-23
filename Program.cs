using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Module5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double ageTemp = 0;
            int PetCount = 0;
            bool isPetExistsTemp = false;
            string[] favFlowersTemp = new string[0];
            string[] emptyPetTempArray = new string[0];

            (string FirstName, string LastName, double Age, bool IsPetExists, int PetCount, string[] PetNames, string[] FavFlowers)UserData;

            //Вводим / проверяем корректные имена.

            string[] userNames = CheckingCorrectUserName();
            UserData.FirstName = userNames[0];
            UserData.LastName = userNames[1];
            //Вводим/проверяем возраст

            UserData.Age = CheckingCorrectAge(ref ageTemp);

            //Существуют ли питомцы, их количество и клички

            UserData.IsPetExists = CheckingIfPetExist(ref isPetExistsTemp);
            if (UserData.IsPetExists == true)
            {
                UserData.PetCount = PetCounting(ref PetCount);
                UserData.PetNames = PetNamesHandler(UserData.IsPetExists, UserData.PetCount);
            }
            else
            {
                UserData.PetNames = emptyPetTempArray;
            }

            //Спрашиваем о количестве и навзвании любимый цветов.
            UserData.FavFlowers = FavFlowerHandler(ref favFlowersTemp);

            //Выводим дату о пользователе в консоль
            UserDataShower();

            Console.ReadLine();

        // Метод для вывода данных пользователя в консоль
            void UserDataShower()
            {
                Console.WriteLine("Имя и фамилия пользователя : " + UserData.FirstName+ " " + UserData.LastName);

                Console.WriteLine("Возраст пользователя : " + UserData.Age);

                if (UserData.IsPetExists)
                {
                    Console.WriteLine("Имена домашних животных пользователя : ");
                    for (int i = 0; i < UserData.PetNames.Length; i++)
                    {
                        Console.Write(UserData.PetNames[i] + " ");
                    }
                }
                else
                {
                    Console.WriteLine("У пользователя нет домашних животных.\n");
                }
                Console.WriteLine($"Количество любимых цветов пользователя : {UserData.FavFlowers.Length}\n");
                Console.Write("Любимые цветы пользователя : ");
                for (int i = 0; i < UserData.FavFlowers.Length; i++)
                {
                    Console.Write(UserData.FavFlowers[i] + " ");
                }

            }
        }

        public static string[] FavFlowerHandler(ref string[] favFlowers)
        {
            Console.WriteLine("Введите количество ваших любимых цветов : ");
            bool isCorrect = Int32.TryParse(Console.ReadLine(), out int favFlowerCount);
            if (!isCorrect || favFlowerCount == 0)
            {
                Console.WriteLine("Вы ввели некорректные данные, попробуйте снова. Для полноты данных требуется как минимум один цветок. ");
                FavFlowerHandler(ref favFlowers);
            }
            else
            {
                string[] favFlowerArray = new string[favFlowerCount];
                for (int i = 0; i < favFlowerCount; i++)
                {
                    Console.WriteLine($"Введите ваш {i + 1} любимый цветок");
                    favFlowerArray[i] = Console.ReadLine();
                }
                favFlowers = favFlowerArray;
            }
            return favFlowers;
        }
        //Создаем массив строк, первой строкой является имя юзера, вторая строка - фамилия
        public static string[] CheckingCorrectUserName()
        {
            string[] username = new string[2];
            string firstName;
            string lastName;
            bool isUserNameCorrect = false;
            do
            {
                Console.WriteLine("Введите ваше имя : ");
                firstName = Console.ReadLine();
                Console.WriteLine("Введите вашу фамилию : ");
                lastName = Console.ReadLine();

                if (firstName.Length > 1 && lastName.Length > 1)
                {
                    username[0] = firstName;
                    username[1] = lastName;
                    isUserNameCorrect = true;
                }
                else
                    Console.WriteLine("Вашe имя или фамилия слишком короткие, введите данные заново");
            }
            while(isUserNameCorrect == false);
            return username;
        }

        //Проверяем инпут юзера на правильный ввод возраста и перезапускаем метод, если ввод не в формате double;
        public static double CheckingCorrectAge(ref double ageTemp)
        {
            Console.WriteLine("Введите ваш возраст : ");
            bool isCorrect = double.TryParse(Console.ReadLine(), out double age);
            if (isCorrect != true || age == 0)
            {
                Console.WriteLine("Вы ввели некорректный возраст, попробуйте снова");
                CheckingCorrectAge(ref ageTemp);
            }
            else
            {
            ageTemp = age;
            }
            return ageTemp;
        }

        //Проверяем, есть ли животное у пользователя, на основе его ответа Да/Нет.
        public static bool CheckingIfPetExist(ref bool isPetExist)
        {
            Console.WriteLine("Есть ли у вас домашнее животное? Да/Нет");
            string userAnswer = Console.ReadLine().ToLower();
            if (userAnswer != "да" && userAnswer != "нет")
            {
                Console.WriteLine("Вы ввели некорретный ответ, попробуйте снова.");
                CheckingIfPetExist(ref isPetExist);
            }
            else
            {
                switch (userAnswer)
                {
                    case "да":
                        isPetExist = true;
                        break;
                    case "нет":
                        isPetExist = false;
                        break;
                }
            }
            return isPetExist;
        }

        //Узнаем количество количество домашних животных
        public static int PetCounting(ref int petCount)
        {
            Console.WriteLine("Введите количество ваших животных : ");
            bool isCountInt = Int32.TryParse(Console.ReadLine(), out int petCountTemp);
            if (isCountInt != true || petCountTemp == 0)
            {
                Console.WriteLine("Вы ввели некорректное количество, попробуйте снова");
                PetCounting(ref petCount);
            }
            else
            {
                petCount = petCountTemp;
            }
            return petCount;
        }

        //Заполняем массив именами животных
        public static string[] PetNamesHandler(bool isPetExists, int PetCount = 1)
        {
            string[] petNamesMethod = new string[PetCount];
            if (isPetExists)
            {
                
                for (int i = 0; i < PetCount; i++)
                {
                    Console.WriteLine($"Укажите имя вашего {i+1} питомца");
                    petNamesMethod[i] = Console.ReadLine();
                }
                return petNamesMethod;
            }
            else
                throw new Exception("Pet does not exist, however this method was triggered.");
        }


    }
}
