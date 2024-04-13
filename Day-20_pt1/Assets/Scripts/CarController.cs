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
        //����� Hz(�ֻ���)�� �ٸ� ��ǻ�� �ϰ�� ĳ�� ���۽� ������ �����ϼ��ִ�.

        //GameObject a_Obj = GameObject.Find("GameDirector");
        //if(a_Obj != null )
        //    m_GDirector = a_Obj.GetComponent<GameDirector>();

        m_GDirector = GameObject.FindObjectOfType<GameDirector>();// ������ ������ �� ȿ���� ����.

    }

    // Update is called once per frame
    void Update()
    {

        if (GameDirector.s_State == GameState.GameENd)
            return;



        //if (m_IsMove == false) //�ڵ����� ���������� ���������ϵ���---�굵 �Ǵµ� ȿ���� �������� ���� enumȰ��
        if (GameDirector.s_State == GameState.Ready) //�ڵ����� ���������� ������ �����ϵ���
        {

            //���������� ���̸� ���Ѵ�.
            if (Input.GetMouseButtonDown(0))
            {
                this.startPos = Input.mousePosition;

            }

            else if (Input.GetMouseButtonUp(0))
            {
                //���콺 ��ư���� �հ����� �������� ��ǥ
                Vector2 endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;

                //������������ ó���ӵ��� ����
                this.speed = swipeLength / 500.0f; //Ʃ��


                GetComponent<AudioSource>().Play(); //������ҽ� �÷���.

                GameDirector.s_State = GameState.MoveIng;

            }

        }

        else if (GameDirector.s_State == GameState.MoveIng)
        {


            transform.Translate(this.speed, 0, 0); //�̵� //�����ǰ��� ���� (translate)

            // transform.position += Vector3.a_Pos(this.speed , 0 ,0)


            this.speed *= 0.98f; //����

            if (this.speed < 0.0005f) //�ڵ����� ����ٰ� ����(Ʃ�װ�) 
            {
                this.speed = 0.0f;

                //m_IsMove = false;


                GameDirector.s_State = GameState.Ready;

                //���� �÷��̰� ���� ������ ��� ����
                m_GDirector.RecordLength();
                //~���� �÷��̰� ���� ������ ��� ����
                
                //���� �÷��̾ ���� �ڵ����� ó�� ��ġ�� ����
                this.transform.position = new Vector3(-7.0f, -3.7f, 0);



            }






        }


    }//update end



} //class end
