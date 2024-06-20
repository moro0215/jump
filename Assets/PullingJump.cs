using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    [SerializeField] float groundAngleLimit = 30;
    [SerializeField] float jumpSpeed = 10f;
    Rigidbody rb;
    Vector3 clickPosition;
    /// <summary>�W�����v�ۃt���O</summary>
    bool canJump = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;    // �}�E�X�̂�����W
        }   // �h���b�O�J�n�����o
        else if (canJump && Input.GetMouseButtonUp(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            // �x�N�g���̒����𓾂�            
            float size = dragVector.magnitude;
            rb.velocity = dragVector.normalized * jumpSpeed;
        }   // ��������W�����v
    }


    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // �@�����Ƃ��Ă���
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < groundAngleLimit)
            canJump = true;
        Debug.Log(collision.gameObject.name + " �ɂԂ�����");
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
        Debug.Log(collision.gameObject.name + " �Ɨ��ꂽ");
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;  // �@�����Ƃ��Ă���
        float angle = Vector3.Angle(normal, Vector3.up);

        if (angle < groundAngleLimit)
            canJump = true;
        // Debug.Log("�������Ă���");
    }
}