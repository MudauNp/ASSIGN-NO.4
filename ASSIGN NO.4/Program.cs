using System;

class TicTacToe
{
    private char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    private char currentPlayer = 'X';
    private int turns = 0;
    private bool isGameOver = false;

    public void Run()
    {
        do
        {
            Console.Clear();
            PrintBoard();
            GetPlayerMove();
            CheckForWinner();
            SwitchPlayer();
            turns++;

        } while (!isGameOver && turns < 9);

        Console.Clear();
        PrintBoard();
        PrintGameResult();
    }

    private void PrintBoard()
    {
        Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
    }

    private void GetPlayerMove()
    {
        int move;
        bool isValidMove;

        do
        {
            Console.WriteLine($"Player {currentPlayer}, enter your move (1-9): ");
            isValidMove = int.TryParse(Console.ReadLine(), out move);

            if (isValidMove && move >= 1 && move <= 9 && board[move - 1] == (char)(move + '0'))
            {
                board[move - 1] = currentPlayer;
                break;
            }
            else
            {
                Console.WriteLine("Invalid move. Please try again.");
            }

        } while (true);
    }

    private void CheckForWinner()
    {
        if (
            (board[0] == board[1] && board[1] == board[2]) ||
            (board[3] == board[4] && board[4] == board[5]) ||
            (board[6] == board[7] && board[7] == board[8]) ||
            (board[0] == board[3] && board[3] == board[6]) ||
            (board[1] == board[4] && board[4] == board[7]) ||
            (board[2] == board[5] && board[5] == board[8]) ||
            (board[0] == board[4] && board[4] == board[8]) ||
            (board[2] == board[4] && board[4] == board[6])
        )
        {
            isGameOver = true;
        }
    }

    private void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    private void PrintGameResult()
    {
        if (isGameOver)
        {
            Console.WriteLine($"Player {currentPlayer} wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}

class Program
{
    static void Main()
    {
        ConsoleColor oldColor = Console.ForegroundColor;

        Console.SetCursorPosition(10, 2);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to Tic Tac Toe");

        var ticTacToe = new TicTacToe();

        ticTacToe.Run();

        Console.ForegroundColor = oldColor;

        Console.SetCursorPosition(20, 25);
        Console.WriteLine("Thank you for playing");
        Console.ReadLine();
    }
}
