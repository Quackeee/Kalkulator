using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    public partial class MainWindow
    {

        [Serializable]
        public class DivisionByZeroException : Exception
        {
            public DivisionByZeroException() { }
            public DivisionByZeroException(string message) : base(message) { }
            public DivisionByZeroException(string message, Exception inner) : base(message, inner) { }
            protected DivisionByZeroException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        bool displayEmpty => display_tb.Text.Length == 0;
        char lastEntry => display_tb.Text[display_tb.Text.Length - 1];
        int lastEntryIndex => (display_tb.Text.Length - 1);

        bool isOperator(char c)
        {
            if (c == '-' || c == '÷' || c == '×' || c == '+') return true;
            else return false;
        }

        void clearDisplay()
        {
            display_tb.Text = "";
        }

        void removeLastEntry()
        {
            if (!displayEmpty)
            display_tb.Text = display_tb.Text.Remove(display_tb.Text.Length - 1, 1);
        }

        void writeToDisplay(string c)
        {
            display_tb.Text += c;
        }

        void writeToDisplay(char c)
        {
            display_tb.Text += c;
        }

        double stringToDouble(string s)
        {
            double result;

            if (CultureInfo.CurrentCulture.Name == "pl-PL")
            {
                result = Convert.ToDouble(s.Replace(".", ","));
            }
            else
                result = Convert.ToDouble(s);
            return result;
        }

        double evaluate(double o1, double o2, string operation)
        {
            if (operation == "-") return o1 - o2;
            if (operation == "+") return o1 + o2;
            if (operation == "÷" && o2 == 0) throw new DivisionByZeroException();
            if (operation == "÷") return o1 / o2;
            if (operation == "×") return o1 * o2;
            throw new Exception("Niezdefiniowany operator");
        }
    }
}
