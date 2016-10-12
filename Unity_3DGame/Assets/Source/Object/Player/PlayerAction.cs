using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

    // アニメーション
    private Animator m_animation;
    private AnimatorStateInfo m_animatorInfo;
	private float m_length;
	private float m_Cur;

    public float m_spped = 0.07f;
    public float m_gravity = 0.1f;

    // Use this for initialization
    void Start()
    {
        m_animation = GetComponent<Animator>();
        // 初期アニメーション
        m_animation.Play("Idle");
        m_animation.SetBool("Walk", false);
		m_animation.SetBool("Attack", false);

		m_length = m_animatorInfo.length;
		m_Cur = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

	bool Attack()
	{
		m_animatorInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
		m_animation.SetBool ("Attack", true);

		if(m_animatorInfo.normalizedTime >= 1.0f)
		{
			m_animation.SetBool ("Attack", false);
			return true;
		}
		return false;
	}

    void FixedUpdate()
    {
        // プレイヤーの向き
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // マウス右クリック
        if (Input.GetMouseButton(0))
        {
            if (!Attack())return;
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

        // 同一のGameObjectが持つRigidbodyコンポーネントを取得
        Rigidbody rigidbody = GetComponent<Rigidbody>();

       rigidbody.position += new Vector3(x * m_spped, -m_gravity, z * m_spped);

    }
}
