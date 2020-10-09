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
            Console.Write("| ");
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
            Console.WriteLine("\nYour Turn : Choose an index from 1 to 9");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index < 1 || index > 9)
            {
                Console.WriteLine("The index chosen is invalid! choose a number between 1 to 9");
                UserMove();
            }
            else if (isSpaceFree(board, index))
            {
                board[index] = userLetter;
            }
            else
            {
                Console.WriteLine("The index chosen is already occupied! Choose another index");
                UserMove();
            }
        }

        public bool isSpaceFree(char[] b, int index)
        {
            if (board[index] == ' ')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Toss()
        {
            Random random = new Random();
            int toss = random.Next(0, 2);
            string tossWin = (toss == HEAD) ? "You" : "Computer";
            Console.WriteLine(tossWin + " won the toss and will start the game");
            return tossWin;
        }
        public bool CheckWin(char[] b, char playerLetter)
        {
            bool win = (b[1] == playerLetter && b[2] == playerLetter && b[3] == playerLetter) ||
                       (b[4] == playerLetter && b[5] == playerLetter && b[6] == playerLetter) ||
                       (b[7] == playerLetter && b[8] == playerLetter && b[9] == playerLetter) ||
                       (b[1] == playerLetter && b[4] == playerLetter && b[7] == playerLetter) ||
                       (b[2] == playerLetter && b[5] == playerLetter && b[8] == playerLetter) ||
                       (b[3] == playerLetter && b[6] == playerLetter && b[9] == playerLetter) ||
                       (b[1] == playerLetter && b[5] == playerLetter && b[9] == playerLetter) ||
                       (b[3] == playerLetter && b[5] == playerLetter && b[7] == playerLetter);

            return win;
        }
        public bool CheckDraw()
        {
            int temp = 0;
            for (int i = 1; i < 10; i++)
            {
                if (!isSpaceFree(board, i))
                    temp++;
            }
            if (temp == 9)
            {

                if (!CheckWin(board, 'X') && !CheckWin(board, 'O'))
                    return true;
            }
            return false;
        }

        public void ComputerMove()
        {
            Console.WriteLine("\nComputer's turn :");
            int index = getWinningMove();
            if (Convert.ToBoolean(index))
            {
                board[index] = computerLetter;
            }
            else
            {
                Random random = new Random();
                do
                {
                    int randomIndex = random.Next(1, 10);
                    if (isSpaceFree(board, randomIndex))
                    {
                        board[randomIndex] = computerLetter;
                        break;
                    }
                }
                while (true);
            }
        }
        public int getWinningMove()
        {
            for (int i = 1; i < 10; i++)
            {
                char[] copyOfBoard = getCopyOfBoard();
                if (isSpaceFree(copyOfBoard, i))
                {
                    copyOfBoard[i] = computerLetter;
                    if (CheckWin(copyOfBoard, computerLetter))
                    {
                        return i;
                    }
                }
            }
            for (int i = 1; i < 10; i++)
            {
                char[] copyOfBoard = getCopyOfBoard();
                if (isSpaceFree(copyOfBoard, i))
                {
                    copyOfBoard[i] = userLetter;
                    if (CheckWin(copyOfBoard, userLetter))
                    {
                        return i;
                    }
                }
            }
            return 0;
        }
        public char[] getCopyOfBoard()
        {
            char[] boardCopy = new char[10];
            for (int i = 1; i < 10; i++)
            {
                boardCopy[i] = board[i];
            }
            return boardCopy;
        }
        public void Play(string player)
        {
            if (player == "You")
            {
                do
                {
                    UserMove();
                    ShowBoard();
                    if (Convert.ToBoolean(DisplayWinner()))
                        break;
                    ComputerMove();
                    ShowBoard();
                    if (Convert.ToBoolean(DisplayWinner()))
                        break;
                }

                while (!CheckWin(board, userLetter) && !CheckWin(board, computerLetter) && !CheckDraw());
            }
            else
            {
                do
                {
                    ComputerMove();
                    ShowBoard();
                    if (Convert.ToBoolean(DisplayWinner()))
                        break;
                    UserMove();
                    ShowBoard();
                    if (Convert.ToBoolean(DisplayWinner()))
                        break;
                }
                while (!CheckWin(board, userLetter) && !CheckWin(board, computerLetter) && !CheckDraw());
            }
        }
        public int DisplayWinner()
        {
            if (CheckWin(board, userLetter))
            {
                Console.WriteLine("\nGame Over!! You won the game");
                return 1;
            }
            else if (CheckWin(board, computerLetter))

            {
                Console.WriteLine("\nGame Over!! Computer won the game");
                return 1;
            }
            else if (CheckDraw())
            {
                Console.WriteLine("\nGame Over!! It's a tie");
                return 1;
            }
            return 0;
        }
    }
}
