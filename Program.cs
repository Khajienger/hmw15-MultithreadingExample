using System;
using System.Threading;

namespace MultitaskExample
{
    internal class Program
    {
        private static void WriteShortText(object Text)
        {
            Console.WriteLine($"\nПоток #{Thread.CurrentThread.ManagedThreadId} ShortText начал работу...\n");

            for(int i = 0; i < 45; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write($"{Text} ");
                Thread.Sleep(333);
            }

            Console.WriteLine($"\nПоток #{Thread.CurrentThread.ManagedThreadId} ShortText закончил работу...\n");
        }

        private static void WriteLongText(object Text)
        {
            Console.WriteLine($"\nПоток #{Thread.CurrentThread.ManagedThreadId} LongText начал работу...\n");

            for (int i = 0; i < 15; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine($"\n{Text}");
                Thread.Sleep(1000);
            }

            Console.WriteLine($"\nПоток #{Thread.CurrentThread.ManagedThreadId} LongText закончил работу...\n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите короткий текст для первого потока, например '*'\n");
            string shortText = Console.ReadLine();

            Console.WriteLine("\nВведите длиный текста для второго потока, например 'Row with text'\n");
            string longText = Console.ReadLine();

            ParameterizedThreadStart ptsTHRshorttext = new ParameterizedThreadStart(WriteShortText); 
            ParameterizedThreadStart ptsTHRlongtext = new ParameterizedThreadStart(WriteLongText);

            Thread thrShortText = new Thread(ptsTHRshorttext);
            Thread thrLongText = new Thread(ptsTHRlongtext);

            thrShortText.Start(shortText);
            thrLongText.Start(longText);

            Console.ReadKey();
            Console.Clear();
        }
    }
}