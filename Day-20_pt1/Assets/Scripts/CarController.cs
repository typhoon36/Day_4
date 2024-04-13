using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

//CarController Solve
public class CarController : MonoBehaviour
{
    float speed = 0;

    Vector2 startPos;


    //bool m_IsMove = false;

    GameDirector m_GDirector = null;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        QualitySettings.vSyncCount = 0;
        //모니터 Hz(주사율)이 다른 컴퓨터 일경우 캐릭 조작시 빠르게 움직일수있다.

        //GameObject a_Obj = GameObject.Find("GameDirector");
        //if(a_Obj != null )
        //    m_GDirector = a_Obj.GetComponent<GameDirector>();

        m_GDirector = GameObject.FindObjectOfType<GameDirector>();// 이편이 가독성 및 효율이 좋음.

    }

    // Update is called once per frame
    void Update()
    {

        if (GameDirector.s_State == GameState.GameENd)
            return;



        //if (m_IsMove == false) //자동차가 멈춰있을때 조정가능하도록---얘도 되는데 효율과 가독성을 위해 enum활용
        if (GameDirector.s_State == GameState.Ready) //자동차가 멈춰있을때 힘조정 가능하도록
        {

            //스와이프의 길이를 구한다.
            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition;

            }

            else if (Input.GetMouseButtonUp(0))
            {
                //마우스 버튼에서 손가락을 떼었을때 좌표
                Vector2 endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;

                //스와이프길이 처음속도로 변경
                this.speed = swipeLength / 500.0f; //튜닝


                GetComponent<AudioSource>().Play(); //오디오소스 플레이.

                GameDirector.s_State = GameState.MoveIng;

            }

        }

        else if (GameDirector.s_State == GameState.MoveIng)
        {


            transform.Translate(this.speed, 0, 0); //이동 //포지션값을 누적 (translate)

            // transform.position += Vector3.a_Pos(this.speed , 0 ,0)


            this.speed *= 0.98f; //감속

            if (this.speed < 0.0005f) //자동차가 멈췄다고 판정(튜닝값) 
            {
                this.speed = 0.0f;

                //m_IsMove = false;


                GameDirector.s_State = GameState.Ready;

                //지금 플레이가 끝난 유저의 기록 저장
                m_GDirector.RecordLength();
                //~지금 플레이가 끝난 유저의 기록 저장
                
                //다음 플레이어를 위해 자동차를 처음 위치로 리셋
                this.transform.position = new Vector3(-7.0f, -3.7f, 0);



            }






        }


    }//update end



} //class end
