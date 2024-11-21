using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace заданияТумакова
{
    internal class Program
    {
        static string GetMonthName(byte month)
        {
            switch (month)
            {
                case 1: return "января";
                case 2: return "февраля";
                case 3: return "марта";
                case 4: return "апреля";
                case 5: return "мая";
                case 6: return "июня";
                case 7: return "июля";
                case 8: return "августа";
                case 9: return "сентября";
                case 10: return "октября";
                case 11: return "ноября";
                case 12: return "декабря";
                default: return "";
            }
        }
        static void FirstTask()
        {
            /* Написать программу, которая читает с экрана число от 1 до 365 (номер дня
             в году), переводит это число в месяц и день месяца. Например, число 40 соответствует 9
             февраля (високосный год не учитывать)*/

            Console.WriteLine("Упражнение 4.1");

            Console.WriteLine("Введите номер дня в году от 1 до 365: ");
            uint dayOfYear = uint.Parse(Console.ReadLine());
            byte[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            byte month = 0;
            uint day = 0;
            for (byte i = 0; i < daysInMonth.Length; i++)
            {
                if (dayOfYear <= daysInMonth[i])
                {
                    month = (byte)(i + 1); 
                    day = dayOfYear; 
                    break;
                }
                dayOfYear -= daysInMonth[i]; 
            }
            Console.WriteLine($"Дата: {day} {GetMonthName(month)}");
        }

        static void SecondTask()
        {
            /*Упражнение 4.2 Добавить к задаче из предыдущего упражнения проверку числа введенного
            пользователем.Если число меньше 1 или больше 365, программа должна вырабатывать
            исключение, и выдавать на экран сообщение.*/
            
            Console.WriteLine("Упражнение 4.2");
            
            try
            {
                Console.WriteLine("Введите номер дня в году от 1 до 365: ");
                uint dayOfYear = uint.Parse(Console.ReadLine());
                if (dayOfYear < 1 || dayOfYear > 365)
                {
                    throw new ArgumentOutOfRangeException("Число должно быть в диапазоне от 1 до 365.");
                }
                byte[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                byte month = 0;
                uint day = 0;
                for (byte i = 0; i < daysInMonth.Length; i++)
                {
                    if (dayOfYear <= daysInMonth[i])
                    {
                        month = (byte)(i + 1); 
                        day = dayOfYear;
                        break;
                    }
                    dayOfYear -= daysInMonth[i];
                }
                Console.WriteLine($"Дата: {day} {GetMonthName(month)}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введено некорректное число. Пожалуйста, введите целое число.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Спасибо за использование программы");
            }
        }

        static void ThirdTask()
        {
            /*Изменить программу из упражнений 4.1 и 4.2 так, чтобы она
            учитывала год (високосный или нет). Год вводится с экрана. (Год високосный, если он
            делится на четыре без остатка, но если он делится на 100 без остатка, это не високосный
            год. Однако, если он делится без остатка на 400, это високосный год.)*/

            Console.WriteLine("Домашнее задание 4.1");
            
            try
            {
                Console.WriteLine("Введите номер дня в году от 1 до 366: ");
                uint dayOfYear = uint.Parse(Console.ReadLine());
                Console.WriteLine("Введите год: ");
                uint year = uint.Parse(Console.ReadLine());
                bool isLeapYear = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
                int maxDays = isLeapYear ? 366 : 365;
                if (dayOfYear < 1 || dayOfYear > maxDays)
                {
                    Console.WriteLine($"Число должно быть в диапазоне от 1 до {maxDays}.");
                    return;
                }
                byte[] daysInMonth = isLeapYear
                ? new byte[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }
                : new byte[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                byte month = 0;
                uint day = 0;
                for (byte i = 0; i < daysInMonth.Length; i++)
                {
                    if (dayOfYear <= daysInMonth[i])
                    {
                        month = (byte)(i + 1); 
                        day = dayOfYear; 
                        break;
                    }
                    dayOfYear -= daysInMonth[i];
                }
                Console.WriteLine($"Дата: {day} {GetMonthName(month)} {year} года");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введено некорректное число. Пожалуйста, введите целое число.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Спасибо за использование программы");
            }
        }

        static void Main(string[] args)
            {
                FirstTask();
                SecondTask();
                ThirdTask();
            }
        
    }
}
