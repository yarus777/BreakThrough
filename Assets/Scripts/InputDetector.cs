using UnityEngine;

public class InputDetector : MonoBehaviour
{

    public Ball ball;
    public Platform platform;
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

    private Vector2 pointerOffset;

    public void OnDown ()
    {
        Vector2 clickPosition = camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        pointerOffset = clickPosition - platform.GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnDrag()
    {
        Vector2 pos = camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        platform.GetComponent<RectTransform>().anchoredPosition = new Vector2((pos - pointerOffset).x, yPosition);
    }
}
