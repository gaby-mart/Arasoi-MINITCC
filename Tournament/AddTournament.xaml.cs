using Arasoi.DatabaseManagement;
using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Arasoi.Tournament
{
    public partial class AddTournament : Window
    {
        public AddTournament()
        {
            InitializeComponent();
        }

        // close the window
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if(CheckInfo())
            {
                MySqlConnection connection = ConnectionFactory.GetConnection();
                string stringCommand = "INSERT INTO campeonato (cod_campeonato, nome_campeonato, filiacao, data_inicio, data_fim) " +
                    "VALUES (@cod_campeonato, @nome_campeonato, @filiacao, @data_inicio, @data_fim)";
                MySqlCommand commandINSERT = new MySqlCommand(stringCommand, connection);
                
                commandINSERT.Parameters.AddWithValue("@cod_campeonato", CodeTB.Text);
                commandINSERT.Parameters.AddWithValue("@nome_campeonato", TournamentNameTB.Text);
                commandINSERT.Parameters.AddWithValue("@filiacao", FiliationTB.Text);
                commandINSERT.Parameters.AddWithValue("@data_inicio", DataPickerStart.SelectedDate.Value.ToString("yyyy-MM-dd"));
                commandINSERT.Parameters.AddWithValue("@data_fim", DataPickerEnd.SelectedDate.Value.ToString("yyyy-MM-dd"));

                commandINSERT.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Registrado!");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Faltam informações!");
            }
        }

        // check if something is missing
        private bool CheckInfo()
        {
            // Variablename'TB' means TextBox
            // Incomplete code
            // If something is false, return false. Returning false means that the function should NOT be executed.
            return CodeTB.Text.Trim() != ""
                && TournamentNameTB.Text.Trim() != "" 
                && FiliationTB.Text.Trim() != "" 
                && DataPickerStart.SelectedDate.HasValue 
                && DataPickerEnd.SelectedDate.HasValue;
        }
    }
}
