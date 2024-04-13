using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float m_MvX = 0.0f; //�̵� ���� ����
    float m_MvSpeed = 7.0f; //�̵� �ӵ�

    bool m_IsRBtnDown = false; //�� ������ ���϶� r��ư�� ������ �ִٴ� �ǹ�.
    bool m_IsLBtnDown = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//60������ ����

        QualitySettings.vSyncCount = 0; //�ֻ���
    }

    // Update is called once per frame
    void Update()
    {
        //���� ȭ��ǥ�� ��������

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)
            || m_IsLBtnDown == true)
        {
            //transform.Translate(-3, 0, 0);//�������� 3�����δ�
            m_MvX += Time.deltaTime * (-1.0f * m_MvSpeed);
            //�ӵ� = �Ÿ� /�ð� --> �ð�*�ӵ� = �Ÿ�
            //transform.position += new Vector3(m_MvX, 0.0f, 0.0f);
            transform.Translate(m_MvX, 0.0f, 0.0f); //�� ������ ���� �����̴�.


        }

        //������ ȭ��ǥ�� ��������

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)
           || m_IsRBtnDown == true) 
        {

            //transform.Translate(3, 0, 0); //���������� 3 �����δ�.
            m_MvX += Time.deltaTime * m_MvSpeed;
            //transform.position = new Vector3(m_MvX , 0 , 0.0f);
            transform.Translate(m_MvX, 0.0f, 0.0f);

        }

        //--ĳ���Ͱ� ���� ȭ���� ��������ϰ� ���� ó��
        Vector3 a_vPos = transform.position;
        if (8.0f < a_vPos.x)
            a_vPos.x = 8.0f;


        if (a_vPos.x < -8.0f)
            a_vPos.x = -8.0f;
        transform.position = a_vPos;



    }

    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(3, 0, 0);
    }

    //event trigger ó��

    //������ �̵���ư�� ��������

    public void OnRBtnDown()
    {
        m_IsRBtnDown = true;
    }

    // ������ �̵� ��ư�� ����
    public void OnRBtnUp()
    {
        m_IsRBtnDown = false;
    }

    //���� ��ư�� ����
    public void OnLBtnUp()
    {
        m_IsLBtnDown = false;
    }
    //���� �̵� ��ư�� ������
    public void OnLBtnDown()
    {
        m_IsLBtnDown=true;
    }

}
