using Arasoi.DatabaseManagement;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arasoi.Tournament
{
    internal class TournamentView
    {
        public Canvas ActualCanvas { set; get; }
        public TournamentView() 
        {
            MySqlConnection connection = ConnectionFactory.GetConnection();
            string stringCommand = "SELECT * FROM campeonato";
            MySqlCommand commandSELECT = new MySqlCommand(stringCommand, connection);
            MySqlDataReader reader = commandSELECT.ExecuteReader();

            if (reader.HasRows)
            {
                ActualCanvas = CreateAndAddView();
            }
            else 
            {
                ActualCanvas = CreateAndAddEmptyView();
            }

            connection.Close();
        }

        public Canvas CreateAndAddEmptyView()
        {
            Canvas canvas = new Canvas();
            canvas.Margin = new Thickness(0, 119, 0, 0);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Crie um campeonato";
            textBlock.FontSize = 16;
            textBlock.Foreground = Brushes.Black;
            Canvas.SetLeft(textBlock, 585);
            Canvas.SetTop(textBlock, 282);
            textBlock.HorizontalAlignment = HorizontalAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Top;

            canvas.Children.Add(textBlock);

            return canvas;
        }

        public Canvas CreateAndAddView()
        {
            MySqlConnection connection = ConnectionFactory.GetConnection();
            string stringCommand = "SELECT * FROM campeonato";
            MySqlCommand commandSELECT = new MySqlCommand(stringCommand, connection);
            MySqlDataReader reader = commandSELECT.ExecuteReader();

            Canvas canvas = new Canvas();

            StackPanel stackPanel = new StackPanel
            {
                Height = 505,
                Width = 1920,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };

            while (reader.Read())
            {
                Canvas card = new Canvas
                {
                    Background = new SolidColorBrush(Colors.Red),
                    Height = 100
                };

                Label label = new Label
                {
                    Content = reader["nome_campeonato"].ToString()
                };

                Canvas.SetLeft(label, 49);
                Canvas.SetTop(label, 37);

                card.Children.Add(label);
                stackPanel.Children.Add(card);
            }
            
            canvas.Children.Add(stackPanel);
            return canvas;
        }
    }
}
