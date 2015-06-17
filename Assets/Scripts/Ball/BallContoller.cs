using UnityEngine;

namespace Assets.Scripts.Ball
{
    public class BallContoller : MonoBehaviour {

        public Ball ball;
        private Vector2 pos;
        void Start ()
        {
            pos = ball.GetComponent<RectTransform>().anchoredPosition;

        }

        public void OnBallLost()
        {
            ball.rigidbody2D.velocity = new Vector2(0, 0);
            ball.GetComponent<RectTransform>().anchoredPosition = pos;
        }

        void Update () {
	
        }
    }
}
