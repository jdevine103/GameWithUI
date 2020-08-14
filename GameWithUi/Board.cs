using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GameWithUi
{


    public class Board
    {
        ConsoleColor XTextColor = ConsoleColor.Blue;
        ConsoleColor OTextColor = ConsoleColor.Magenta;
        ConsoleColor mainTextColor = ConsoleColor.White;

        public Board() { }
        public Board(string one, string two, string three, string four, string five, string six,
                        string seven, string eight, string nine, int moveCount)
        {
            One = one;
            Two = two;
            Three = three;
            Four = four;
            Five = five;
            Six = six;
            Seven = seven;
            Eight = eight;
            Nine = nine;
            TotalMoveCount = moveCount;
        }
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }
        public string Four { get; set; }
        public string Five { get; set; }
        public string Six { get; set; }
        public string Seven { get; set; }
        public string Eight { get; set; }
        public string Nine { get; set; }
        public int TotalMoveCount { get; set; }


        public void ShowBoard()
        {
            Console.WriteLine($"                       ");
            Console.WriteLine($"        |       |      ");
            Console.WriteLine($"    {One}   |   {Two}   |   {Three}  ");
            Console.WriteLine($"  ______|_______|______");
            Console.WriteLine($"        |       |      ");
            Console.WriteLine($"    {Four}   |   {Five}   |   {Six}  ");
            Console.WriteLine($"  ______|_______|______");
            Console.WriteLine($"        |       |      ");
            Console.WriteLine($"    {Seven}   |   {Eight}   |   {Nine}  ");
            Console.WriteLine($"        |       |      ");
            //Console.ReadLine();
        }
        public void MakeMove(string choice, char team)
        {
            switch (choice)
            {
                case "1":
                    One = team.ToString();                
                    break;
                case "2":
                    Two = team.ToString();
                    break;
                case "3":
                    Three = team.ToString();
                    break;
                case "4":
                    Four = team.ToString();
                    break;
                case "5":
                    Five = team.ToString();
                    break;
                case "6":
                    Six = team.ToString();
                    break;
                case "7":
                    Seven = team.ToString();
                    break;
                case "8":
                    Eight = team.ToString();
                    break;
                case "9":
                    Nine = team.ToString();
                    break;
                default:
                    break;
            }
        }

        public bool CheckForWin()
        {
            bool win = false;

            string[] PlayerOneWin = { "X", "X", "X" };
            string[] PlayerTwoWin = { "O", "O", "O" };

            List<string[]> WinningCombos = new List<string[]>
                {
                    new string[] { One, Two, Three },
                    new string[] { Four, Five, Six },
                    new string[] { Seven, Eight, Nine },
                    new string[] { One, Four, Seven },
                    new string[] { Two, Five, Eight },
                    new string[] { Three, Six, Nine },
                    new string[] { Three, Five, Seven },
                    new string[] { One, Five, Nine },
                };

            for (int i = 0; i < WinningCombos.Count(); i++)
            {
                if (WinningCombos[i].SequenceEqual(PlayerOneWin))
                {
                    win = true;
                    break;
                }
                else if (WinningCombos[i].SequenceEqual(PlayerTwoWin))
                {
                    win = true;
                    break;
                }
                else
                {
                    win = false;
                }
            }
            return win;
        }
        public bool CheckForDraw()
        {
            bool draw = false;
            if (TotalMoveCount < 9)
            {
                draw = false;
            }
            else
            {
                draw = true;
            }
            return draw;
        }


        public bool CheckForDuplicate(string choice)
        {
            switch (choice)
            {
                case "1":
                    if (One == "1")
                    {
                        return false;
                    }
                    break;
                case "2":
                    if (Two == "2")
                    {
                        return false;
                    }
                    break;
                case "3":
                    if (Three == "3")
                    {
                        return false;
                    }
                    break;
                case "4":
                    if (Four == "4")
                    {
                        return false;
                    }
                    break;
                case "5":
                    if (Five == "5")
                    {
                        return false;
                    }
                    break;
                case "6":
                    if (Six == "6")
                    {
                        return false;
                    }
                    break;
                case "7":
                    if (Seven == "7")
                    {
                        return false;
                    }
                    break;
                case "8":
                    if (Eight == "8")
                    {
                        return false;
                    }
                    break;
                case "9":
                    if (Nine == "9")
                    {
                        return false;
                    }
                    break;
                default:
                    return true;
            }
            return true;
        }
    }
}
