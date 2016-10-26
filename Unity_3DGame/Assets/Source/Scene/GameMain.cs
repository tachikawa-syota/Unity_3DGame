using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMain : MonoBehaviour
{
    // プレイヤーリスト
    private GameObject m_player;

    // 敵(仮)
    private GameObject m_enemy;


	// Use this for initialization
	void Start () {
        m_player = Resources.Load<GameObject>("Player");

        // 仮
        m_enemy = Resources.Load<GameObject>("Cube");

        // 動的生成
        Instantiate(m_enemy, new Vector3(0f, 5f, 0f), Quaternion.identity);

        Instantiate(m_player, new Vector3(0f, 0f, 0f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public Vector3 GetPlayerPos()
    {
        return m_player.transform.position;
    }
}
