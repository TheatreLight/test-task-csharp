namespace TicTacToe.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public char[,] Board { get; set; }
        public string Status { get; set; }
        public string CurrentPlayer { get; set; }
        public bool IsGameOver { get; set; }
        public bool Success { get; set; }

        public Game()
        {
            Board = new char[3, 3];
            ResetBoard();
            CurrentPlayer = Player1;
        }

        public void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = '.';
                }
            }
            IsGameOver = false;
        }

        public void MakeMove(string player, int row, int column)
        {
            if (player != CurrentPlayer || IsGameOver)
            {
                Success = false;
                return;
            }
            if (Board[row, column] != '.')
            {
                Success = false;
                return;
            }
            Board[row, column] = (player == Player1) ? 'X' : 'O';
            if (CheckForWin(Board))
            {
                IsGameOver = true;
                Success = true;
                return;
            }
            if (CheckForTie(Board))
            {
                IsGameOver = true;
                Success = false;
                return;
            }
            CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
            Success = true;
            return;
        }

        private bool CheckForWin(char[,] board)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != '.' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return true;
                }
            }

            // Check columns
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] != '.' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[1, 1] != '.' && ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) || (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])))
            {
                return true;
            }

            return false;
        }

        private bool CheckForTie(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
