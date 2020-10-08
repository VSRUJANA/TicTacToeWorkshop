using System;

namespace Tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame t = new TicTacToeGame();
            t.CreateBoard();
            char userLetter = t.ChooseUserLetter();
            t.Toss();
            t.ShowBoard();
            t.CheckWin(userLetter);
        }
    }
}
