using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {

        //프레임마다 등속 낙하
        transform.Translate(0, -0.1f, 0);

        //오브젝트 소멸
        if (transform.position.y < -5.0f) //오브젝트 위치 y가 5보다 작을때
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
            //GameDirector 컴포넌트 가져오기
            GameDirector director = FindObjectOfType<GameDirector>();
            if (director != null)
            {
                director.InCreaseHp(); // 체력 증가
            }

            // PlayerController 컴포넌트 가져오기
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Gold++; // 골드 증가
                playerController.Gold_Text.text = "Gold : " + playerController.Gold; // UI 업데이트
            }

            // 현재 오브젝트 파괴
            Destroy(gameObject);
        }
    }
}
