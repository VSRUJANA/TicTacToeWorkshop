using System;

namespace Tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame t = new TicTacToeGame();
            t.CreateBoard();
            t.ChooseUserLetter();
        }
    }
}
