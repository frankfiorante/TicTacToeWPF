using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClass
{
    class TicTacToe
    {
        private Player currentPlayer;
        private char[] board;
        private int[][] triple;
        private int[] winningTriple;

        public TicTacToe()
        {
            //Set the current Player
            currentPlayer = Player.X;

            //Set the board
            board = new char[9]; //board has 9 spots

            //Declare winning triple values
            triple = new int[8][] {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 },
        };

            //Initialize winning triple
            winningTriple = new int[1];

            //Clear board at start of game
            ClearBoard();
        }

        public enum Player
        {
            X,
            O
        }

        public Player GetCurrentPlayer
        {
            get { return currentPlayer; }
        }

        public int[] GetWinTrip
        {
            get { return winningTriple; }
        }

        public void ChangePlayer()
        {
            if (currentPlayer == Player.X)
            {
                currentPlayer = Player.O;
            }
            else
            {
                currentPlayer = Player.X;
            }
        }

        public void ClearBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' '; //empty space
            }
        }

        public void PlaceMove(int x, Player player)
        {
            if (board[x] == ' ' && board[x] != (int) Player.X && board[x] != (int) Player.O)
            {
                board[x] = (char) player;
            }
        }

        public bool Tie()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        public bool Win()
        {
            foreach (int[] x in triple)
            {
                if (board[x[0]] == board[x[1]] && board[x[0]] == board[x[2]] && board[x[0]] != ' ')
                {
                    winningTriple = x;
                    return true;
                }
            }
            return false;
        }

    }
}
