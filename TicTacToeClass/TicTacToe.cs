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

        public TicTacToe()
        {
            //Set the current Player
            currentPlayer = Player.X;

            //Set the board
            board = new char[9]; //board has 9 spots

            //Clear board at start of game
            ClearBoard();
        }

        public enum Player
        {
            X,
            O
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
                board[i] = '-';
            }
        }

    }
}
