using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    GameObject warningPrefab; // 경고 이미지 오브젝트
    public float arrowSpeed = 1.0f; // 화살 이동 속도

    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    public void SetWarningImage(GameObject warning)
    {
        warningPrefab = warning;
    }

    void Update()
    {
        transform.Translate(0, -arrowSpeed * Time.deltaTime, 0);

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position; // 화살의 중심 좌표
        Vector2 p2 = this.player.transform.position; // 플레이어의 중심 좌표
        float d = Vector2.Distance(p1, p2); // 화살과 플레이어 사이의 거리


        // 플레이어와 충돌했을 때 플레이어의 체력을 감소시킴
        if (d < 0.5f) // 플레이어와의 거리가 0.5f 미만인 경우 충돌로 간주
        {
            PlayerController playerController = this.player.GetComponent<PlayerController>();
            playerController.DecreaseLives(); // 플레이어의 체력을 감소시킴
            Destroy(gameObject); // 화살 삭제
            Destroy(warningPrefab); // 경고 이미지 삭제
        }

        // 화살의 속도를 점차 빨라지게 함
        if (arrowSpeed < 5.0f)
        {
            arrowSpeed += 0.001f;
        }

    }
}
