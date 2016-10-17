using UnityEngine;
using System.Collections;


public class PlayerAction : MonoBehaviour
{
    // カメラ
    private GameObject m_camera;
    // 1フレーム前のカメラの角度
    private Vector3 m_oldCameraAngle;
    // アニメーション
    private Animator m_animation;
    private Rigidbody m_rigidbody;
    private AnimatorStateInfo m_animatorInfo;

    public float m_moveSpeed = 0.07f;
    public float m_gravity = 0.1f;

    // 1フレーム前の座標
    private Vector3 m_oldPos;

    // Use this for initialization
    void Start()
    {
        m_camera = GameObject.Find("Camera");
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_oldPos = m_rigidbody.position;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_animation.SetBool("Jump", true);
        }
        else
        {
            m_animation.SetBool("Jump", false);
        }

        // 入力判定
        if (horizontal != 0.0f || vertical != 0.0f)
        {
            m_animation.SetBool("Walk", true);
        }
        else
        {
            m_animation.SetBool("Walk", false);
        }


       Vector3 forward = m_camera.transform.TransformDirection(Vector3.forward);
       Vector3 right = m_camera.transform.TransformDirection(Vector3.right);
  
       // 移動
       Vector3 moveDirection = horizontal * right + vertical * forward;
       moveDirection *= m_moveSpeed;
       m_rigidbody.position += moveDirection;
       UpdateRotation();
    }

    void UpdateRotation()
    {
        Vector3 diff =  m_rigidbody.position - m_oldPos;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        diff.Normalize();

        if(horizontal <= 0.4f)
        {
      //     right = m_camera.transform.TransformDirection(Vector3.right);
        }

       if(diff.x >= 0.00000000001f || diff.z >= 0.00000000001f)
        {
            // カメラの回転に合わせてプレイヤーも回転させる
            m_rigidbody.transform.rotation = Quaternion.LookRotation(new Vector3(diff.x, 0, diff.z));
        }

       // カメラの角度を保存 
       m_oldCameraAngle = m_camera.transform.localEulerAngles;
    }
}
