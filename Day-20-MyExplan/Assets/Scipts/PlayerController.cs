using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int Gold = 0; //��� ���� �߰�

    public Text Gold_Text;

    public Image GG_Dis;

    public void GG()
    {
        GG_Dis.gameObject.SetActive(true); // GG_Dis Ȱ��ȭ
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//60������ ����

        QualitySettings.vSyncCount = 0; //�ֻ���
    }

    // Update is called once per frame
    void Update()
    {
        //���� ȭ��ǥ�� ��������

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3, 0, 0);//�������� 3�����δ�
        }

        //������ ȭ��ǥ�� ��������

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.Translate(3, 0, 0); //���������� 3 �����δ�.

        }


       

    }

    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(3, 0, 0);
    }

    public void EatAp()
    {
        Gold++;

        Gold_Text.text = "Gold : " + Gold;
    }

   

}
