using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWitUi
{
    public class Player
    {
        public ConsoleColor mainTextColor = ConsoleColor.White;
        public ConsoleColor badEventTextColor = ConsoleColor.Red;
        public ConsoleColor goodEventTextColor = ConsoleColor.Green;
        public Player(string name, char team)
        {
            Name = name;
            Team = team;
        }
        public string Name
        { get; set; }
        public char Team
        { get; set; }
        public int WinCount { get; set; }
        public int LossCount { get; set; }
        public int DrawCount { get; set; }


        public string GetMove()
        {
            Console.WriteLine("Claim a territory (1-9): ");
            string input = Console.ReadLine();
            int parsedInput = 10; //makes if loop false
            try
            {
                parsedInput = Int32.Parse(input);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = this.badEventTextColor;
                Console.WriteLine("Invalid input. Try again.");
                Console.ForegroundColor = this.mainTextColor;
                return GetMove(); //recursive call..should it be helper?
            }
            //checks for boundary that game permits (1-9) 
            if (parsedInput > 0 && parsedInput < 10)
            {
                return input;
            }
            else
            {
                Console.ForegroundColor = this.badEventTextColor;
                Console.WriteLine("Invalid input. Try again.");
                Console.ForegroundColor = this.mainTextColor;

                return GetMove();
            }

        }

        public void DisplayWinner(string playerName)
        {
            Console.ForegroundColor = this.goodEventTextColor;
            Console.WriteLine($"{playerName} is the winner!");
            Console.ForegroundColor = this.mainTextColor;
        }
    }
}
