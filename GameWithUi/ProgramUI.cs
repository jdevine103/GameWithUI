using GameWitUi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace GameWithUi
{
    class ProgramUI
    {
        //properties
        ConsoleColor badEventTextColor = ConsoleColor.Red;
        ConsoleColor mainTextColor = ConsoleColor.White;
        ConsoleColor drawTextColor = ConsoleColor.Yellow;
        ConsoleColor XTextColor = ConsoleColor.Blue;
        ConsoleColor OTextColor = ConsoleColor.Magenta;
        private bool _isRunning = true; //exit in menu 

        private readonly GameRepo _gameRepo = new GameRepo();

        //methods
        public void Start()
        {
            Console.WriteLine("Lets play tic tac toe.");
            CreatePlayers();
            RunMenu();
        }

        public void CreatePlayers()
        {
            //create the players 
            
            Console.WriteLine("Enter Player 1's name: ");
            string NameOne = Console.ReadLine();
            Console.WriteLine("Enter Player 2's name: ");
            string NameTwo = Console.ReadLine();
            Player PlayerOne = new Player(NameOne, 'X');
            Player PlayerTwo = new Player(NameTwo, 'O');
            //add players to repo for scoreboard memory retention/whatever thats called
            _gameRepo.AddPlayerToLeaderboard(PlayerOne);
            _gameRepo.AddPlayerToLeaderboard(PlayerTwo);
        }
        private void RunMenu()
        {
            while (_isRunning)
            {
                //get selection for menu
                string userInputFromMenu = GetMenuSelection();
                //call menu selection 
                OpenMenuItem(userInputFromMenu);
            }
        }
        private string GetMenuSelection()
        {
            Console.Clear();
            Console.WriteLine(
                            "Welcome to Tic Tac Toe!\n" +
                            "Select Menu Item:\n" +
                            "1. Play new game\n" +
                            "2. See leaderboard\n" +
                            "3. Exit\n");

            string userInput = Console.ReadLine(); //bound check
            return userInput;
        }
        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    // Start new game
                    NewGame();
                    break;
                case "2":
                    _gameRepo.PrintScoreboard();
                    break;
                case "3":
                    _isRunning = false;
                    return;
                default:
                    // Invalid selection
                    //_console.WriteLine("Invalid input.");
                    Console.WriteLine("Invalid input, try again.");
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    RunMenu(); //start over menu if menu input is not 1, 2, or 3. DOES THIS MESS UP _gameRepo?
                    break; 
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
        private void NewGame()
        {
            //create new board
            Board CurrentBoard = new Board("1", "2", "3", "4", "5", "6", "7", "8", "9", 0);

            //show fresh board
            CurrentBoard.ShowBoard();

            //play the game
            while (!CurrentBoard.CheckForWin() && !CurrentBoard.CheckForDraw())
            {
                if (CurrentBoard.TotalMoveCount % 2 == 0)
                {
                    Console.ForegroundColor = this.XTextColor;
                    Console.Write($"{_gameRepo.GetPlayer(1).Name}'s");
                    Console.ForegroundColor = mainTextColor;
                    Console.WriteLine(" turn (X)");
                    //checks for dup player 1
                    bool isValid;
                    string Choice;
                    do
                    {
                        Choice = _gameRepo.GetPlayer(1).GetMove();
                        isValid = CurrentBoard.CheckForDuplicate(Choice);

                        if (isValid == true)
                        {
                            Console.ForegroundColor = badEventTextColor;
                            Console.WriteLine("Territory is already taken. Choose different territory.");
                            Console.ForegroundColor = mainTextColor;
                        }

                    } while (isValid);
                    //make move if input is not a duplicate move
                    CurrentBoard.MakeMove(Choice, _gameRepo.GetPlayer(1).Team);
                    CurrentBoard.TotalMoveCount++; //maybe change
                }
                else
                {
                    Console.ForegroundColor = this.OTextColor;
                    Console.Write($"{_gameRepo.GetPlayer(2).Name}'s");
                    Console.ForegroundColor = mainTextColor;
                    Console.WriteLine(" turn (O)");
                    //checks for dup player 2
                    bool isValid;
                    string Choice;
                    do
                    {
                        Choice = _gameRepo.GetPlayer(2).GetMove();
                        isValid = CurrentBoard.CheckForDuplicate(Choice);

                        if (isValid == true)
                        {
                            Console.ForegroundColor = badEventTextColor;
                            Console.WriteLine("Territory is already taken. Choose different territory.");
                            Console.ForegroundColor = mainTextColor;
                        }

                    } while (isValid);
                    //make move if input is not a duplicate move
                    CurrentBoard.MakeMove(Choice, _gameRepo.GetPlayer(2).Team);
                    CurrentBoard.TotalMoveCount++; //maybe change
                }
                Console.Clear();
                CurrentBoard.ShowBoard();
            }
            //display winner //could clean this up a bit
            if (CurrentBoard.TotalMoveCount % 2 == 0 && !CurrentBoard.CheckForDraw())
            {
                _gameRepo.GetPlayer(2).DisplayWinner(_gameRepo.GetPlayer(2).Name);
                _gameRepo.GetPlayer(2).WinCount++;
                _gameRepo.GetPlayer(1).LossCount++;

            }
            else if (CurrentBoard.TotalMoveCount % 2 == 1 && !CurrentBoard.CheckForDraw())
            {
                _gameRepo.GetPlayer(1).DisplayWinner(_gameRepo.GetPlayer(1).Name);
                _gameRepo.GetPlayer(1).WinCount++;
                _gameRepo.GetPlayer(2).LossCount++;

            }
            else 
            {
                Console.ForegroundColor = drawTextColor;
                Console.WriteLine("Draw");
                _gameRepo.GetPlayer(1).DrawCount++;
                _gameRepo.GetPlayer(2).DrawCount++;
                Console.ForegroundColor = mainTextColor;
                //add draw to scoreboard
            }
        }
    }
}

