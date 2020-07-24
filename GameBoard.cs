using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameBoard
    {
        string[,] gameBoardValues;  //board values
        public int Dimension { get; set; }
        public GameBoard()
        {
            Dimension = 3;
            gameBoardValues = new string[Dimension, Dimension];
            for(int i=0;i<Dimension;i++)
            {
                for(int j=0;j<Dimension;j++)
                {
                    gameBoardValues[i, j] = (i * Dimension + j).ToString();
                }
            }
        }
        public void ModifyBoardValues(int option, string newValue)    //when a player select where to put x or 0
        {
            int rowNumber = option / Dimension;
            int columnNumber = option % Dimension;
            if (this.gameBoardValues[rowNumber, columnNumber] != "O" && this.gameBoardValues[rowNumber, columnNumber] != "X")
            {
                this.gameBoardValues[rowNumber, columnNumber] = newValue;
            }
            else
            {
                Console.WriteLine("Cannot modify a value! You lost your round.");
            }
        }
        public void PrintGameBoard()  //show game board
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("_____________");
            for(int i=0;i<Dimension;i++)
            {
                Console.WriteLine("| {0} | {1} | {2} |", gameBoardValues[i,0], gameBoardValues[i,1], gameBoardValues[i,2]);
                Console.WriteLine("_____________");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public bool CheckGameBoard()
        {
            if(CheckDiagonals() == true)
            {
                return true;
            }
            if (CheckLinesAndColumns() == true)
                return true;
            return false;
        }
        private bool CheckLinesAndColumns()  //verify on lines and columns if a player has 3
        {
            bool returnValue = false;
            string currentValue;
            for (int j = 0; j < this.Dimension; j++)
            {
                currentValue = gameBoardValues[j,0];
                for (int i = 1; i < this.Dimension; i++)
                {
                    if (gameBoardValues[j,i] == currentValue)
                    {
                        returnValue = true;
                    }
                    else
                    {
                        returnValue = false;
                        break;
                    }
                }
                if(returnValue == true)
                {
                    return true;
                }
            }
            for (int j = 0; j < this.Dimension; j++)
            {
                currentValue = gameBoardValues[0,j];
                for (int i = 1; i < this.Dimension; i++)
                {
                    if (gameBoardValues[i, j] == currentValue)
                    {
                        returnValue = true;
                    }
                    else
                    {
                        returnValue = false;
                        break;
                    }
                }
                if (returnValue == true)
                {
                    return true;
                }
            }
            return false;
        }
        private bool CheckDiagonals()  //check diagonals
        {
            bool returnValue = false;
            string currentValue=gameBoardValues[0,0];
            for(int i=1;i<Dimension;i++)
            {
                if(currentValue == gameBoardValues[i,i])
                {
                    returnValue = true;
                }
                else
                {
                    returnValue = false;
                    break;
                }
            }
            if (returnValue == true)
            {
                return true;
            }
            currentValue = gameBoardValues[0, Dimension - 1];
            for(int i=1;i<Dimension;i++)
            {
                if(gameBoardValues[i,Dimension-i] == currentValue)
                {
                    returnValue = true;
                }
                else
                {
                    returnValue = false;
                    break;
                }
            }
            if(returnValue == true)
            {
                return true;
            }
            return false;
        }
        public bool  checkIfFull()  //check if you can make a move
        {
            for(int i=0;i<Dimension;i++)
            {
                for(int j=0;j<Dimension;j++)
                {
                    if(this.gameBoardValues[i,j] != "X" && this.gameBoardValues[i,j] != "O")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
