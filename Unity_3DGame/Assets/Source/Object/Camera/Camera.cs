using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour
{
    // ターゲット
    public Transform m_target;
    // 相対座標
    private Vector3 offset;
    // 注視点の高さ
    public float m_height = 0.3f;
    // カメラとプレイヤーとの距離
    public float m_distanceToPlayer = 2.0f;
    // カメラを横にスライドさせる；プラスの時右へ，マイナスの時左へ
    public float m_slideDistance = 0f;       

    void Start()
    {
        //自分自身とtargetとの相対距離を求める
        offset = GetComponent<Transform>().position - m_target.position;
        offset.y += 0.2f;
    }

    void Update()
    {
        float RotationSensitivity = 150.0f;
       
        float rotX = Input.GetAxis("Mouse X") * Time.deltaTime * RotationSensitivity;
        float rotY = Input.GetAxis("Mouse Y") * Time.deltaTime * RotationSensitivity;
        rotY *= -1f;

        Vector3 lookAt = m_target.position + Vector3.up * m_height;

        if (Input.GetMouseButton(1))
        {
            // 回転
            transform.RotateAround(lookAt, Vector3.up, rotX);

            // カメラがプレイヤーの真上や真下にあるときにそれ以上回転させないようにする
            if (transform.forward.y > 0.9f && rotY < 0)
            {
                rotY = 0;
            }
            if (transform.forward.y < -0.9f && rotY > 0)
            {
                rotY = 0;
            }
            transform.RotateAround(lookAt, transform.right, rotY);

        }

        // カメラとプレイヤーとの間の距離を調整
        transform.position = lookAt - transform.forward * m_distanceToPlayer;

        // 注視点の設定
        transform.LookAt(lookAt);

        // カメラを横にずらして中央を開ける
        transform.position = transform.position + transform.right * m_slideDistance;

        // 自分自身の座標に、targetの座標に相対座標を足した値を設定する
   //     GetComponent<Transform>().position = m_target.position + offset;
    //    GetComponent<Transform>().transform.rotation = Quaternion.Euler(0, m_target.transform.localEulerAngles.y, 0);
    }
}
