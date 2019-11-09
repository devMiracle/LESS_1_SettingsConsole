using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    /*Настроить окно консоли.
    Заголовок  - своё имя и группа
    Цвет выводимого текста - красный
    Размер консоли в два раза меньше от текущего
    Вывести текст "Привет, мои милые лягушатки!" по центру консоли.

    После всего сбросить цвета в состояние по-умолчанию.

    Как только пользователь нажимает Enter по ЦЕНТРУ консоли появляется меню на 3 пункта.
    1. Заполнить список случайными значениями
    2. Вывести Массив
    3. отсортировать

    Переключение между пунктами меню осуществляем стрелочками. 
    НЕльзя выйти за границы меню.
    Активный пункт меню отображает цветом, отличающимся от всех остальных пунктов.
    При нажатии на пункте меню Enter - выполняется пункт меню.
    При нажатии Esc - выход из приложения.
     */
    class Program
    {
        static int[] numbers = new int[10];//список
        static bool atLeastOneTimeKeyNumberRandomizer = false;//переменная отвечает за то, была ли использованна функция NumberRandomizer() хотя бы раз.
        static bool isSorted = false;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Console.Title = "ППС 31-18";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetWindowSize(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
            string text = "Привет, мои милые лягушатки!";
            Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, Console.WindowHeight / 2);
            Console.Write(text);

            Console.ResetColor();
            ConsoleKeyInfo button;
            do
            {
                button = Console.ReadKey(true);
            } while (button.Key != ConsoleKey.Enter);



            string[] menu = { "Заполнить список случайными значениями", "Вывести Массив", "Отсортировать" };
            int maxLengthString = 0;


            foreach (var item in menu)
            {
                if (item.Length > maxLengthString)
                    maxLengthString = item.Length;
            }
            ConsoleKeyInfo buttonPress;
            int target = 1;
            int XСoordinate = Console.WindowWidth / 2 - maxLengthString / 2;
            int YСoordinate = Console.WindowHeight / 2 - menu.Length / 2;
            bool isInTheCycle = false;
            Console.Clear();
            bool hideArray = false;
            do
            {
                for (int i = 0; i < menu.Length; i++)
                {
                    if (target - 1 == i)
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.SetCursorPosition(XСoordinate, YСoordinate + i);
                    Console.Write(menu[i]);

                    if (hideArray == false)
                    {
                        Console.SetCursorPosition(35, 7);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Спрятано");
                        Console.SetCursorPosition(35, 7);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Видно");
                    }
                    else
                    {
                        Console.SetCursorPosition(35, 7);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("Видно");
                        Console.SetCursorPosition(35, 7);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Спрятано");
                    }


                    Console.ResetColor();

                }
                buttonPress = Console.ReadKey(true);
                switch (buttonPress.Key)
                {
                    case ConsoleKey.Enter:
                        if (target == 1)
                        {
                            NumberRandomizer();
                            Print(hideArray);
                        }
                        if (target == 2)
                        {
                            if (hideArray == false)
                                hideArray = true;
                            else if (hideArray == true)
                                hideArray = false;
                            if (hideArray == true)
                                Print(true);
                            else if (hideArray == false && atLeastOneTimeKeyNumberRandomizer == true)
                                Print(false);
                        }
                        if (target == 3)
                        {
                            if (atLeastOneTimeKeyNumberRandomizer)
                            {
                                if (!isSorted)
                                {
                                    Array.Sort(numbers);
                                    isSorted = true;
                                }
                                else
                                    Console.Beep(12000, 100);
                                Print(hideArray);
                            }
                        }
                        break;

                    case ConsoleKey.Escape:
                        isInTheCycle = true;
                        break;

                    case ConsoleKey.UpArrow:
                        if (target == 1)
                            target = menu.Length + 1;
                        target--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (target == menu.Length)
                            target = 1 - 1;
                        target++;
                        break;

                    default:
                        break;
                }
            } while (!isInTheCycle);
        }
        //Рандомизатор нашего массива.
        public static void NumberRandomizer()
        {
            atLeastOneTimeKeyNumberRandomizer = true;
            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = random.Next(0, 10);
            isSorted = false;
        }
        public static void Print(bool hide)
        {
            if (hide)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.SetCursorPosition(2, 2 + i);
                    Console.Write(numbers[i]);
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.SetCursorPosition(2, 2 + i);
                    Console.Write(numbers[i]);
                }
                Console.ResetColor();
            }
        }

    }
}
