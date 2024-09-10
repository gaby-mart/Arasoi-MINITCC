using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arasoi.Tournament
{
    internal class CardTournament
    {
        public Canvas canvas = null;
        private TournamentView tournamentView = new TournamentView();

        public CardTournament() { }

        public Canvas CreateCard(string name, string cod)
        {
            canvas = new Canvas
            {
                Background = new SolidColorBrush(Colors.AliceBlue),
                Height = 90,
                Width = 1280
            };

            Label label = new Label
            {
                Content = name
            };
            Canvas.SetLeft(label, 48);
            Canvas.SetTop(label, 32);

            Button button = new Button
            {
                Content = "Deletar"
            };
            button.Click += new RoutedEventHandler(Delete);
            Canvas.SetLeft(button, 1);
            Canvas.SetTop(button, 1);

            canvas.Children.Add(label);
            canvas.Children.Add(button);

            return canvas;
        }
        
        public void Delete(object sender, RoutedEventArgs e)
        {
            if (canvas != null && canvas.Parent is StackPanel parentStackPanel)
            {
                parentStackPanel.Children.Remove(canvas);
            }

            tournamentView.LoadView();
        }
    }
}
