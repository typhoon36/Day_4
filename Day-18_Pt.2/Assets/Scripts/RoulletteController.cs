using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulletteController : MonoBehaviour
{
    float rotSpeed = 0; //ȸ�� ���ǵ�

    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 60; 
        //���ø����̼� ȸ���ӵ� ������ 60����-->������ ���� �ӵ��� ���� �ȴ�.
        //��,1�ʿ� 60�������� �������ϵ��� ������Ų��.(������ ���� ������)
        QualitySettings.vSyncCount = 0;
        //ȭ�� �ֻ����� �ٸ� ������ϰ�� ĳ���� ���۽� ������ �����ϼ� ����.

    }

    // Update is called once per frame
    void Update()
    {
        //����Ƽ �޴����� ���� 0�̸� ���� 1�̸� ������ 2�� ��
        if (Input.GetMouseButton(0)) 
        {
            this.rotSpeed = 10;
        }
        //ȸ�� �ӵ� ����
        transform.Rotate(0, 0, this.rotSpeed);

        //transform.transform.localRotation = Quaternion.Euler(0, 0, 0); �߸��� ��


        //25�ٰ� ���� �����̴�.
        //eulerAngles.z ; 0~359.9999���� ���� ȯ���ؼ� �������ش�.

        //Vector3 a_Rot = transform.transform.eulerAngles;
        // a_Rot.z += this.rotSpeed;
        // transform.transform.eulerAngles = a_Rot;
        //~25�ٰ� ���� ���۵�



        //���ӽ�Ű��
        this.rotSpeed *= 0.98f; //10 *0.98 �̸� �����ϰԵ�.����




    }
}
