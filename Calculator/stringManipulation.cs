using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calculator
{
    public class StringManipulation
    {
        public static string CalculateString(string completeString)
        {
            if (completeString != null)
            {
                MathHelper mathHelper = new MathHelper();

                int numberOfOperationSigns = GetNumberOfOperationSignsInString(completeString);

                for (int i = 0; i <= numberOfOperationSigns; i++)
                {
                    completeString = mathHelper.CalculateEquation(completeString);
                }
            }
            return completeString;
        }

        private static int GetNumberOfOperationSignsInString(string completeString)
        {
            int count = completeString.Length - completeString.Replace("+", "").Length;
            count += completeString.Length - completeString.Replace("-", "").Length;
            count += completeString.Length - completeString.Replace("/", "").Length;
            count += completeString.Length - completeString.Replace("x", "").Length;

            return count;
        }

        private static void ReplaceEquationWithResult(string equation, string result, ref string completeString)
        {
            completeString = completeString.Replace(equation, result);
        }

    }
}
