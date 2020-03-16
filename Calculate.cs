using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    partial class MainWindow
    {

        Dictionary<string, int> precedence = new Dictionary<string, int>();

        void fillPrecedenceDictionary() {
            precedence.Add("+", 1);
            precedence.Add("-", 1);
            precedence.Add("÷", 2);
            precedence.Add("×", 2);
        }

        string generateRawOutput(string s)
        {
            string raw = "";
            foreach (char c in s)
            {
                if (isOperator(c))
                {
                    raw += " " + c + " ";
                }
                else raw += c;
            }
            return raw;
        }


        string toPostfix(string s)
        {

        Stack<string> stack = new Stack<string>();
        string wyjscie = "";

        string[] rownanie = s.Split();

        foreach (string c in rownanie)
        {
            try
            {
                stringToDouble(c);
                wyjscie += c + " ";
            }
            catch
            {
                while (stack.Count != 0 && precedence[c] <= precedence[stack.Peek()])
                {
                    wyjscie += stack.Pop() + " ";
                }
                stack.Push(c);

                Console.WriteLine(wyjscie);
            }
        }
        while (stack.Count != 0)
        {
            wyjscie += stack.Pop() + " ";
        }
            Console.WriteLine(wyjscie);
            return wyjscie;
        }

        double calculatePostfixExpression(string s)
        {
            string[] znaki = s.Trim().Split();
            Stack<double> stack = new Stack<double>();

            foreach (string c in znaki)
            {
                try
                {
                    double num = stringToDouble(c);
                    stack.Push(num);
                }
                catch
                {
                    double o1 = stack.Pop();
                    double o2 = stack.Pop();
                    stack.Push(evaluate(o2, o1, c));
                }
            }
            return (stack.Pop());
            
        }

        void evaluateFromDisplay()
        {
            if (isOperator(lastEntry()) || lastEntry()=='.')
            {
                removeLastEntry();
            }

            previousCalculation_tb.Text = display_tb.Text;

            if (display_tb.Text[0] == '-')
                display_tb.Text = '0' + display_tb.Text;

            try
            {
                display_tb.Text = calculatePostfixExpression(toPostfix(generateRawOutput(display_tb.Text))).ToString();
            } catch (DivisionByZeroException)
            {
                display_tb.Text = "err div0";
            } catch
            {
                display_tb.Text = "err other";
            }
        }
    }
}
