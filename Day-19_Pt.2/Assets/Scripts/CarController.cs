using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;

    Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        QualitySettings.vSyncCount = 0;
        //모니터 Hz(주사율)이 다른 컴퓨터 일경우 캐릭 조작시 빠르게 움직일수있다.

    }

    // Update is called once per frame
    void Update()
    {

        //if(Input.GetMouseButton(0)) //마우스 클릭하면
        //{
        //    this.speed = 0.2f;   //처음속도를 설정한다.
        //}


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
        }




        transform.Translate(this.speed, 0 , 0); //이동 //포지션값을 누적 (translate)

        // transform.position += Vector3.a_Pos(this.speed , 0 ,0)


        this.speed *= 0.98f; //감속


    }
}
