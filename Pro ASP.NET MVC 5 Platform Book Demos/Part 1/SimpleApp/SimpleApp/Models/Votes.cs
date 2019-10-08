﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApp.Models
{
    public enum Color
    {
        Red = 1,
        Green = 2,
        Yellow = 3,
        Purple = 4
    }
    public class Votes
    {
        private static Dictionary<Color, int> votes = new Dictionary<Color, int>();
        public static void RecordVote(Color color)
        {
            votes[color] = votes.ContainsKey(color) ? votes[color] + 1 : 1;
        }
        public static void ChangeVote(Color newColor, Color oldColor)
        {
            if (votes.ContainsKey(oldColor))
            {
                votes[oldColor]--;
            }
            RecordVote(newColor);
        }
        public static int GetVotes(Color color)
        {
            return votes.ContainsKey(color) ? votes[color] : 0;
        }
    }
}