using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector2 ballInitialForce;
    private bool IsRunning;


	// Use this for initialization
	void Start () {
        ballInitialForce = new Vector2(1500.0f, 1500.0f);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SendBall()
    {
        if (!IsRunning)
        {
            rigidbody2D.AddForce(ballInitialForce);
            IsRunning = true;
        }
    }
}
