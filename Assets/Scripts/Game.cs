using Assets.Scripts.Ball;
using Assets.Scripts.Block;
using Assets.Scripts.Block.Type;
using Assets.Scripts.Platform;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {

        public BallContoller ballController;
        public PlatformController platformController;
        public BlockController blockContoller;
        private LivesHandler livenum;
        private ScoreHandler scorenum;
       
        public VisualizeText visualizeText;

        void Start ()
        {
            livenum = new LivesHandler(3);
            scorenum = new ScoreHandler(0);
            visualizeText.Init(livenum, scorenum);       
            Debug.Log(scorenum.score);
            blockContoller.BlockTouched += OnBlockTouched;
            ballController.ball.Lost += OnBallLost;
            blockContoller.Create(new[] { new BlockInfo { X = 0, Y = 0, Type = BlockInfo.BlockType.Wood }, new BlockInfo { X = 200, Y = 300, Type = BlockInfo.BlockType.Stone }, new BlockInfo { X = -200, Y = -200, Type = BlockInfo.BlockType.Metal } });
        }


        private void OnBallLost(Ball.Ball ball)
        {
            ballController.OnBallLost();
            platformController.OnBallLost();
            livenum.OnBallLost();
        }

        private void OnBlockTouched(Block.Block block)
        {
            scorenum.OnBlockTouched();
        }

    }
}
