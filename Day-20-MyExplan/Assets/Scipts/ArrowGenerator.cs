using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float initialSpan = 1.0f; // 초기 생성 간격
    float minSpan = 0.1f; // 최소 생성 간격
    float delta = 0;

    void Start()
    {
        //Time.timeScale = 2.0f; // 초기 속도 설정
    }

    void Update()
    {
        // 생성 간격을 시간이 지날수록 줄임
        //float currentSpan = Mathf.Lerp(initialSpan, minSpan, Time.time / 60f);
        delta += Time.deltaTime;
        if (delta >initialSpan)
        {
            delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }

        initialSpan -= Time.deltaTime * 0.02f;
        if(initialSpan <= minSpan)
        {
            initialSpan = minSpan;
        }
    }
}
