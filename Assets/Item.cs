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
    /// 獲得アニメーションの再生が終わったら呼ぶ
    /// オブジェクトを破棄する
    /// </summary>
    void OnGetAnimationFinished()
    {
        Debug.Log("アイテムを破棄します");
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject);
        Debug.Log(other.gameObject.name + " が接触した");
        animator.SetTrigger("Get");
        //animator.SetBool("IsGet", true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " が離れた");
    }
}