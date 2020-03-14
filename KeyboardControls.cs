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
    public partial class MainWindow
    {
        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D1 || e.Key == Key.NumPad1)
            {
                btn1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                btn2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.D3 || e.Key == Key.NumPad3)
            {
                btn3.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.D4 || e.Key == Key.NumPad4)
            {
                btn4.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.D5 || e.Key == Key.NumPad5)
            {
                btn5.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.D6 || e.Key == Key.NumPad6)
            {
                btn6.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.D7 || e.Key == Key.NumPad7)
            {
                btn7.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.D8 || e.Key == Key.NumPad8)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift))
                    multiply_btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                else
                    btn8.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                btn9.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.D0 || e.Key == Key.NumPad0)
            {
                btn0.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.OemComma || e.Key == Key.OemPeriod || e.Key == Key.Decimal)
            {
                point_btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.OemMinus || e.Key == Key.Subtract)
            {
                minus_btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.OemPlus || e.Key == Key.Add)
            {
                plus_btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.Back)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift))
                    C_btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                else
                    CE_btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            }
            else if (e.Key == Key.Divide || e.Key == Key.OemBackslash || e.Key == Key.OemQuestion || e.Key == Key.Oem5)
            {
                divide_btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else if (e.Key == Key.Multiply)
            {
                multiply_btn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            Console.WriteLine(e.Key.ToString());
        }

    }
}