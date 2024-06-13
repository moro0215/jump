using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDraw : MonoBehaviour
{
    /// <summary>ドラッグ開始座標</summary>
    Vector3 clickPosition;
    /// <summary>矢印の画像</summary>
    [SerializeField] UnityEngine.UI.Image arrowImage;

    void Start()
    {
        // 矢印の画像を消す
        arrowImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 矢印の画像を出す
            arrowImage.gameObject.SetActive(true);
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
            clickPosition = Input.mousePosition;    // マウスのいる座標
            // 矢印の画像をドラッグ開始位置に移動する
            arrowImage.rectTransform.position = clickPosition;
        }   // ドラッグ開始を検出
        else if (Input.GetMouseButton(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            // ベクトルの長さを得る            
            float size = dragVector.magnitude;
            // 矢印をベクトルの方向に向ける
            arrowImage.rectTransform.right = dragVector;
            // ドラッグをたくさんしたら矢印を大きくする
            arrowImage.rectTransform.sizeDelta = Vector2.one * size;
        }   // ドラッグしている間処理する
        else if (Input.GetMouseButtonUp(0))
        {
            // 矢印の画像を消す
            arrowImage.gameObject.SetActive(false);
        }
    }
}