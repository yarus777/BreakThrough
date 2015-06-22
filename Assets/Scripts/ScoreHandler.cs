

using UnityEngine;

namespace Assets.Scripts
{
    public class ScoreHandler
    {
        public int score;

        public ScoreHandler(int score)
        {
            this.score = score;
        }

        public void OnBlockTouched()
        {
            score = score + 50;
            //Debug.Log(score);
        }
    }
}
