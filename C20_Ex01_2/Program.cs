using System;
using System.Collections.Generic;
using System.Text;

namespace C20_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            PrintHourGlass(5);
        }

        public static void PrintHourGlass(int i_clockHeight)
        {
            if (i_clockHeight % 2 == 0)
            {
                printHourGlassRec(i_clockHeight + 1);
            }
            else
            {
                printHourGlassRec(i_clockHeight);
            }
        }

        private static void printRow(int i_numberOfAstrix, int i_numOfSpaces)
        {
            for (int i = 0; i < i_numOfSpaces; i++)
            {
                Console.Write(' ');
            }

            for (int i = 0; i < i_numberOfAstrix; i++)
            {
                Console.Write('*');
            }

            Console.WriteLine();
        }

        private static void printHourGlassRec(int i_clockHeight, int i_numOfSpaces = 0)
        {
            printRow(i_clockHeight, i_numOfSpaces);
            if (i_clockHeight == 1 || i_clockHeight == 0)
            {
                return;
            }

            printHourGlassRec(i_clockHeight - 2, i_numOfSpaces + 1);
            printRow(i_clockHeight, i_numOfSpaces);
        }
    }
}
