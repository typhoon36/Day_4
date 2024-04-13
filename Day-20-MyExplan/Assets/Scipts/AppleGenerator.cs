using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGenerator : MonoBehaviour
{
    public GameObject ApplePrefab;
    public float initialSpan = 2.0f; // �ʱ� ���� ����
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f; // �ʱ� �ӵ� ����
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;

        // ���� ������ �ʱ� ���� ���ݺ��� ũ�ų� ������ ��� ����
        if (delta >= initialSpan)
        {
            GameObject go = Instantiate(ApplePrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
            delta = 0; // �ð� �ʱ�ȭ
        }
    }
}
