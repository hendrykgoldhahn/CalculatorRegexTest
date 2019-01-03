using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    class MathHelper
    {
        public string CalculateEquation(string equation)
        {
            char computeSign = 'x';
            string result = "";

            if (CheckForDoubleCalculationSigns(equation))
            {
                equation = CleanDoubleCalculatrionSigns(equation);
            }

            Match matchResult = MatchWithRegex(equation, ref computeSign);

            if (matchResult.Value.Contains(computeSign))
            {
                result = CalculateWithComputeSign(matchResult.Value, computeSign);
            }

            return matchResult.Value == "" ? equation : equation.Replace(matchResult.Value, result);
        }


        private string CalculateWithComputeSign(string matchResult, char computeSign)
        {
            string result = "";
            string computeString = matchResult;
            if (matchResult.Contains("("))
            {
                computeString = matchResult.Replace("(", "");
                computeString = computeString.Replace(")", "");
            }
            string[] matchSplit = computeString.Split(computeSign);
            switch (computeSign)
            {
                case '+':
                    result = Addition(matchSplit[0], matchSplit[1]);
                    break;
                case '-':
                    result = Subtraction(matchSplit[0], matchSplit[1]);
                    break;
                case '/':
                    result = Division(matchSplit[0], matchSplit[1]);
                    break;
                case 'x':
                    result = Multiplication(matchSplit[0], matchSplit[1]);
                    break;
            }
            return result;
        }

        private Match MatchWithRegex(string equation, ref char computeSign)
        {
            Match matchResult = Regex.Match(equation, "([(][0-9]+[,0-9]*[x][0-9]+[,0-9]*[)])");

            if (matchResult.Value == "")
            {
                matchResult = Regex.Match(equation, "([(][0-9]+[,0-9]*[/][0-9]+[,0-9]*[)])");
                computeSign = '/';
            }
            if (matchResult.Value == "")
            {
                matchResult = Regex.Match(equation, "([(][0-9]+[,0-9]*[\\+][0-9]+[,0-9]*[)])");
                computeSign = '+';
            }
            if (matchResult.Value == "")
            {
                matchResult = Regex.Match(equation, "([(][0-9]+[,0-9]*[-][0-9]+[,0-9]*[)])");
                computeSign = '-';
            }


            if (matchResult.Value == "")
            {
                matchResult = Regex.Match(equation, "([0-9]+[,0-9]*[x][0-9]+[,0-9]*)");
                computeSign = 'x';
            }
            if (matchResult.Value == "")
            {
                matchResult = Regex.Match(equation, "([0-9]+[,0-9]*[/][0-9]+[,0-9]*)");
                computeSign = '/';
            }
            if (matchResult.Value == "")
            {
                matchResult = Regex.Match(equation, "([0-9]+[,0-9]*[\\+][0-9]+[,0-9]*)");
                computeSign = '+';
            }
            if (matchResult.Value == "")
            {
                matchResult = Regex.Match(equation, "([0-9]+[,0-9]*[-][0-9]+[,0-9]*)");
                computeSign = '-';
            }

            return matchResult;
        }



        private bool CheckForDoubleCalculationSigns(string completeString)
        {
            return completeString.Contains("+-") || completeString.Contains("-+") || completeString.Contains("--");
        }

        private string CleanDoubleCalculatrionSigns(string completeString)
        {
            if (completeString.Contains("+-"))
            {
                completeString = completeString.Replace("+-", "-");
            }
            if (completeString.Contains("-+"))
            {
                completeString = completeString.Replace("-+", "-");
            }
            if (completeString.Contains("--"))
            {
                completeString = completeString.Replace("--", "-");
            }

            return completeString;
        }

        private string Addition(string factor1, string factor2)
        {
            double.TryParse(factor1, out double summand1);
            double.TryParse(factor2, out double summand2);
            double sum = summand1 + summand2;

            return DoubleHasOnlyDecimalPlaces(sum) ? sum.ToString() : sum.ToString("0.00");
        }

        private string Subtraction(string factor1, string factor2)
        {
            double.TryParse(factor1, out double minuend);
            double.TryParse(factor2, out double subtrahend);
            double difference = minuend - subtrahend;

            return DoubleHasOnlyDecimalPlaces(difference) ? difference.ToString() : difference.ToString("0.00");
        }

        private string Division(string factor1, string factor2)
        {
            double.TryParse(factor1, out double dividend);
            double.TryParse(factor2, out double divisor);
            double quotient_value = dividend / divisor;

            return DoubleHasOnlyDecimalPlaces(quotient_value) ? quotient_value.ToString() : quotient_value.ToString("0.00");
        }

        private string Multiplication(string factor1, string factor2)
        {
            double.TryParse(factor1, out double multiplier);
            double.TryParse(factor2, out double multiplicand);
            double product = multiplier * multiplicand;

            return DoubleHasOnlyDecimalPlaces(product) ? product.ToString() : product.ToString("0.00");
        }

        private bool DoubleHasOnlyDecimalPlaces(double number)
        {
            return number % 1 == 0;
        }

    }
}
