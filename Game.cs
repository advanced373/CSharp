using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        GameBoard principalBoard;  
        Player player1;
        Player player2;
        int numberOfPlayers = 2;
        int currentPlayer;   //to know when you put X or O
        public Game()
        {
            principalBoard = new GameBoard();
            this.player1 = new Player("O");
            this.player2 = new Player("X");
        }
        public void Start()   //function that start the program
        {
            currentPlayer = 1;
            principalBoard.PrintGameBoard();
            int flag = 0;
            while(principalBoard.CheckGameBoard()!=true)
            {
                if (principalBoard.checkIfFull() != true)
                {
                    Round();
                    principalBoard.PrintGameBoard();
                }
                else
                {
                    flag = 1;
                    break;
                }
            }
            if(currentPlayer == 2 && flag == 0)
            {
                Console.WriteLine("Player 1 won!");
            }
            else if(currentPlayer == 1 && flag == 0)
            {
                Console.WriteLine("Player 2 won!");
            }
            else
            {
                Console.WriteLine("Draw!");
            }
        }
        private void Round()   //try and catch because you need an int between 0 and 8
        {
            Console.WriteLine("Insert your option(number) from 0 to 8:");
            try
            {
                int option = int.Parse(Console.ReadLine());
                if (option < 0 || option > 8)
                    throw new OverflowException();
                if(currentPlayer == 1)
                {
                    this.principalBoard.ModifyBoardValues(option, player1.Sign);
                    currentPlayer = 2;
                }
                else
                {
                    this.principalBoard.ModifyBoardValues(option, player2.Sign);
                    currentPlayer = 1;
                }

            }
            catch(FormatException)
            {
                Console.WriteLine("Please, enter a number!");
            }
            catch(OverflowException)
            {
                Console.WriteLine("Please, enter a number in that range!");
            }
            catch(Exception)
            {
                Console.WriteLine("Error! Please, try again!");
            }
        }
    }
    
}
