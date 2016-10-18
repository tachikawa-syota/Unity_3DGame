using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {

    // 敵(仮)
    private GameObject m_enemy;


	// Use this for initialization
	void Start () {
        // 仮
        m_enemy = Resources.Load<GameObject>("Cube");

        // 動的生成
        Instantiate(m_enemy, new Vector3(0f, 5f, 0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
