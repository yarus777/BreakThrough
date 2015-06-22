using UnityEngine;

namespace Assets.Scripts.Platform
{
    public class Platform : MonoBehaviour {

        void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log(col.collider);
        }
    }
}
