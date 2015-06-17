using UnityEngine;

namespace Assets.Scripts.Platform
{
    public class PlatformController : MonoBehaviour
    {

        public Platform platform;
        private Vector2 pos;

        void Start () {

            pos = platform.GetComponent<RectTransform>().anchoredPosition;
	
        }

        void Update () {
	
        }

        public void OnBallLost()
        {
            platform.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }
}
