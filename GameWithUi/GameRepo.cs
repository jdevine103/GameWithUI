using GameWitUi;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameWithUi
{
    class GameRepo
    {
        private readonly List<Player> _leaderBoard = new List<Player>();

        public void AddPlayerToLeaderboard (Player player)
        {
            _leaderBoard.Add(player);
        }
        public void PrintScoreboard()
        {
            Console.WriteLine("Scoreboard: ");
            Console.WriteLine($"{GetPlayer(1).Name} has {GetPlayer(1).WinCount} W, {GetPlayer(1).LossCount} L, " +
                $"and {GetPlayer(1).DrawCount} draws.");
            Console.WriteLine($"{GetPlayer(2).Name} has {GetPlayer(2).WinCount} W, {GetPlayer(2).LossCount} L, " +
                $"and {GetPlayer(2).DrawCount} draws.");
        }
        public Player GetPlayer(int i)
        {
            if (i == 1)
            {
                return _leaderBoard[0];
            } 
            else
            {
                return _leaderBoard[1];
            }
        }

    }
}
