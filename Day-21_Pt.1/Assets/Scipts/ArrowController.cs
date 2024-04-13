using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
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

        //프레임마다 등속 낙하
        transform.Translate(0, m_DownSpeed, 0);

        //오브젝트 소멸
        if(transform.position.y < -5.0f) //오브젝트 위치 y가 5보다 작을때
        {
            Destroy(gameObject); //오브젝트 소멸
        }

        Vector2 p1 = transform.position;//화살 중심좌표
        Vector2 p2 = this.player.transform.position; //플레이어 중심좌표
        Vector2 dir = p1 - p2; //뒤에서 앞으로 향하는 벡터가 되었을때
        float d = dir.magnitude; //중점이 된다.
        float r1 = 0.5f; //화살반경
        float r2 = 1.0f; //플레이어 반경

        if (d < r1 + r2)
        {
            //감독 스크립트에 플레이어와 화살이 충돌했다고 전달.
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

            Destroy(gameObject);//충돌했을때 화살을 파괴
        }

    }
}
