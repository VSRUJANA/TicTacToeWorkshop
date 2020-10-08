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
        public const int HEAD = 1;
        public const int TAIL = 0;

        public void CreateBoard()
        {
            for (int i = 1; i < 10; i++)
            {
                board[i] = ' ';
            }
        }
        public char ChooseUserLetter()
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
            return userLetter;
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
            else if (isSpaceFree(index))
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
            if (board[index] == ' ')
            {
                return true;
            }
            else
            {
                Console.WriteLine("The index chosen is already occupied! Choose another index");
                return false;
            }
        }

        public string Toss()
        {
            Random random = new Random();
            int toss = random.Next(0, 2);
            string tossWin = (toss == HEAD) ? "User" : "Computer";
            Console.WriteLine(tossWin + " has won the toss and will start the game");
            return tossWin;
        }

        public bool CheckWin(char playerLetter)
        {
            bool win = (board[1] == playerLetter && board[2] == playerLetter && board[3] == playerLetter) ||
                       (board[4] == playerLetter && board[5] == playerLetter && board[6] == playerLetter) ||
                       (board[9] == playerLetter && board[8] == playerLetter && board[9] == playerLetter) ||
                       (board[1] == playerLetter && board[4] == playerLetter && board[7] == playerLetter) ||
                       (board[2] == playerLetter && board[5] == playerLetter && board[8] == playerLetter) ||
                       (board[3] == playerLetter && board[6] == playerLetter && board[9] == playerLetter) ||
                       (board[1] == playerLetter && board[5] == playerLetter && board[9] == playerLetter) ||
                       (board[3] == playerLetter && board[5] == playerLetter && board[7] == playerLetter);
            if (win == true)
            {
                if (playerLetter == userLetter)
                    Console.WriteLine("User won the game");
                else
                    Console.WriteLine("Computer won the game");
            }
            return win;
        }

        public bool CheckDraw()
        {
            int temp = 0;
            for (int i = 1; i < 10; i++)
            {
                if (!isSpaceFree(i))
                    temp++;
            }
            if (temp == 9)
            {
                if (!CheckWin('X') && !CheckWin('O'))
                    return true;
            }
            return false;
        }

    }
}
