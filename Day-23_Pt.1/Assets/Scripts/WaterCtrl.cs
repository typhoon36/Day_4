using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCtrl : MonoBehaviour
{
    GameObject player;
    float speed = 1.0f; //1�ʿ� 1m�� �����̰� �Ѵٴ� �ӵ�
    float distanceItv = 8.0f;   //���ΰ����� �Ÿ��� 8m �̻� �������� �ʵ���...

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        //Player�� �Ÿ��� �ʹ� �� ��� ����
        float a_FollowHeight = player.transform.position.y - distanceItv;
        if (transform.position.y < a_FollowHeight)
            transform.position = new Vector3(0.0f, a_FollowHeight, 0.0f);

        //���� �ӵ��� ���� �����̰�...
        transform.Translate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f));
    }
}
