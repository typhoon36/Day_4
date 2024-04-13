using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    GameObject player;
    [HideInInspector] public float m_DownSpeed = -0.1f;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, m_DownSpeed, 0);

        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        //충돌판정
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;

        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if(d< r1+ r2)
        {
            //충돌시 사과 소멸
            Destroy(gameObject) ;
            //감독 스크립트에 사과와 플레이어가 충돌했다고 알림.
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().add_Gold();


        }
        //~충돌판정

    }
}
