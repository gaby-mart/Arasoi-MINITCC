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
    internal class CardTournament
    {
        public Canvas Card;
        private StackPanel ParentStackPanel;
        private string Id;
        public CardTournament() { }

        public Canvas CreateCard(string name, string id, StackPanel parentStackPanel)
        {
            ParentStackPanel = parentStackPanel;
            Id = id;

            Canvas card = new Canvas
            {
                Background = new SolidColorBrush(Colors.Red),
                Height = 100
            };

            Button button = new Button
            {
                Content = "Deletar"
            };
            button.Click += Delete; 

            Canvas.SetLeft(button, 125); 
            Canvas.SetTop(button, 10);

            Label label = new Label
            {
                Content = name
            };

            Canvas.SetLeft(label, 49);
            Canvas.SetTop(label, 37);

            card.Children.Add(button);
            card.Children.Add(label);
            return card;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = ConnectionFactory.GetConnection();
            string command = "DELETE FROM campeonato WHERE cod_campeonato = @cod_campeonato";
            MySqlCommand commandDELETE = new MySqlCommand(command, connection);
            commandDELETE.Parameters.AddWithValue("@cod_campeonato", Id);
            commandDELETE.ExecuteNonQuery();

            TournamentView tournamentView = new TournamentView();
        }
    }
}
