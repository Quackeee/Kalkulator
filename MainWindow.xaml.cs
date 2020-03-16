using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void autoClearDisplay()
        {
            if (display_tb.Text == "err div0" || display_tb.Text == "err other")
            {
                clearDisplay();
            }
        }

        public MainWindow()
        {
            this.KeyDown += MainWindow_KeyDown;
            fillPrecedenceDictionary();
            InitializeComponent();
        }

        private void numericInput(object sender, RoutedEventArgs e)
        {
            autoClearDisplay();
            writeToDisplay(((Button)sender).Content.ToString().Trim());
        }

        private void operatorInput(object sender, RoutedEventArgs e)
        {
            autoClearDisplay();

            String symbol = ((Button)sender).Content.ToString();
            if (displayEmpty())
            {
                if (symbol=="-")
                {
                    writeToDisplay(symbol);
                }
            }
            else if (isOperator(lastEntry()))
            {
                if (display_tb.Text.Length!=1)
                {
                    removeLastEntry();
                    writeToDisplay(symbol);
                }
                
            }
            else
            {
                writeToDisplay(symbol);
            }

        }

        private void plusMinus(object sender, RoutedEventArgs e)
        {
            autoClearDisplay();

            if (displayEmpty() || display_tb.Text[0] != '-')
            {
                display_tb.Text = '-' + display_tb.Text;  
            }
            else
            {
                display_tb.Text = display_tb.Text.Remove(0, 1);
            }

        }

        private void clearButton(object sender, RoutedEventArgs e)
        {
            if (sender == C_btn)
            {
                clearDisplay();
            }
            else
            {
                removeLastEntry();
            }
        }

        private void point(object sender, RoutedEventArgs e)
        {
            autoClearDisplay();

            if (!displayEmpty())
            {
                if (!isOperator(lastEntry()) && !(lastEntry() == '.'))
                {
                    bool ok = true;
                    for (int i = lastEntryIndex(); i >= 0; i--)
                    {
                        if (isOperator(display_tb.Text[i])) break; 
                        if (display_tb.Text[i] == '.') { ok = false; break; }
                    }
                    if (ok)
                        writeToDisplay('.');
                }
            }
        }

        private void calculate(object sender, RoutedEventArgs e)
        {
            autoClearDisplay();
            if (!displayEmpty())
            {
                evaluateFromDisplay();
            }
            else
            {
                writeToDisplay("0");
            }
        }
    }
}