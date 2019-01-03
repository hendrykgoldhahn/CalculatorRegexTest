using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _calculatorDisplayText;
        public string CalculatorDisplayText
        {
            get { return _calculatorDisplayText; }
            set
            {
                _calculatorDisplayText = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetDisplayText(string buttonContent)
        {
            CalculatorDisplayText += buttonContent;
        }

        public void ClearDisplayText()
        {
            CalculatorDisplayText = "";
        }

        public void DeleteLastChar()
        {
            if (CalculatorDisplayText != "")
            {
                CalculatorDisplayText = CalculatorDisplayText.Substring(0, CalculatorDisplayText.Length - 1);
            }
        }

        public void SetLabelColor()
        {

        }

        public void CalculateResult()
        {
            CalculatorDisplayText = StringManipulation.CalculateString(CalculatorDisplayText);
        }
    }
}
