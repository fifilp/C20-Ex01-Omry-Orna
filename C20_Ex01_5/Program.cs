using System;
using System.Collections.Generic;
using System.Text;

namespace C20_Ex01_5
{
     public class Program
     {
          private const uint k_ValidNumLen = 8;

          public static void Main()
          {
               analizeInput();
          }

          private static void analizeInput()
          {
               string inputNumAsString = getValidInput();
               queriesOnDigits(inputNumAsString);
          }

          private static string getValidInput()
          {
               Console.WriteLine("Please enter an 8 digit positive number: ");

               bool isValid = false;
               string inputNumberAsString = string.Empty;

               while (!isValid)
               {
                    inputNumberAsString = Console.ReadLine();
                    isValid = (inputNumberAsString.Length == k_ValidNumLen)
                        && C20_Ex01_4.Program.IsAllDigits(inputNumberAsString);
                    if (!isValid)
                    {
                         Console.WriteLine("invalid input");
                    }
               }

               return inputNumberAsString;
          }

          private static void queriesOnDigits(string i_str)
          {
               int maxDigit = (int)char.GetNumericValue(i_str[0]);
               int minDigit = (int)char.GetNumericValue(i_str[0]);
               int divisableBy4count = 0;
               int greaterThanLSDcount = 0;

               for (int i = 0; i < i_str.Length; i++)
               {
                    int currentDigit = (int)char.GetNumericValue(i_str[i]);

                    findMaxDigit(currentDigit, ref maxDigit);
                    findMinDigit(currentDigit, ref minDigit);
                    countDivisableBy4(currentDigit, ref divisableBy4count);
                    countGreaterThanLSD(currentDigit, i_str[i_str.Length - 1], ref greaterThanLSDcount);
               }

               printQueriesOutput(maxDigit, minDigit, divisableBy4count, greaterThanLSDcount);
          }

          private static void findMaxDigit(int i_digit, ref int io_maxDigit)
          {
               if (i_digit > io_maxDigit)
               {
                    io_maxDigit = i_digit;
               }
          }

          private static void findMinDigit(int i_digit, ref int io_minDigit)
          {
               if (i_digit < io_minDigit)
               {
                    io_minDigit = i_digit;
               }
          }

          private static void countDivisableBy4(int i_digit, ref int io_divisableBy4count)
          {
               if (i_digit % 4 == 0)
               {
                    io_divisableBy4count++;
               }
          }

          private static void countGreaterThanLSD(int i_digit, char i_LSD, ref int io_greaterThanLSDcount)
          {
               if (i_digit > (int)char.GetNumericValue(i_LSD))
               {
                    io_greaterThanLSDcount++;
               }
          }

          private static void printQueriesOutput(
               int i_maxDigit, int i_minDigit, int i_divisableBy4count,  int i_greaterThanLSDcount)
          {
               Console.WriteLine(
                   @"the largest digit is {0}
the smallest digit is {1}
{2} digits are divisible by 4
{3} digits are greater than the least significant digit",
               i_maxDigit,
               i_minDigit,
               i_divisableBy4count,
               i_greaterThanLSDcount);
          }
     }
}
