using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Tracker.Models
{
    public enum WinState { White = 1, Black, Draw };

    public class Game
    {
        public readonly Guid Guid;

        public readonly int WhiteStartingScore;
        public readonly int BlackStartingScore;

        public Player White { get; }
        public Player Black { get; }

        public DateTime TimePlayed { get; private set; }
        public WinState Winner { get; private set; }

        public Player PlayerWinner
        {
            get
            {
                if (Winner == WinState.White)
                {
                    return White;
                }
                else if (Winner == WinState.Black)
                {
                    return Black;
                }
                else
                {
                    return null;
                }
            }
        }

        private Game(Player white, Player black, WinState winner, Guid? guid = null, int? whiteStartScore = null, int? blackStartScore = null, DateTime? timePlayed = null)
        {
            this.White = white;
            this.Black = black;
            this.Winner = winner;
            if (guid.HasValue)
            {
                this.Guid = guid.Value;
            }
            else
            {
                this.Guid = Guid.NewGuid();
            }
            if (whiteStartScore.HasValue)
            {
                this.WhiteStartingScore = whiteStartScore.Value;
            }
            else
            {
                this.WhiteStartingScore = white.Score;

            }
            if (blackStartScore.HasValue)
            {
                this.BlackStartingScore = blackStartScore.Value;
            }
            else
            {
                this.BlackStartingScore = black.Score;
            }
            if (timePlayed.HasValue)
            {
                this.TimePlayed = TimePlayed;
            }
            else
            {
                this.TimePlayed = DateTime.Now;
            }
        }

        public static Game CreateNewGame(Player white, Player black, WinState winner)
        {
            return new Game(white, black, winner);
        }

        public static Game CreateExistingGame(Player white, Player black, WinState winner, Guid guid, int whiteStartScore, int blackStartScore, DateTime timePlayed)
        {
            return new Game(white, black, winner, guid, whiteStartScore, blackStartScore, timePlayed);
        }
    }
}
