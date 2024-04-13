using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float initialSpan = 1.0f; // �ʱ� ���� ����
    float minSpan = 0.1f; // �ּ� ���� ����
    float delta = 0;

    void Start()
    {
        //Time.timeScale = 2.0f; // �ʱ� �ӵ� ����
    }

    void Update()
    {
        // ���� ������ �ð��� �������� ����
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
