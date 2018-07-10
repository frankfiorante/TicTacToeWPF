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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToeClass
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TicTacToe game;
        private Button[] buttons;
        private int[] winCount;

        public MainWindow()
        {
            InitializeComponent();
            winCount = new int[] { 0, 0 }; //winCount[0] = player 1 and winCount[1] = player 2
            game = new TicTacToe();
            buttons = new Button[]
            {
                Btn0, Btn1, Btn2,
                Btn3, Btn4, Btn5,
                Btn6, Btn7, Btn8
            };


            LblTurn.Content = "Turn: Player " + game.GetCurrentPlayer;
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            ButtonTest(0);
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            ButtonTest(1);
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            ButtonTest(2);
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            ButtonTest(3);
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            ButtonTest(4);
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            ButtonTest(5);
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            ButtonTest(6);
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            ButtonTest(7);
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            ButtonTest(8);
        }

        private void BtnClearBoard_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].ClearValue(BackgroundProperty);
                buttons[i].IsEnabled = true;
                buttons[i].Content = ' ';
                game = new TicTacToe();
                LblTurn.Content = "Turn: Player " + game.GetCurrentPlayer;
            }
        }

        private void ButtonTest (int ButtonNumber)
        {
            Button butt = buttons[ButtonNumber];
            butt.Content = game.GetCurrentPlayer;
            game.PlaceMove(ButtonNumber, game.GetCurrentPlayer);
            butt.IsEnabled = false;

            if (game.Win()) //did anyone win?
            {
                foreach (int button in game.GetWinTrip)
                {
                    buttons[button].Background = Brushes.LightGreen;
                    buttons[button].IsEnabled = true;
                }
                if (game.GetCurrentPlayer.ToString() == "X")
                {
                    winCount[0]++;
                    LblPlayerOne.Content = "Player 1 (X) Wins: " + winCount[0];
                }
                else
                {
                    winCount[1]++;
                    LblPlayerTwo.Content = "Player 2 (O) Wins: " + winCount[1];
                }
                MessageBox.Show(game.GetCurrentPlayer.ToString() + " You Won");
                BtnClearBoard_Click(null, null);
            }
            else if (game.Tie()) //did anyone tie?
            {
                foreach (Button button in buttons)
                {
                    button.Background = Brushes.LightSalmon;
                    button.IsEnabled = true;
                }
                MessageBox.Show("Tie");
                BtnClearBoard_Click(null, null);
            }
            else
            {
                game.ChangePlayer(); //change player
                LblTurn.Content = "Turn: Player " + game.GetCurrentPlayer;
            }
        }

    }
}
