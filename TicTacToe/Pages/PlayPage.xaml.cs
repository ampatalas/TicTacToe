using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace TicTacToe.Pages
{
    public partial class PlayPage : PhoneApplicationPage
    {
        String symbol;
        Color color;

        public PlayPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.NavigationContext.QueryString.ContainsKey("color") && this.NavigationContext.QueryString.ContainsKey("symbol"))
            {
                symbol = this.NavigationContext.QueryString["symbol"];
                String colorString = this.NavigationContext.QueryString["color"];
                color = getColorFromString(colorString);
                SymbolAndColorMessage.Text = "You are playing as " + symbol + " and your color is " + colorString + ".";
            }
        }

        private Color getColorFromString(string color)
        {
            if (color.Equals("red")) return System.Windows.Media.Colors.Red;
            else return System.Windows.Media.Colors.White;
        }

        private void TicTacToeTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Canvas canvasSender = sender as Canvas;
            String name = canvasSender.Name;
        }
    }
}