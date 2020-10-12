using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace C20_Ex01_4
{
     public class Program
     {
          private const uint k_ValidStrLen = 12;

          public static void Main()
          {
               analizeString();
          }

          private static void analizeString()
          {
               Console.WriteLine("Please enter a 12 char string:");
               string inputString = Console.ReadLine();

               eInputType inType = getInputTypeString(inputString);
               switch (inType)
               {
                    case eInputType.Invalid:
                         {
                              Console.WriteLine("invalid input");
                              break;
                         }

                    case eInputType.Letters:
                         {
                              analizeLetterString(inputString);
                              break;
                         }

                    case eInputType.Digits:
                         {
                              analizeDigitsString(inputString);
                              break;
                         }
               }
          }

          private static void analizeLetterString(string i_letterString)
          {
               Console.WriteLine("string is palindrome? {0}", isPalindrome(i_letterString));
               int lowerCaseCount = numOfLowerCaseLetters(i_letterString);
               Console.WriteLine("number of lowercase letters: {0}", lowerCaseCount);
          }

          private static void analizeDigitsString(string i_digitsString)
          {
               Console.WriteLine("number is palindrome? {0}", isPalindrome(i_digitsString));
               Console.WriteLine("number is divisible by 3? {0}", divisibleBy3(i_digitsString));
          }

          private static bool isPalindrome(string i_str)
          {
               bool isPali = true;
               int strLength = i_str.Length;
               if (strLength > 1)
               {
                    isPali = (i_str[0] == i_str[strLength - 1])
                        && isPalindrome(i_str.Substring(1, strLength - 2));
               }

               return isPali;
          }

          private static eInputType getInputTypeString(string i_str)
          {
               eInputType result = eInputType.Invalid;

               if (i_str.Length != k_ValidStrLen)
               {
                    result = eInputType.Invalid;
               }
               else if (isAllEnglishLetters(i_str))
               {
                    result = eInputType.Letters;
               }
               else if (IsAllDigits(i_str))
               {
                    result = eInputType.Digits;
               }

               return result;
          }

          // aux method used in IsAllEnglishLetters method. (char.IsLetter Method checks for Unicode letters, this method is specific for English)  
          private static bool isEnglishLetter(char i_char)
          {
               bool isEnglishLetterChecker = (i_char >= 'a' && i_char <= 'z') ||
                   (i_char >= 'A' && i_char <= 'Z');
               return isEnglishLetterChecker;
          }

          private static bool isAllEnglishLetters(string i_str)
          {
               bool isAllEnglishLettersChecker = true;

               for (int i = 0; i < i_str.Length; i++)
               {
                    if (!isEnglishLetter(i_str[i]))
                    {
                         isAllEnglishLettersChecker = false;
                         break;
                    }
               }

               return isAllEnglishLettersChecker;
          }

          public static bool IsAllDigits(string i_str)
          {
               bool IsDigit = true;
               for (int i = 0; i < i_str.Length; i++)
               {
                    if (!char.IsDigit(i_str[i]))
                    {
                         IsDigit = false;
                         break;
                    }
               }

               return IsDigit;
          }

          private static int numOfLowerCaseLetters(string i_str)
          {
               int lowerCaseCount = 0;

               for (int i = 0; i < i_str.Length; i++)
               {
                    // we can use char.IsLower method, which generally 
                    // checks for unicode, because we already know the whole string is English letters
                    if (char.IsLower(i_str, i))
                    {
                         lowerCaseCount++;
                    }
               }

               return lowerCaseCount;
          }

          private static bool divisibleBy3(string i_str)
          {
               int sumOfDigs = sumOfDigits(i_str);
               bool isDivisibleBy3 = sumOfDigs % 3 == 0;
               return isDivisibleBy3;
          }

          private static int sumOfDigits(string i_str)
          {
               int sumOfDigs = 0;

               for (int i = 0; i < i_str.Length; i++)
               {
                    sumOfDigs += (int)char.GetNumericValue(i_str[i]);
               }

               return sumOfDigs;
          }
     }
}
