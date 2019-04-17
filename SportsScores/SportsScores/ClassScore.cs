using System;

namespace SportsScores
{
    class ClassScore
    {

        public ClassScore(String scoreDate, int score)
        {
            ScoreDate = scoreDate;
            Score = score;
        }

        public String ScoreDate { get; set; }
        public int Score { get; set; }

    }
}
