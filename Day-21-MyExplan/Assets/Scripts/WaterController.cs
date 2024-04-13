using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float waterRiseSpeed = 0.1f; // �� ��� �ӵ�
    public float maxHeight = 10f; // �ִ� �� ����
    public float damageInterval = 1f; // �÷��̾ ���� ���� ������ ������ ������ ����
    public int damageAmount = 1; // �÷��̾�� ������ ������ ��

    private float lastDamageTime; // ���������� �÷��̾�� �������� ���� �ð�

    private void Update()
    {
        // ���� ���̸� ��½�Ŵ
        transform.Translate(Vector3.up * waterRiseSpeed * Time.deltaTime);

        // ���� ���̰� �ִ� ���̸� �ʰ��ϸ� �ִ� ���̷� ����
        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
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

