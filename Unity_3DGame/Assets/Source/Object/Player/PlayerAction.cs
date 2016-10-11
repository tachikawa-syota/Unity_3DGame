using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {


    // アニメーション
    private Animator m_animation;
    private AnimatorStateInfo m_animatorInfo;
	private float m_length;
	private float m_Cur;

    float m_speed = 10;

    // Use this for initialization
    void Start()
    {
        m_animation = GetComponent<Animator>();
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
        //  入力をxとzに代入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown("a"))
        {
			if(!Attack())return;
        }

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

        rigidbody.position += new Vector3(x * 0.1f, -0.1f, z * 0.1f);

        // rigidbodyのx軸（横）とz軸（奥）に力を加える
//        rigidbody.AddForce(x * m_speed, 0, z * m_speed);
    }
}
