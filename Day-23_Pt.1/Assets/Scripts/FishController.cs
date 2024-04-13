using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    // 플레이어 오브젝트를 저장할 변수
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // 플레이어 오브젝트를 찾아 player 변수에 할당
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 화면 밖으로 나가면 파괴
        if(transform.position.y < player.transform.position.y- 10.0f)
            Destroy(gameObject);
        //~플레이어가 화면 밖으로 나가면 파괴

    }
}
