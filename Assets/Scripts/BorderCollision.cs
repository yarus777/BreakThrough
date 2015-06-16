using UnityEngine;
using System.Collections;

public class BorderCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "LeftBorder")
        {
            Debug.Log("blabla");
            GetComponent<RectTransform>().anchoredPosition = coll.gameObject.GetComponent<RectTransform>().anchoredPosition;
        }
    }
}
