using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGen : MonoBehaviour
{
    public GameObject arrowPrefab; // ȭ�� ������
    public GameObject warningImagePrefab; // ��� �̹��� ������
    public float span = 15.0f; // ȭ�� ���� �ֱ⸦ ó������ �� ��� ����
    public float warningTime = 2.0f; // ��� �ð�
    public float delta = 0; // �ð� ���� ����
    private GameObject player; // �÷��̾� ������Ʈ
    private GameObject currentWarningImage; // ���� ��� �̹���

    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            Vector3 arrowPosition = new Vector3(player.transform.position.x, 23, 0);

            // ���ο� ��� �̹��� �ν��Ͻ��� �����ϰ� �÷��̾�� ������ ��ġ�� ��ġ
            if (currentWarningImage != null)
            {
                Destroy(currentWarningImage); // ���� ��� �̹��� ����
            }
            currentWarningImage = Instantiate(warningImagePrefab, player.transform.position, Quaternion.identity);

            // ���� �ð� �Ŀ� ȭ�� ����
            StartCoroutine(CreateArrowAfterWarning(arrowPosition));

            // ȭ�� ���� �ֱ⸦ ���� ����
            if (span > 1.0f)
            {
                span -= 0.01f;
            }
        }
    }

    IEnumerator CreateArrowAfterWarning(Vector3 position)
    {
        // ��� �ð� ���� ���
        yield return new WaitForSeconds(warningTime);

        // ȭ�� ����
        GameObject go = Instantiate(arrowPrefab) as GameObject;
        go.transform.position = position;

        // ȭ���� �������� �����ϸ� ��� �̹����� ����
        Destroy(currentWarningImage);
    }
}
