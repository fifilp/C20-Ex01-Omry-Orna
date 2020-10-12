using System;

namespace C20_Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            getInputFromUserAndPrint();
        }

        private static void getInputFromUserAndPrint()
        {
            Console.WriteLine("Please enter the number of lines for the sand machine:");
            int clockHeight;
            bool isNumeric = int.TryParse(Console.ReadLine(), out clockHeight);
            while (!isNumeric)
            {
                Console.WriteLine("Invalid input, please insert a number");
                isNumeric = int.TryParse(Console.ReadLine(), out clockHeight);
            }

            C20_Ex01_2.Program.PrintHourGlass(clockHeight);
        }
    }
}
