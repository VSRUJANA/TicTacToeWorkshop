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
            string tossWin = t.Toss();
            t.Play(tossWin);
        }
    }
}
