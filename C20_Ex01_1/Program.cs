using System;
using System.Collections.Generic;
using System.Text;

namespace C20_Ex01_1
{
     public class Program
     {
          private const uint k_ValidStrLen = 8;

          public static void Main()
          {
               analizeStringInput();
          }

          private static void analizeStringInput()
          {
               string binaryNumberInput;
               int powerOf2counter = 0, numberOfZeros = 0, sumOfValues = 0, AscendingSeriesCounter = 0;
               StringBuilder decimalNumbersString = new StringBuilder();
               System.Console.WriteLine("Please enter 4 binary number with 8 digits each:");
               for (int i = 0; i < 4; i++)
               {
                    binaryNumberInput = getValidInput();
                    int decimalNumber = binaryStringToDecimal(ref binaryNumberInput);
                    decimalNumbersString.Append(decimalNumber).Append(" ");
                    numberOfZeros += getNumberOfZeros(binaryNumberInput);
                    countPowerOf2(binaryNumberInput, ref powerOf2counter);
                    countAscending(decimalNumber, ref AscendingSeriesCounter);
                    sumOfValues += decimalNumber;
               }

               printAnalysisOutput(decimalNumbersString, numberOfZeros, powerOf2counter, AscendingSeriesCounter, sumOfValues);
          }

          private static void printAnalysisOutput(
               StringBuilder i_decimalNumbersString,
               int i_numberOfZeros,
               int i_powerOf2counter,
               int i_AscendingSeriesCounter,
               int i_sumOfValues)
          {
               printDecimalNumbers(i_decimalNumbersString);
               printNumberOfOnesAndZeros(i_numberOfZeros);
               printNumberOfPowerOf2(i_powerOf2counter);
               printNumberOfAscendingSeries(i_AscendingSeriesCounter);
               printGeneralAverage(i_sumOfValues);
          }

          private static void printGeneralAverage(int i_sumOfValues)
          {
               string msg = string.Format(
                    "The general average of the inserted numbers is:{0}",
                   (float)i_sumOfValues / 4);
               Console.WriteLine(msg);
          }

          private static void printNumberOfAscendingSeries(int i_AscendingSeriesCounter)
          {
               string msg = string.Format(
                   "There are {0} numbers which are ascending series ",
                   i_AscendingSeriesCounter);
               Console.WriteLine(msg);
          }

          private static void printNumberOfPowerOf2(int i_powerOf2counter)
          {
               string msg = string.Format("There are {0} numbers which are power of 2", i_powerOf2counter);
               Console.WriteLine(msg);
          }

          private static void printNumberOfOnesAndZeros(int i_numberOfZeros)
          {
               string msg = string.Format(
                    "In average, there are {0} number of zeros and {1} number of ones in each binary number",
                    ((float)i_numberOfZeros) / 4,
                    (float)(32 - i_numberOfZeros) / 4);
               Console.WriteLine(msg);
          }

          private static void countPowerOf2(string i_binaryNumber, ref int io_powerOf2Counter)
          {
               if (getNumberOfZeros(i_binaryNumber) == 7)
               {
                    io_powerOf2Counter++;
               }
          }

          private static void countAscending(int i_decimalNumber, ref int io_AscendingSeriesCounter)
          {
               bool isAscending = true;
               if (i_decimalNumber > 9)
               {
                    while (i_decimalNumber > 0)
                    {
                         // if the 2 least significant digits aren't ascending
                         if (i_decimalNumber % 10 <= (i_decimalNumber / 10) % 10)
                         {
                              isAscending = false;
                         }

                         i_decimalNumber /= 10;
                    }
               }

               if (isAscending)
               {
                    io_AscendingSeriesCounter++;
               }
          }

          private static int getNumberOfZeros(string i_binaryNumberString)
          {
               int zeroCounter = 0;
               for (int i = 0; i < i_binaryNumberString.Length; i++)
               {
                    if (i_binaryNumberString[i] == '0')
                    {
                         zeroCounter++;
                    }
               }

               return zeroCounter;
          }

          public static void printDecimalNumbers(StringBuilder i_decimalNumbersString)
          {
               string msg = string.Format("The decimal numbers are: {0}", i_decimalNumbersString);
               Console.WriteLine(msg);
          }

          public static int binaryStringToDecimal(ref string io_binaryNumber)
          {
               int decimalNumber = 0;

               for (int i = 0; i < io_binaryNumber.Length; i++)
               {
                    decimalNumber = (decimalNumber * 2) + (int)char.GetNumericValue(io_binaryNumber[i]);
               }

               return decimalNumber;
          }

          public static string getValidInput()
          {
               while (true)
               {
                    string binaryNumberInput = System.Console.ReadLine();

                    if (!isValidInput(binaryNumberInput))
                    {
                         Console.WriteLine("invalid input");
                         continue;
                    }
                    else
                    {
                         return binaryNumberInput;
                    }
               }
          }

          private static bool isValidInput(string i_binaryNumber)
          {
               bool isValidInputChecker = true;
               if (i_binaryNumber.Length != k_ValidStrLen)
               {
                    isValidInputChecker = false;
               }

               for (int i = 0; i < i_binaryNumber.Length; i++)
               {
                    if (i_binaryNumber[i] != '0' && i_binaryNumber[i] != '1')
                    {
                         isValidInputChecker = false;
                         break;
                    }
               }

               return isValidInputChecker;
          }
     }
}
