using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        //making array and
        //by default I am providing 0-9 where no use of zero
        static readonly char[] arr = { '-', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1; //By default player 1 is set
        static int choice; //This holds the choice at which position user want to mark
        // The flag variable checks who has won if it's value is 1 then someone has won the match
        //if -1 then Match has Draw if 0 then match is still running
        static int flag = 0;
        static void Main()
        {
            do
            {
                Console.Clear();// whenever loop will be again start then screen will be clear
                Console.WriteLine("Player1:X and Player2:O");
                Console.WriteLine("\n");
                Console.WriteLine($"Player {player}'s turn");
                Console.WriteLine("\n");
                Board();// calling the board Function
                choice = int.Parse(Console.ReadLine());//Taking users choice
                // checking that position is unmarked (The value in the array is a number)
                if (char.IsDigit(arr[choice]))
                {
                    arr[choice] = player == 1 ? arr[choice] = 'X' : arr[choice] = 'O';
                }
                else
                //If a position is already marked, show message and load the board again
                {
                    Console.WriteLine($"Sorry the row {choice} is already marked with {arr[choice]}");
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();// calling of check win
                if(flag != 1)
                    player = player == 1 ? 2 : 1;
            }
            while (flag == 0);
            // This loop will continue until all someone wins or draws
            Console.Clear();// clearing the console
            Board();// getting filled board again
            // if flag value is 1 then someone has won else it is a draw
            string message = flag == 1 ? $"Player {player} has won" : "Draw";
            Console.WriteLine(message);
            Console.ReadLine();
        }
        // This method creates the board used for the game
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[1]}  |  {arr[2]}  |  {arr[3]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[4]}  |  {arr[5]}  |  {arr[6]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {arr[7]}  |  {arr[8]}  |  {arr[9]}");
            Console.WriteLine("     |     |      ");
        }
        //Checking that any player has won or not
        private static int CheckWin()
        {
            #region Horzontal Winning Condtion
            for (int i = 1; i < 9; i += 3)
            {
                if (arr[i] == arr[i + 1] && arr[i] == arr[i + 2])
                    return 1;
            }
            #endregion
            #region vertical Winning Condtion
            for (int i = 1; i < 4; i++)
            {
                if (arr[i] == arr[i + 3] && arr[i] == arr[i + 6])
                    return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            for (int i = 1; i < 4; i += 2)
            {
                if (arr[i] == arr[5] && arr[i] == arr[5 + 5 - i]) // 5 is the center of the board
                    return 1;
            }
            #endregion
            #region Checking For Draw
            // If none of the values in arr are a digit the game is a draw and no one has one
            if (arr.All(y => !Char.IsDigit(y)))
                return -1;
            #endregion
            return 0;
        }
    }
}