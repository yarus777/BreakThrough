using UnityEngine;

namespace Assets.Scripts
{
    public class InputDetector : MonoBehaviour
    {

        public Ball.Ball ball;
        public Platform.Platform platform;
        private Camera camera;
        private float yPosition;

        void Start () {
            camera = Camera.main;
            yPosition = platform.GetComponent<RectTransform>().anchoredPosition.y;
        }
	
        void Update () {
	
        }

        public void OnScreenClick ()
        {
            ball.SendBall();
        }

        private Vector3 pointerOffset;
        private float prevpos;
        private bool isPressed = false;

        public void OnDown ()
        {
            Vector2 clickPosition = camera.ScreenToWorldPoint(Input.mousePosition);
            //pointerOffset = clickPosition - platform.GetComponent<RectTransform>().anchoredPosition;
            prevpos = clickPosition.x;
            isPressed = true;
        }

        //public void OnDrag()
        //{
        //    Vector2 pos = camera.ScreenToWorldPoint(Input.mousePosition) - pointerOffset;
        //    var platformSize = platform.GetComponent<RectTransform>().sizeDelta;
        //    if (camera.WorldToViewportPoint(pos + platformSize / 2).x > 1||
        //        camera.WorldToViewportPoint(pos - platformSize / 2).x < 0)
        //    {
        //        return;
        //    }
        //    platform.GetComponent<RectTransform>().anchoredPosition = new Vector2(pos.x, yPosition);
        //}

        public void FixedUpdate()
        {
            if (!isPressed)
            {
                return;
            }
            Vector2 pos = camera.ScreenToWorldPoint(Input.mousePosition);
            platform.rigidbody2D.velocity = new Vector2((pos.x-prevpos)/Time.deltaTime, 0);
            prevpos = pos.x;
        }

        public void OnUp()
        {
            platform.rigidbody2D.velocity = Vector2.zero;
            isPressed = false;
        }
    }
}
