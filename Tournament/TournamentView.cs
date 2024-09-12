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
            LoadView();
        }

        public void LoadView()
        {
            if (ActualCanvas != null) ActualCanvas.Children.Clear();

            using (MySqlConnection connection = ConnectionFactory.GetConnection())
            {
                try
                {
                    string stringCommand = "SELECT * FROM campeonato";
                    MySqlCommand commandSELECT = new MySqlCommand(stringCommand, connection);

                    using (MySqlDataReader reader = commandSELECT.ExecuteReader())
                    {
                        ActualCanvas = reader.HasRows ? CreateAndAddView(reader) : CreateAndAddEmptyView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar os dados: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            MessageBox.Show("Bora bill!!");
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

        public Canvas CreateAndAddView(MySqlDataReader reader)
        {
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
                CardTournament cardTournament = new CardTournament();
                Canvas card = cardTournament.CreateCard(reader["nome_campeonato"].ToString(), reader["cod_campeonato"].ToString(), stackPanel);
                stackPanel.Children.Add(card);
            }
            
            canvas.Children.Add(stackPanel);
            return canvas;
        }
    }
}
