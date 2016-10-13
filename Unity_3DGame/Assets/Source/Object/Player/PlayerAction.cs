using UnityEngine;
using System.Collections;


public class PlayerAction : MonoBehaviour
{

    // アニメーション
    private Animator m_animation;
    private Rigidbody m_rigidbody;
    private AnimatorStateInfo m_animatorInfo;

    public float m_spped = 0.07f;
    public float m_gravity = 0.1f;

    // Use this for initialization
    void Start()
    {
        // コンポーネントを取得
        m_rigidbody = GetComponent<Rigidbody>();
        m_animation = GetComponent<Animator>();
        m_animatorInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        // 初期アニメーション
        m_animation.Play("Idle");
    }

    void FixedUpdate()
    {
        // プレイヤーの向き
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        // マウス右クリック
        if (Input.GetMouseButtonDown(0))
        {
            m_animation.SetBool("Attack", true);
            return;
        }
        else
        {
            m_animation.SetBool("Attack", false);
        }

        // ジャンプ
        if(Input.GetKey(KeyCode.Space))
        {
            m_animation.SetBool("Jump", true);
        }
        else
        {
            m_animation.SetBool("Jump", false);
        }

        // 入力判定
        if (x != 0.0f || z != 0.0f)
        {
            m_animation.SetBool("Walk", true);
        }
        else
        {
            m_animation.SetBool("Walk", false);
        }

        // 移動
       m_rigidbody.position += new Vector3(x * m_spped, -m_gravity, z * m_spped);
    }
}
