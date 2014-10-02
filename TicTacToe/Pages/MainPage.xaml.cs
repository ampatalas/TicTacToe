using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TicTacToe.Resources;

namespace TicTacToe
{
    public partial class MainPage : PhoneApplicationPage
    {

        String color;
        String symbol;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            color = null;
            symbol = null;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            String uriAddress = "/Pages/PlayPage.xaml";
            if (color == null || symbol == null)
            {
                MessageBox.Show("You didn't pick color or UserSymbol!");
            }
            else
            {
                uriAddress += "?color=" + color + "&UserSymbol=" + symbol;
                NavigationService.Navigate(new Uri(uriAddress, UriKind.Relative));
            }
        }

        private void RedColor_Checked(object sender, RoutedEventArgs e)
        {
            color = "red";
        }

        private void WhiteColor_Checked(object sender, RoutedEventArgs e)
        {
            color = "white";
        }

        private void NoughtSymbol_Checked(object sender, RoutedEventArgs e)
        {
            symbol = "O";
        }

        private void CrossSymbol_Checked(object sender, RoutedEventArgs e)
        {
            symbol = "X";
        }
    }
}