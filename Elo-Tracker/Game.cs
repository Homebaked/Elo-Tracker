﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elo_Tracker.Models
{
    public class Game
    {
        public enum WinState { White, Black, Draw };

        public readonly Guid Guid;

        public readonly Player White;
        public readonly Player Black;

        public readonly int WhiteStartingScore;
        public readonly int BlackStartingScore;

        public DateTime TimePlayed { get; private set; }
        public WinState Winner { get; private set; }

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
            return new Game(white, black);
        }

        public static Game CreateExistingGame(Player white, Player black, WinState winner, Guid guid, int whiteStartScore, int blackStartScore, DateTime timePlayed)
        {
            return new Game(white, black, guid, whiteStartScore, blackStartScore, timePlayed);
        }
    }
}
