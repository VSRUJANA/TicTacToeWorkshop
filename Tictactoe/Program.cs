﻿using System;

namespace Tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe Game!");
            TicTacToeGame t = new TicTacToeGame();
            t.CreateBoard();
        }
    }
}