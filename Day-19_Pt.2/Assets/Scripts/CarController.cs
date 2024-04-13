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
        //����� Hz(�ֻ���)�� �ٸ� ��ǻ�� �ϰ�� ĳ�� ���۽� ������ �����ϼ��ִ�.

    }

    // Update is called once per frame
    void Update()
    {

        //if(Input.GetMouseButton(0)) //���콺 Ŭ���ϸ�
        //{
        //    this.speed = 0.2f;   //ó���ӵ��� �����Ѵ�.
        //}


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
        }




        transform.Translate(this.speed, 0 , 0); //�̵� //�����ǰ��� ���� (translate)

        // transform.position += Vector3.a_Pos(this.speed , 0 ,0)


        this.speed *= 0.98f; //����


    }
}
