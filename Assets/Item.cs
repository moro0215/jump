using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //if (input.getkeydown(keycode.v))
        //{
        //    _anim.play("idle");
        //}

        //if (input.getkeydown(keycode.c))
        //{
        //    _anim.play("get");
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
        animator.SetTrigger("Get");
        //animator.SetBool("IsGet", true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " �����ꂽ");
    }
}