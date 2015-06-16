using UnityEngine;
using System.Collections;

public class BallContoller : MonoBehaviour {

    public Ball ball;
	void Start ()
	{
	    ball.Lost += OnBallLost;

	}

    private void OnBallLost(Ball ball1)
    {
        Debug.Log("Lost Ball");
    }

	void Update () {
	
	}
}
