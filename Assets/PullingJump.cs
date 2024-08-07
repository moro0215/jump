using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PullingJump : MonoBehaviour
{
    [SerializeField] float groundAngleLimit = 30;
    [SerializeField] float jumpSpeed = 10f;
    Rigidbody rigidBody;
    Vector3 clickPosition;
    /// <summary>ジャンプ可否フラグ</summary>
    bool canJump = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;    // マウスのいる座標
        }   // ドラッグ開始を検出
        else if (canJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            // ベクトルの長さを得る            
            float size = dragVector.magnitude;
            rigidBody.velocity = dragVector.normalized * jumpSpeed * 1.5f;
        }   // 離したらジャンプ

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(1);//ゲームのリセット
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // 法線をとってくる
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < groundAngleLimit)
            canJump = true;
        Debug.Log(collision.gameObject.name + " にぶつかった");
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
        Debug.Log(collision.gameObject.name + " と離れた");
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // 法線をとってくる
        float angle = Vector3.Angle(normal, Vector3.up);

        if (angle < groundAngleLimit)
            canJump = true;
        // Debug.Log("くっついている");
    }
}