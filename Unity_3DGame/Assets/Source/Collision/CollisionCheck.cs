using UnityEngine;
using System.Collections;

public class CollisionCheck : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("OK");
        if (col.gameObject.CompareTag("CollisionObject"))
        {
            Debug.Log("HIT");
        }
    }
}
