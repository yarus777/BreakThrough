
using UnityEngine;

namespace Assets.Scripts
{
    public class LivesHandler
    {
        public int lives;

        public void OnBallLost()
        {   if (lives>0)
            lives--;
            Debug.Log(lives);
        }

        public LivesHandler(int lives)
        {
            this.lives = lives;
        }
    }
}
