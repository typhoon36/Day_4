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

        //�����Ӹ��� ��� ����
        transform.Translate(0, -0.1f, 0);

        //������Ʈ �Ҹ�
        if (transform.position.y < -5.0f) //������Ʈ ��ġ y�� 5���� ������
        {
            Destroy(gameObject); //������Ʈ �Ҹ�
        }

        Vector2 p1 = transform.position;//ȭ�� �߽���ǥ
        Vector2 p2 = this.player.transform.position; //�÷��̾� �߽���ǥ
        Vector2 dir = p1 - p2; //�ڿ��� ������ ���ϴ� ���Ͱ� �Ǿ�����
        float d = dir.magnitude; //������ �ȴ�.
        float r1 = 0.5f; //ȭ��ݰ�
        float r2 = 1.0f; //�÷��̾� �ݰ�

        if (d < r1 + r2)
        {
            //GameDirector ������Ʈ ��������
            GameDirector director = FindObjectOfType<GameDirector>();
            if (director != null)
            {
                director.InCreaseHp(); // ü�� ����
            }

            // PlayerController ������Ʈ ��������
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Gold++; // ��� ����
                playerController.Gold_Text.text = "Gold : " + playerController.Gold; // UI ������Ʈ
            }

            // ���� ������Ʈ �ı�
            Destroy(gameObject);
        }
    }
}
