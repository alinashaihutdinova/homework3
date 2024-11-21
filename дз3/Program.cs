using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дз3
{
    enum DayOfWeek 
    {
        Понедельник = 1,
        Вторник,
        Среда,
        Четверг,
        Пятница,
        Суббота,
        Воскресенье
    }
    internal class Program
    {
        static void FirstTask()
        {
            Console.WriteLine("задание 1");
            
            /* Дана последовательность из 10 чисел. Определить, является ли эта последовательность
            упорядоченной по возрастанию. В случае отрицательного ответа определить
            порядковый номер первого числа, которое нарушает данную последовательность.
            Использовать break*/

            int[] numbers = new int[10];
            bool isOrdered = true;
            int wrongIndex = -1;
            Console.WriteLine("Введите 10 чисел:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Число {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[i - 1] || numbers[i] == numbers[i - 1])
                {
                    isOrdered = false;
                    wrongIndex = i;
                    break; 
                }
            }
            if (isOrdered)
            {
                Console.WriteLine("Последовательность упорядочена по возрастанию.");
            }
            else
            {
                Console.WriteLine($"Последовательность не упорядочена. Первое нарушение на позиции {wrongIndex + 1} (число {numbers[wrongIndex]}).");
            }
        }
        static void SecondTask()
        {
            Console.WriteLine("задание 2");
            
            /*Игральным картам условно присвоены следующие порядковые номера в зависимости от
            их достоинства: «валету» — 11, «даме» — 12, «королю» — 13, «тузу» — 14.
            Порядковые номера остальных карт соответствуют их названиям («шестерка»,
            «девятка» и т. п.). По заданному номеру карты k (6 <=k <= 14) определить достоинство
            соответствующей карты. Использовать try-catch-finally*/
            
            try
            {
                Console.Write("Введите порядковый номер карты от 6 до 14: ");
                byte c = byte.Parse(Console.ReadLine());
                string number;
                switch (c)
                {
                    case 6: number = "Шестёрка"; break;
                    case 7: number = "Семёрка"; break;
                    case 8: number = "Восьмёрка"; break;
                    case 9: number = "Девятка"; break;
                    case 10: number = "Десятка"; break;
                    case 11: number = "Валет"; break;
                    case 12: number = "Дама"; break;
                    case 13: number = "Король"; break;
                    case 14: number = "Туз"; break;
                    default: number = "Неизвестная карта"; break;
                }
                Console.WriteLine($"Достоинство карты: {number}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введите корректное целое число.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Спасибо за использование программы");
            }
        }
        static void ThirdTask()
        {
            Console.WriteLine("Задание 3");

            /* Напишите программу, которая принимает на входе строку и производит выходные
            данные в соответствии с таблицей*/

            Console.WriteLine("введите что-нибудь из предложенного: Jabroni/School Counselor/Programmer/Bike gang member/Politician/Rapper");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "jabroni": Console.WriteLine("Patron Tequila"); break;
                case "school counselor": Console.WriteLine("Anything with alco"); break;
                case "programmer": Console.WriteLine("hipster craft beer"); break;
                case "bike gang member": Console.WriteLine("moonshine"); break;
                case "politician": Console.WriteLine("your tax dollars"); break;
                case "rapper": Console.WriteLine("blue cristal"); break;
                default: Console.WriteLine("beer"); break;
            }
        }
        
        static void FourthTask()
        {
            Console.WriteLine("Задание 4");
            
            /*Составить программу, которая в зависимости от порядкового номера дня недели (1, 2,
            ...,7) выводит на экран его название (понедельник, вторник, ..., воскресенье).
            Использовать enum.*/
            
            Console.WriteLine("Введите порядковый номер дня недели от 1 до 7: ");
            try
            {
                byte dayNumber = byte.Parse(Console.ReadLine());
                if (dayNumber < 1 || dayNumber > 7)
                {
                    throw new ArgumentOutOfRangeException("Номер дня должен быть в диапазоне от 1 до 7");
                }
                DayOfWeek day = (DayOfWeek)dayNumber;
                Console.WriteLine($"День недели: {day}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введено недопустимое значение. Пожалуйста, введите целое число");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Спасибо за использование программы");
            }
        }
        static void FifthTask()
        {
            Console.WriteLine("Задание 5");
            
            /*Создать массив строк.При помощи foreach обойти весь массив.При встрече элемента
            "Hello Kitty" или "Barbie doll" необходимо положить их в “сумку”, т.е.прибавить к
            результату.Вывести на экран сколько кукол в “сумке”*/

            string[] dolls = { "Hello Kitty", "Winx doll", "Barbie doll", "Mermaid doll", "Bratz doll", "Monster High doll",  "Barbie doll", "Hello Kitty" };
            List<string> bag = new List<string>();
            foreach (string doll in dolls)
            {
                if (doll == "Hello Kitty" || doll == "Barbie doll")
                {
                    bag.Add(doll);
                }
            }
            Console.WriteLine($"Количество кукол в <сумке>: {bag.Count}");
        }
        static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
            ThirdTask();    
            FourthTask(); 
            FifthTask();
        }
    }
}
