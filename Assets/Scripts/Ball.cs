using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector2 ballInitialForce;
    private bool IsRunning;

	void Start () {
        ballInitialForce = new Vector2(1500.0f, 1500.0f);	
	}

    public void SendBall()
    {
        if (!IsRunning)
        {
            rigidbody2D.AddForce(ballInitialForce);
            IsRunning = true;
        }
    }

    public delegate void BallLostDelegate(Ball ball);

    public event BallLostDelegate Lost;
    private void OnBallLost()
    {
        if (Lost != null)
        {
            Lost(this);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("1");
        if (coll.gameObject.GetComponent<Ground> () != null)  
        {
            Debug.Log("2");
            OnBallLost();
        }
    }
}
