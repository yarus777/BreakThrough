using Assets.Scripts.Ball;
using Assets.Scripts.Block;
using Assets.Scripts.Platform;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {

        public BallContoller ballController;
        public PlatformController platformController;
        public BlockController blockContoller;

        void Start ()
        {
            ballController.ball.Lost += OnBallLost;
        }

        private void OnBallLost(Ball.Ball ball)
        {
            ballController.OnBallLost();
            platformController.OnBallLost();
        }

        void Update () {
	
        }
    }
}
