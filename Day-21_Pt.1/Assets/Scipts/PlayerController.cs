using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float m_MvX = 0.0f; //이동 계산용 변수
    float m_MvSpeed = 7.0f; //이동 속도

    bool m_IsRBtnDown = false; //이 변수가 참일때 r버튼을 누르고 있다는 의미.
    bool m_IsLBtnDown = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//60프레임 고정

        QualitySettings.vSyncCount = 0; //주사율
    }

    // Update is called once per frame
    void Update()
    {
        //왼쪽 화살표가 눌렸을때

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)
            || m_IsLBtnDown == true)
        {
            //transform.Translate(-3, 0, 0);//왼쪽으로 3움직인다
            m_MvX += Time.deltaTime * (-1.0f * m_MvSpeed);
            //속도 = 거리 /시간 --> 시간*속도 = 거리
            //transform.position += new Vector3(m_MvX, 0.0f, 0.0f);
            transform.Translate(m_MvX, 0.0f, 0.0f); //위 구문과 같은 구문이다.


        }

        //오른쪽 화살표가 눌렸을때

        //if (Input.GetKeyDown(KeyCode.RightArrow))
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)
           || m_IsRBtnDown == true) 
        {

            //transform.Translate(3, 0, 0); //오른쪽으로 3 움직인다.
            m_MvX += Time.deltaTime * m_MvSpeed;
            //transform.position = new Vector3(m_MvX , 0 , 0.0f);
            transform.Translate(m_MvX, 0.0f, 0.0f);

        }

        //--캐릭터가 게임 화면을 벗어나지못하게 막는 처리
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

    //event trigger 처리

    //오른쪽 이동버튼이 눌러질시

    public void OnRBtnDown()
    {
        m_IsRBtnDown = true;
    }

    // 오른쪽 이동 버튼을 뗄시
    public void OnRBtnUp()
    {
        m_IsRBtnDown = false;
    }

    //왼족 버튼을 뗄시
    public void OnLBtnUp()
    {
        m_IsLBtnDown = false;
    }
    //왼쪽 이동 버튼을 누를시
    public void OnLBtnDown()
    {
        m_IsLBtnDown=true;
    }

}
