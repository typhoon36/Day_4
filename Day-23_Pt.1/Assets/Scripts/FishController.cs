using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    // �÷��̾� ������Ʈ�� ������ ����
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // �÷��̾� ������Ʈ�� ã�� player ������ �Ҵ�
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        // �÷��̾ ȭ�� ������ ������ �ı�
        if(transform.position.y < player.transform.position.y- 10.0f)
            Destroy(gameObject);
        //~�÷��̾ ȭ�� ������ ������ �ı�

    }
}
