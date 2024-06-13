using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDraw : MonoBehaviour
{
    /// <summary>�h���b�O�J�n���W</summary>
    Vector3 clickPosition;
    /// <summary>���̉摜</summary>
    [SerializeField] UnityEngine.UI.Image arrowImage;

    void Start()
    {
        // ���̉摜������
        arrowImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���̉摜���o��
            arrowImage.gameObject.SetActive(true);
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
            clickPosition = Input.mousePosition;    // �}�E�X�̂�����W
            // ���̉摜���h���b�O�J�n�ʒu�Ɉړ�����
            arrowImage.rectTransform.position = clickPosition;
        }   // �h���b�O�J�n�����o
        else if (Input.GetMouseButton(0))
        {
            Vector3 dragVector = clickPosition - Input.mousePosition;
            // �x�N�g���̒����𓾂�            
            float size = dragVector.magnitude;
            // �����x�N�g���̕����Ɍ�����
            arrowImage.rectTransform.right = dragVector;
            // �h���b�O���������񂵂������傫������
            arrowImage.rectTransform.sizeDelta = Vector2.one * size;
        }   // �h���b�O���Ă���ԏ�������
        else if (Input.GetMouseButtonUp(0))
        {
            // ���̉摜������
            arrowImage.gameObject.SetActive(false);
        }
    }
}