using System;

namespace Tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame t = new TicTacToeGame();
            do
            {
                t.CreateBoard();
                char userLetter = t.ChooseUserLetter();
                string tossWin = t.Toss();
                t.Play(tossWin);
                Console.WriteLine("Do you want to play again? press (y/n)");
                char option = Console.ReadLine()[0];
                if (option == 'y')
                    continue;
                else
                    break;
            }
            while (true);
        }
    }
}
