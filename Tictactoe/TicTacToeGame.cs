using System;
using System.Collections.Generic;
using System.Text;

namespace Tictactoe
{
    class TicTacToeGame
    {
        public char[] board = new char[10];
        public static char userLetter;
        public static char computerLetter;

        public void CreateBoard()
        {
            for (int i = 1; i < 10; i++)
            {
                board[i] = ' ';
            }
        }
        public void ChooseUserLetter()
        {
            Console.WriteLine("Choose your letter- X or O");
            while (true)
            {
                userLetter = char.ToUpper(Console.ReadLine()[0]);
                if (userLetter != 'X' && userLetter != 'O')
                {
                    Console.WriteLine("Invalid input! Choose a valid letter- X or O");
                    continue;
                }
                break;
            }
            computerLetter = (userLetter == 'X') ? 'O' : 'X';
            Console.WriteLine("User Letter    : " + userLetter + "\nComputerLetter : " + computerLetter);
        }

        public void ShowBoard()
        {
            Console.Write("\n| ");
            for (int i = 1; i < 10; i++)
            {
                Console.Write(board[i] + " | ");
                if (i % 3 == 0 && i != 9)
                {
                    Console.WriteLine("\n----+---+----");
                    Console.Write("| ");
                }
            }
        }

        public void UserMove()
        {
            Console.WriteLine("\nChoose an index from 1 to 9");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index < 1 || index > 9)
            {
                Console.WriteLine("The index chosen is invalid! choose a number between 1 to 9");
                UserMove();
            }
            else if(isSpaceFree(index))
            {
                board[index] = userLetter;
            }
            else
            {
                UserMove();
            }
        }

        public bool isSpaceFree(int index)
        {
            if(board[index]==' ')
            {
                return true;
            }
            else
            {
                Console.WriteLine("The index chosen is already occupied! Choose another index");
                return false;
            }
        }
    }
}
