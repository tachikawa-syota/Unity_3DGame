using UnityEngine;
using System.Collections;

// プレイヤーの行動
public class PlayerAction : MonoBehaviour
{
    // カメラ
    private GameObject m_camera;
    // 1フレーム前のカメラの角度
    private Vector3 m_oldCameraAngle;

    private Animation m_anim;
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
        m_anim = gameObject.GetComponent<Animation>();

        // カメラ
        m_camera = GameObject.Find("Camera");
        // コンポーネントを取得
        m_rigidbody = GetComponent<Rigidbody>();
        m_animation = GetComponent<Animator>();
        m_animatorInfo = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
    
        // 初期アニメーション
        m_animation.Play("Idle");
    }

    // 更新
    void FixedUpdate()
    {
        // プレイヤーの向き
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // １フレーム前の座標を保存する
        m_oldPos = m_rigidbody.position;

        // 行動
        if (!UpdateAction(horizontal, vertical)) return;

        // 移動
        UpdateMove(horizontal, vertical);

        // 回転
        UpdateRotation();
    }

    // 移動処理
    void UpdateMove(float horizontal, float vertical)
    {
        Vector3 forward = m_camera.transform.TransformDirection(Vector3.forward);
        Vector3 right = m_camera.transform.TransformDirection(Vector3.right);

        // 移動
        Vector3 moveDirection = horizontal * right + vertical * forward;
        moveDirection *= m_moveSpeed;
        m_rigidbody.position += moveDirection;
    }

    // 行動の更新
    // true - 更新 ： false - 更新しない 
    bool UpdateAction(float horizontal, float vertical)
    {
        // マウス右クリック
        if (Input.GetMouseButtonDown(0))
        {
            m_animation.SetBool("Attack", true);
        }
        else
        {
            m_animation.SetBool("Attack", false);
        }

        // 攻撃中なら更新しない
        if (m_animation.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return false;
        }

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
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

        return true;
    }

    // キャラクターの回転
    void UpdateRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 前フレームとの差分
        Vector3 diff =  m_rigidbody.position - m_oldPos;

        // 正規化
        diff.Normalize();

        // キャラクターが止まっているとき
       if(diff.x != 0.0f && diff.z != 0.0f)
        {
            // カメラの回転に合わせてプレイヤーも回転させる
            m_rigidbody.transform.rotation = Quaternion.LookRotation(new Vector3(diff.x, 0, diff.z));
        }

       // カメラの角度を保存 
       m_oldCameraAngle = m_camera.transform.localEulerAngles;
    }
}
