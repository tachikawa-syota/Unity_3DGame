using UnityEngine;
using System.Collections;

public class CollisionEffect : MonoBehaviour 
{
    public ParticleSystem m_particle;

	// Use this for initialization
	void Start () {
        m_particle = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision collision)
    {
  //      if (Time.timeSinceLevelLoad > 10.0f & Time.timeSinceLevelLoad < 50.0f)
    //    {
		if (collision.gameObject.CompareTag("CollisionObject"))
            {
	//		Destroy (this);
            //    m_particle.Play(); //パーティクルの再生
                Debug.Log("HIT");
            }
     //   }
    }
}
