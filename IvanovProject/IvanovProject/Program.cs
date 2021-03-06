﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IvanovProject
{
    /// <summary>
    /// Author: Захаров Алексей
    /// Задача: Найти дистанцию Левинштейна для двух строк
    /// - Предоставить график зависимости длины Левинштейна от суммарной длины строки (То есть по Оси Х: суммарная длина строк по оси Y: результирующая метрика)
    /// - Предоставить график зависимости вдемени работы программы от суммарной длины строки
    /// </summary>
    class LevenshteinDistance
    {
        static Random rand = new Random();

        /// <summary>
        /// Display 2D array
        /// </summary>
        /// <param name="array"> array to display </param>
        static void displayArray(int[,] array)
        {
            for (int y = 0; y < array.GetLength(0); ++y)
            {
                for (int x = 0; x < array.GetLength(1); ++x)
                    Console.Write(array[y, x] + " ");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Calculate Levenshtein Distance for two inpur strings
        /// </summary>
        /// <param name="collString"> first string </param>
        /// <param name="rowString"> second string </param>
        /// <param name="executionTime"> reference on varible witch store execution time </param>
        /// <param name="insert"> weight of insert operation </param>
        /// <param name="substitute"> weight of substitute operation </param>
        /// <param name="remove"> weight of remove operation </param>
        /// <returns> Levenshtein Distance </returns>
        static long LevenshteinDistanceSolver(string collString, string rowString, ref long executionTime,
            int insert = 1, int substitute = 1, int remove = 1)
        {
            // long startTime = DateTime.Now.Millisecond;

            // Timer start
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (collString == null)
                throw new ArgumentNullException(collString);
            if (rowString == null)
                throw new ArgumentNullException(rowString);

            int[,] matrix = new int[rowString.Length + 1, collString.Length + 1];

            int curentSub = 0;

            // Fill first row
            for (int x = 0; x < matrix.GetLength(1); ++x)
                matrix[0, x] = x;

            // Fill firs column
            for (int y = 0; y < matrix.GetLength(0); ++y)
                matrix[y, 0] = y;

            for (int y = 1; y < rowString.Length + 1; ++y)
            {
                for (int x = 1; x < collString.Length + 1; ++x)
                {
                    // Check if strings are equal current substitute equal to zero, substitute value otherwise
                    curentSub = (collString[x - 1] == rowString[y - 1]) ? 0 : substitute;

                    // Set current element to minimum possible value
                    matrix[y, x] = Math.Min(
                        Math.Min(matrix[y - 1, x] + remove, matrix[y, x - 1] + insert),
                        matrix[y - 1, x - 1] + curentSub);
                }
            }

            //executionTime = DateTime.Now.Millisecond - startTime;
            // Get execution time
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;

            return matrix[rowString.Length, collString.Length];
        }

        #region Random String Solver

        /// <summary>
        /// Generate random string with a predetermined length
        /// </summary>
        /// <param name="length"> length of generating string </param>
        /// <returns> generated string</returns>
        static string generateRandomString(int length)
        {
            if (length == 0)
                throw new InvalidDataException();

            char currentSymbol = ' ';
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < length; ++i)
            {
                // 65 - 'A' code, 122 - 'z' code in ASCII (http://www.math.rsu.ru/dictionary/a/ASCII.htm)
                currentSymbol = Convert.ToChar(rand.Next(65, 122));
                resultString.Append(currentSymbol);
            }

            return resultString.ToString();
        }

        /// <summary>
        /// Add randomly generated string to already existing
        /// </summary>
        /// <param name="initialString"> refernce on initial string </param>
        /// <param name="length"> length of randomly generated string </param>
        static void addRandomString(ref string initialString, int length)
        {
            string additionString = generateRandomString(length);
            initialString += additionString;
        }

        /// <summary>
        /// Find Lwvinstain distanse for rndomly generated strings
        /// </summary>
        static void randomStringSolver()
        {
            // Length of inital string
            int initialLength = 100;    //500
            // Length of additionally generated strings
            int additionalLength = 10;  // 300

            // Weight of isert, remove, substitute operation respectively
            int insertCost = 1;
            int removeCost = 1;
            int substituteCost = 2;

            string fileNameLength = @"Data\distanceIns" +
                insertCost.ToString() + "Rem" +
                removeCost.ToString() + "Sub" +
                substituteCost.ToString() + ".txt";

            StreamWriter distanceStreamWriter = new StreamWriter(fileNameLength);

            string fileNameTime = @"Data\timeIns" +
                insertCost.ToString() + "Rem" +
                removeCost.ToString() + "Sub" +
                substituteCost.ToString() + ".txt";

            StreamWriter timeStreamWriter = new StreamWriter(fileNameTime);

            try
            {
                string first = generateRandomString(initialLength);
                string second = generateRandomString(initialLength);
                long resultDistance = 0;

                long executionTime = 0;

                for (int i = 0; i < 50; ++i)
                {
                    addRandomString(ref first, rand.Next(1, additionalLength));
                    addRandomString(ref second, rand.Next(1, additionalLength));

                    resultDistance = LevenshteinDistanceSolver(first, second, ref executionTime, insertCost, substituteCost, removeCost);
                    Console.WriteLine("Distance: {0}, string sum len: {1}, Time {2}", resultDistance, first.Length + second.Length, executionTime);

                    distanceStreamWriter.WriteLine("{0} {1}", first.Length + second.Length, resultDistance);
                    timeStreamWriter.WriteLine("{0} {1}", first.Length + second.Length, executionTime);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (InvalidDataException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                distanceStreamWriter.Close();
                timeStreamWriter.Close();
            }
        }

        #endregion

        #region Text Solver

        public static string[] getText(string path)
        {
            string text = File.ReadAllText(path);
            StringBuilder tempText = new StringBuilder();

            foreach (char curSymb in text)
            {
                if (!char.IsPunctuation(curSymb) && curSymb != '\n')
                    tempText.Append(curSymb);
            }
            text = tempText.ToString();

            return text.Split(' ');
        }

        public static string getTextString(string[] textGlossary, int wordCount)
        {
            string str = "";
            for (int curWordCount = 0; curWordCount < wordCount; ++curWordCount)
            {
                str += textGlossary[rand.Next(0, textGlossary.Length)] + ' ';
            }
            return str;

        }

        public static void textSolver(int insertCost = 10, int removeCost = 8, int substituteCost = 5)
        {
            string[] textGlossary = getText(@"Data\Text\text.txt");

            StreamWriter sw = new StreamWriter(@"Data\Text\Result\Length.txt");
            StreamWriter sw1 = new StreamWriter(@"Data\Text\Result\Time.txt");

            int i = 0;

            for (int wordCount = 30; wordCount < 100; /*wordCount++*/)
            {
                string row = getTextString(textGlossary, wordCount);
                
                string coll = getTextString(textGlossary, wordCount);

                long executionTime = 0;
                long distance = 0;

                distance = LevenshteinDistanceSolver(coll, row, ref executionTime, insertCost, substituteCost, removeCost);

                sw.WriteLine("{0} {1}", /*row.Length + coll.Length*/ i, distance);
                sw1.WriteLine("{0} {1}", /*row.Length + coll.Length*/ i, executionTime);

                Console.WriteLine("Levinstaine dist = {0}", distance);
                Console.WriteLine("Execution time = {0}", executionTime);
                ++i;
                if (i > 100)
                    break;
            }
            sw.Close();
            sw1.Close();
        }

        #endregion

        static void Main(string[] args)
        {
            //randomStringSolver();
            textSolver();
        }
    }
}
