using UnityEngine;
using System.Collections;

public class EnemyAction : MonoBehaviour {

    GameObject m_obj;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("OK");
        if (col.gameObject.CompareTag("CollisionObject"))
        {
            Debug.Log("HIT");
            Destroy(m_obj);
        }
    }
}
