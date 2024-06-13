using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 10f;
    Rigidbody rb;
    Vector3 clickPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;    // マウスのいる座標
        }   // ドラッグ開始を検出
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            // ベクトルの長さを得る            
            float size = dragVector.magnitude;
            rb.velocity = dragVector.normalized * jumpSpeed;
        }   // ドラッグしている間処理する
    }
}