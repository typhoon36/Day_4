using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoulletteController : MonoBehaviour
{
    float rotSpeed = 0; //회전 스피드
    float m_MaxPower = 80.0f; //최대힘 변수

    bool IsRotate = false;

    public Image m_PwBarImg = null;
    public Text PwText = null;
   

    GameMgr m_GameMgr = null;


    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60; 
        //어플리케이션 회전속도 설정을 60으로-->프레임 제어 속도로 보면 된다.
        //즉,1초에 60프레임을 렌더링하도록 강제시킨다.(보통의 게임 프레임)
        QualitySettings.vSyncCount = 0;
        //화면 주사율이 다른 모니터일경우 캐릭터 조작시 빠르게 움직일수 있음.

        //GameObject a_Gobj = GameObject.Find("GameMgr");
        //if (a_Gobj != null)
        //   m_GameMgr = a_Gobj.GetComponent<GameMgr>();  //미리 호출이 되었으니까 호출가능.
        //밑에 멤버변수로 선언을 할수 있는것임.

        m_GameMgr = GameObject.FindObjectOfType<GameMgr>();

    }

    // Update is called once per frame
    void Update()
    {
        if(m_GameMgr.NumberTexts.Length <= m_GameMgr.m_NumCount) return;
        //5개 배열 슬롯에 값이 채워지면 return처리.(gameOver)


        if(IsRotate == false)
        {

            if(Input.GetMouseButton(0)) // 마우스를 누르고있는 동안
            {
                //this.rotSpeed = 10;

                if (GameMgr.IsPointerOverUIObject() == true)
                    return;

                this.rotSpeed += (Time.deltaTime * 50.0f); //튜닝한값->조정하면서 속도를 잡은값(경험값이라 보면됨).

                if(m_MaxPower < rotSpeed) 
                    rotSpeed = m_MaxPower ;
            }

            if(Input.GetMouseButtonUp(0))
            {//마우스 떼는순간
                IsRotate = true ;


            }


        }

        else
        {
            transform.Rotate(0, 0, this.rotSpeed);


            this.rotSpeed *= 0.98f; //10 *0.98 이면 감속하게됨.감쇠곡선

            if(this.rotSpeed <= 0.1f) //룰렛이 멈춘 상태로 판정
            {
                this.rotSpeed = 0.0f; //룰렛을 완전 멈춰주고

                IsRotate = false; //룰렛이 멈춘 모드로 바꿔 힘조절가능으로 만들게시킴

                

                //바늘이 가르키는 번호 확인 로직
                GetCurNumber();
                

            }

        }

        m_PwBarImg.fillAmount = rotSpeed / m_MaxPower;
        PwText.text = (int)(m_PwBarImg.fillAmount * 100) + " / 100"; 

        

    }

    void GetCurNumber() //룰렛이 멈췄을 때 바늘이 가리키고 있는 숫자 값을 얻어오는 함수
    {
        // transform.eulerAngles.z : 0 ~ 359.9999f 까지의 값을 환산해서 전달해 준다.
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
