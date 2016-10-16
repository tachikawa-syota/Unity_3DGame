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
        if (horizontal != 0.0f || vertical != 0.0f)
        {
            m_animation.SetBool("Walk", true);
        }
        else
        {
            m_animation.SetBool("Walk", false);
        }

        UpdateRotation();

       Vector3 forward = m_camera.transform.TransformDirection(Vector3.forward);
       Vector3 right = m_camera.transform.TransformDirection(Vector3.right);
  
       // 移動
       Vector3 moveDirection = horizontal * right + vertical * forward;
       moveDirection *= m_moveSpeed;
       m_rigidbody.position += moveDirection;
    }

    void UpdateRotation()
    {
        Vector3 right = m_camera.transform.TransformDirection(Vector3.right);
         float horizontal = Input.GetAxis("Horizontal");

        if(horizontal >= 0.2f)
        {
// 調整中
        }

        if (m_oldCameraAngle != m_camera.transform.localEulerAngles)
        {
            // カメラの回転に合わせてプレイヤーも回転させる
            m_rigidbody.transform.rotation = Quaternion.Euler(0, m_camera.transform.localEulerAngles.y, 0);
        }

       // カメラの角度を保存 
       m_oldCameraAngle = m_camera.transform.localEulerAngles;
    }
}
