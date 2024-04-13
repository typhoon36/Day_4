using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoulletteController : MonoBehaviour
{
    float rotSpeed = 0; //ȸ�� ���ǵ�
    float m_MaxPower = 80.0f; //�ִ��� ����

    bool IsRotate = false;

    public Image m_PwBarImg = null;
    public Text PwText = null;
   

    GameMgr m_GameMgr = null;


    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60; 
        //���ø����̼� ȸ���ӵ� ������ 60����-->������ ���� �ӵ��� ���� �ȴ�.
        //��,1�ʿ� 60�������� �������ϵ��� ������Ų��.(������ ���� ������)
        QualitySettings.vSyncCount = 0;
        //ȭ�� �ֻ����� �ٸ� ������ϰ�� ĳ���� ���۽� ������ �����ϼ� ����.

        //GameObject a_Gobj = GameObject.Find("GameMgr");
        //if (a_Gobj != null)
        //   m_GameMgr = a_Gobj.GetComponent<GameMgr>();  //�̸� ȣ���� �Ǿ����ϱ� ȣ�Ⱑ��.
        //�ؿ� ��������� ������ �Ҽ� �ִ°���.

        m_GameMgr = GameObject.FindObjectOfType<GameMgr>();

    }

    // Update is called once per frame
    void Update()
    {
        if(m_GameMgr.NumberTexts.Length <= m_GameMgr.m_NumCount) return;
        //5�� �迭 ���Կ� ���� ä������ returnó��.(gameOver)


        if(IsRotate == false)
        {

            if(Input.GetMouseButton(0)) // ���콺�� �������ִ� ����
            {
                //this.rotSpeed = 10;

                if (GameMgr.IsPointerOverUIObject() == true)
                    return;

                this.rotSpeed += (Time.deltaTime * 50.0f); //Ʃ���Ѱ�->�����ϸ鼭 �ӵ��� ������(���谪�̶� �����).

                if(m_MaxPower < rotSpeed) 
                    rotSpeed = m_MaxPower ;
            }

            if(Input.GetMouseButtonUp(0))
            {//���콺 ���¼���
                IsRotate = true ;


            }


        }

        else
        {
            transform.Rotate(0, 0, this.rotSpeed);


            this.rotSpeed *= 0.98f; //10 *0.98 �̸� �����ϰԵ�.����

            if(this.rotSpeed <= 0.1f) //�귿�� ���� ���·� ����
            {
                this.rotSpeed = 0.0f; //�귿�� ���� �����ְ�

                IsRotate = false; //�귿�� ���� ���� �ٲ� �������������� ����Խ�Ŵ

                

                //�ٴ��� ����Ű�� ��ȣ Ȯ�� ����
                GetCurNumber();
                

            }

        }

        m_PwBarImg.fillAmount = rotSpeed / m_MaxPower;
        PwText.text = (int)(m_PwBarImg.fillAmount * 100) + " / 100"; 

        

    }

    void GetCurNumber() //�귿�� ������ �� �ٴ��� ����Ű�� �ִ� ���� ���� ������ �Լ�
    {
        // transform.eulerAngles.z : 0 ~ 359.9999f ������ ���� ȯ���ؼ� ������ �ش�.
        float a_Angle = transform.eulerAngles.z;

        int a_Num = 0;
        if (17.5f <= a_Angle && a_Angle < 54.5f)
        {
            a_Num = 8;
        }
        else if (54.5f <= a_Angle && a_Angle < 90.0f)
        {
            a_Num = 9;
        }
        else if (90.0f <= a_Angle && a_Angle < 125.5f)
        {
            a_Num = 0;
        }
        else if (125.5f <= a_Angle && a_Angle < 162.0f)
        {
            a_Num = 1;
        }
        else if (162.0f <= a_Angle && a_Angle < 198.0f)
        {
            a_Num = 2;
        }
        else if (198.0f <= a_Angle && a_Angle < 234.0f)
        {
            a_Num = 3;
        }
        else if (234.0f <= a_Angle && a_Angle < 270.0f)
        {
            a_Num = 4;
        }
        else if (270.0f <= a_Angle && a_Angle < 306.0f)
        {
            a_Num = 5;
        }
        else if (306.0f <= a_Angle && a_Angle < 342.0f)
        {
            a_Num = 6;
        }
        else
        //else if((342.0f <= a_Angle && a_Angle < 360.0f) ||
        //        (0.0f <= a_Angle && a_Angle < 17.5f))
        {
            a_Num = 7;
        }

        if(m_GameMgr != null)
          m_GameMgr.SetNumber(a_Num);


    }//void GetCurNumber()

 


}
