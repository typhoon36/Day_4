using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosionCtrl : MonoBehaviour
{
    public float PosionRiseSpeed = 0.1f; // �� ��� �ӵ�
    public float maxHeight = 10f; // �ִ� �� ����
    public float damageInterval = 1f; // �÷��̾ ���� ���� ������ ������ ������ ����
    public int damageAmount = 1; // �÷��̾�� ������ ������ ��

    private float lastDamageTime; // ���������� �÷��̾�� �������� ���� �ð�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���̸� ��½�Ŵ
        transform.Translate(Vector3.up * PosionRiseSpeed * Time.deltaTime);

        // ���� ���̰� �ִ� ���̸� �ʰ��ϸ� �ִ� ���̷� ����
        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // �浹�� ������Ʈ�� �÷��̾��� ���
        if (other.CompareTag("Player"))
        {
            // damageInterval �̻��� �ð��� ������ ������ ����
            if (Time.time - lastDamageTime > damageInterval)
            {
                other.GetComponent<PlayerController>().DecreaseLives(); // �÷��̾��� ���� ����
                lastDamageTime = Time.time; // ������ ������ �ð� ������Ʈ
            }
        }
    }

}
