using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulletteController : MonoBehaviour
{
    float rotSpeed = 0; //회전 스피드

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60; 
        //어플리케이션 회전속도 설정을 60으로-->프레임 제어 속도로 보면 된다.
        //즉,1초에 60프레임을 렌더링하도록 강제시킨다.(보통의 게임 프레임)
        QualitySettings.vSyncCount = 0;
        //화면 주사율이 다른 모니터일경우 캐릭터 조작시 빠르게 움직일수 있음.

    }

    // Update is called once per frame
    void Update()
    {
        //유니티 메뉴얼을 보면 0이면 왼쪽 1이면 오른쪽 2면 휠
        if (Input.GetMouseButton(0)) 
        {
            this.rotSpeed = 10;
        }
        //회전 속도 설정
        transform.Rotate(0, 0, this.rotSpeed);

        //transform.transform.localRotation = Quaternion.Euler(0, 0, 0); 잘못된 예


        //25줄과 같은 동작이다.
        //eulerAngles.z ; 0~359.9999까지 값을 환산해서 전달해준다.

        //Vector3 a_Rot = transform.transform.eulerAngles;
        // a_Rot.z += this.rotSpeed;
        // transform.transform.eulerAngles = a_Rot;
        //~25줄과 같은 동작들



        //감속시키기
        this.rotSpeed *= 0.98f; //10 *0.98 이면 감속하게됨.감쇠곡선




    }
}
