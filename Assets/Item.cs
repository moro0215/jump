using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //    _anim.Play("Idle");
        //}

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    _anim.Play("Get");
        //}
    }

    /// <summary>
    /// �l���A�j���[�V�����̍Đ����I�������Ă�
    /// �I�u�W�F�N�g��j������
    /// </summary>
    void OnGetAnimationFinished()
    {
        Debug.Log("�A�C�e����j�����܂�");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        Debug.Log(other.gameObject.name + " ���ڐG����");
        // _anim.Play("Get");
        _anim.SetBool("IsGet", true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " �����ꂽ");
    }
}