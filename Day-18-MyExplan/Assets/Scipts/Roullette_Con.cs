using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulette_Con : MonoBehaviour
{
    float rotSpeed = 0; // ȸ�� �ӵ�
    int a_Num = 0;
    float RotZ = 0.0f;
    bool isRotating = false; // ȸ�� ������ ���θ� ��Ÿ���� ����

    public Image m_PwBarImg = null;

    public Text PwText;
    public Text Title_Text;

    public Image Rolltry_Num_1 = null;
    public Text Num1_Text;
    public Image Rolltry_Num_2 = null;
    public Text Num2_Text;
    public Image Rolltry_Num_3 = null;
    public Text Num3_Text;
    public Image Rolltry_Num_4 = null;
    public Text Num4_Text;
    public Image Rolltry_Num_S = null;
    public Text NumS_Text;

    public Button ResetBtn;

    private Text fixedText; // ���� ������ �ؽ�Ʈ

    // ���� ������ �ؽ�Ʈ�� �ε���
    int fixedTextIndex = 0;

    // ��� ���� �ؽ�Ʈ�� ������� �����ϴ� �迭
    Text[] fixedTexts = new Text[4];


    // ���� ���� �� ȣ��Ǵ� �Լ�
    void Start()
    {
        ResetBtn.onClick.AddListener(ResetBtn_Click);


        // ���� �ؽ�Ʈ �迭 �ʱ�ȭ
        fixedTexts[0] = Num1_Text;
        fixedTexts[1] = Num2_Text;
        fixedTexts[2] = Num3_Text;
        fixedTexts[3] = Num4_Text;

        Application.targetFrameRate = 60; // ������ �ӵ� ����
        QualitySettings.vSyncCount = 0;

        fixedText = Num1_Text; // Num1_Text�� �ʱ� ���� �ؽ�Ʈ�� ����
    }

    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    void Update()
    {
        // ���콺 ���� ��ư�� ���� ������ ��
        if (Input.GetMouseButton(0))
        {
            this.rotSpeed = 10; // ȸ�� �ӵ� ����
            isRotating = true; // ȸ�� �� ���� ����
        }
        // ���콺 ���� ��ư�� ������ �����̰� ȸ�� �ӵ��� ���� ����� ���� ��
        else if (Mathf.Abs(this.rotSpeed) > 0.01f)
        {
            this.rotSpeed *= 0.98f; // ȸ�� �ӵ� ����
        }
        // ���콺 ���� ��ư�� ������ �����̰� ȸ�� �ӵ��� ����� �������� ��
        else
        {
            isRotating = false; // ȸ�� �� ���� ����
        }

        // ȸ�� ���� ��
        if (isRotating)
        {
            transform.Rotate(0, 0, this.rotSpeed); // �� ȸ��

            // Z�� ���� ���� ȸ�� ���� ���
            RotZ = transform.eulerAngles.z;

            // ȸ�� ������ ���� ��� ��ȣ ����
            if (18.3 <= RotZ && RotZ < 56)
                a_Num = 8;
            else if (56 <= RotZ && RotZ < 90.6)
                a_Num = 9;
            else if (90.6 <= RotZ && RotZ < 126.1)
                a_Num = 0;
            else if (142 <= RotZ && RotZ < 162.2)
                a_Num = 1;
            else if (162.2 <= RotZ && RotZ < 198.5)
                a_Num= 2;
            else if (198.5 <= RotZ && RotZ < 233.8)
                a_Num = 3;
            else if (233.8 <= RotZ && RotZ < 269.1)
                a_Num = 4;
            else if (269.1 <= RotZ && RotZ < 304.4)
                a_Num = 5;
            else if (304.4 <= RotZ && RotZ < 339.7)
                a_Num = 6;
            else
                a_Num = 7;

            this.rotSpeed *= 0.98f; // ����

            m_PwBarImg.fillAmount = rotSpeed / 10.0f; // ���� �� ������Ʈ

            // ȸ�� �Ϸ� �Ŀ��� ���� ������ �ؽ�Ʈ ������Ʈ
            if (Mathf.Abs(this.rotSpeed) < 0.01f)
            {
                UpdateFixedText();
            }
        }
    }

    // ���� ������ �ؽ�Ʈ ������Ʈ �Լ�
    void UpdateFixedText()
    {
        // ���� ������ �ؽ�Ʈ�� ���� ��ȣ ǥ��
        fixedTexts[fixedTextIndex].text = a_Num.ToString();

        // ���� �� ȸ���� ���� ���� �ؽ�Ʈ ����
        fixedTextIndex = (fixedTextIndex + 1) % 4;
    }

    void ResetBtn_Click()
    {
        Num1_Text.text = "0";
        Num2_Text.text = "0";
        Num3_Text.text = "0";
        Num4_Text.text = "0";
       
    }


}
