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
        public CardTournament() { }

        public Canvas CreateCard(string name, StackPanel parentStackPanel)
        {
            ParentStackPanel = parentStackPanel;

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
            if (ParentStackPanel != null)
            {
                if (sender is Button button && button.Parent is Canvas buttonParentCanvas)
                {
                    ParentStackPanel.Children.Remove(buttonParentCanvas);
                }
            }
        }
    }
}
