using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    GameObject warningPrefab; // ��� �̹��� ������Ʈ
    public float arrowSpeed = 1.0f; // ȭ�� �̵� �ӵ�

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

        Vector2 p1 = transform.position; // ȭ���� �߽� ��ǥ
        Vector2 p2 = this.player.transform.position; // �÷��̾��� �߽� ��ǥ
        float d = Vector2.Distance(p1, p2); // ȭ��� �÷��̾� ������ �Ÿ�


        // �÷��̾�� �浹���� �� �÷��̾��� ü���� ���ҽ�Ŵ
        if (d < 0.5f) // �÷��̾���� �Ÿ��� 0.5f �̸��� ��� �浹�� ����
        {
            PlayerController playerController = this.player.GetComponent<PlayerController>();
            playerController.DecreaseLives(); // �÷��̾��� ü���� ���ҽ�Ŵ
            Destroy(gameObject); // ȭ�� ����
            Destroy(warningPrefab); // ��� �̹��� ����
        }

        // ȭ���� �ӵ��� ���� �������� ��
        if (arrowSpeed < 5.0f)
        {
            arrowSpeed += 0.001f;
        }

    }
}
