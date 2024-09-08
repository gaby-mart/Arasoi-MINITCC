using Arasoi.DatabaseManagement;
using MySql.Data.MySqlClient;
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
                MessageBox.Show("!");
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
    }
}
