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
using System.Windows.Shapes;
using System.Windows.Data;

namespace TicTacToe.Pages
{
    public partial class PlayPage : PhoneApplicationPage
    {
        String userSymbol;
        Color color;
        Game game;
        Brush brush;

        String Msg_Win = "Congratulations! You won!";
        String Msg_Lost = "You lost!";
        String Msg_Draw = "It's a draw!";

        public PlayPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (this.NavigationContext.QueryString.ContainsKey("color") && this.NavigationContext.QueryString.ContainsKey("UserSymbol"))
            {
                userSymbol = this.NavigationContext.QueryString["UserSymbol"];
                String colorString = this.NavigationContext.QueryString["color"];
                color = getColorFromString(colorString);
                SymbolAndColorMessage.Text = "You are playing as " + userSymbol + " and your color is " + colorString + ".";
                game = new Game(userSymbol);
                brush = new SolidColorBrush(color);
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
            char[] data = canvasSender.Name.ToCharArray();
            int row = getIntFromChar(data[0]);
            int column = getIntFromChar(data[1]);
            if (!game.addElement(row, column, userSymbol))
            {
                MessageBox.Show("This position is already taken.");
            }
            else
            {
                drawSymbol(canvasSender, userSymbol);
            }

        }

        private void drawSymbol(Canvas sender, string userSymbol)
        {
            if (userSymbol.Equals("O"))
            {
                Ellipse el = new Ellipse();

                el.Width = 100;
                el.Height = 100;
                el.Stroke = brush;
                el.StrokeThickness = 5;
                sender.Children.Add(el);
            }
            else
            {
                Path path = new Path();
                var b = new Binding
                {
                    Source = "M0,0 L30,50 L0,100 L30,100 L50,70 L70,100 L100,100 L70,50 L100,0 L70,0 L50,30 L30,0 C0,0 0,0 0,0"
                };
                BindingOperations.SetBinding(path, Path.DataProperty, b);
                path.Stroke = brush;
                sender.Children.Add(path);
            }
        }

        private int getIntFromChar(char p)
        {
            if (p == 'Z') return 0;
            if (p == 'O') return 1;
            if (p == 'T') return 2;
            else throw new Exception("Unexpected character.");
        }


    }
}