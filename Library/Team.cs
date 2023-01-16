using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Team
    {
        string name;

        /// <summary>
        /// List of players of the Team
        /// </summary>
        List<Player> players;

        /// <summary>
        /// Team captain
        /// </summary>
        Player? captain;
        
        /// <summary>
        /// Maximum number of players for each role
        /// </summary>
        const int MAX_RISERVA_PLAYERS = 3;
        const int MAX_ROSA_PLAYERS = 11;
        int riserva, rosa;

        public Team(string name)
        {
            this.name = name;
            riserva = 0;
            rosa = 0;
        }

        /// <summary>
        /// Adding player to a Team
        /// 
        /// We can have a maximum of MAX_ROSA_PLAYERS rosa's players and MAX_RISERVA_PLAYERS riserva's player
        /// </summary>
        /// <param name="player"></param>
        /// <returns>True if player has been inserted</returns>
        public bool AddPlayer(Player player)
        {
            if ((int)player.Role == 0 && rosa < MAX_ROSA_PLAYERS)
            {
                players.Add(player);
                rosa++;
                return true;
            }
            else if ((int)player.Role == 1 && riserva < MAX_ROSA_PLAYERS)
            {
                players.Add(player);
                riserva++;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Setting captain of the Team
        /// 
        /// Captain must be in the Rosa role
        /// </summary>
        /// <param name="captain"></param>
        /// <returns>True if captain has been setted</returns>
        public bool AddCaptain(Player captain)
        {
            if ((int)captain.Role == 0)
            {
                this.captain = captain;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Get a list of players of the team
        /// </summary>
        /// <returns></returns>
        public string GetPlayers()
        {
            string playerList = "";
            foreach (Player player in players)
            {
                playerList += $"Giocatore: {player.Description()} - Ruolo: {player.Role}";
            }
            return playerList;
        }

        public string Name { get { return name; } }

        public Player? Captain { get { return captain; } }
    }
}
