using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{
    public GameObject ApplePrefab;
    public float initialSpan = 2.0f; // 초기 생성 간격
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f; // 초기 속도 설정
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;

        // 생성 간격이 초기 생성 간격보다 크거나 같으면 사과 생성
        if (delta >= initialSpan)
        {
            GameObject go = Instantiate(ApplePrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
            delta = 0; // 시간 초기화
        }
    }
}
