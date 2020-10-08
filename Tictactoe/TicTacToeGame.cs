using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Tictactoe
{
    class TicTacToeGame
    {
        public char[] board = new char[10];
        public void CreateBoard()
        {
            for (int i = 1; i < 10; i++)
            {
                board[i] = ' ';
            }
        }
    }
}
