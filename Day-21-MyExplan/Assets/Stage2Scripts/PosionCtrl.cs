using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionCtrl : MonoBehaviour
{
    public float PosionRiseSpeed = 0.1f; // 물 상승 속도
    public float maxHeight = 10f; // 최대 물 높이
    public float damageInterval = 1f; // 플레이어가 물에 닿을 때마다 입히는 데미지 간격
    public int damageAmount = 1; // 플레이어에게 입히는 데미지 양

    private float lastDamageTime; // 마지막으로 플레이어에게 데미지를 입힌 시간

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 물의 높이를 상승시킴
        transform.Translate(Vector3.up * PosionRiseSpeed * Time.deltaTime);

        // 물의 높이가 최대 높이를 초과하면 최대 높이로 고정
        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // 충돌한 오브젝트가 플레이어인 경우
        if (other.CompareTag("Player"))
        {
            // damageInterval 이상의 시간이 지나면 생명을 깎음
            if (Time.time - lastDamageTime > damageInterval)
            {
                other.GetComponent<PlayerController>().DecreaseLives(); // 플레이어의 생명 감소
                lastDamageTime = Time.time; // 마지막 데미지 시간 업데이트
            }
        }
    }

}
