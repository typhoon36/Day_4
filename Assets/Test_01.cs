using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���
// if : ���ǹ�, �б⹮
// if(���ǽ�)
// {
//      ����� �ڵ�
// }
// else if(���ǽ�)
// {
//      ����� �ڵ�
// }
// else
// {
//      ����� �ڵ�
// }

// switch ~ case ��
// switch (���ǽ�)  //���ǽ� ����� ���� �� �ִ� �� : ������, ����, ���ڿ�
// {
//      case ���:
//          ����� �ڵ�;
//      break;
//
//      case ���:
//          ����� �ڵ�;
//      break;
//
//      default:    // else �� ������ ������ �ش�ȴٰ� �����ϸ� ��
//          ����� �ڵ�;
//      break;
// }

public class Test_01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 1;
        if (x == 1)
        {
            int y = 2;
            Debug.Log(x);
            Debug.Log(y);
        }

        // y = 11;  //�ڱ� �Ҽ� ����ȣ�� ����� ����Ϸ��� �߱� ������ ��������.

        x = 8;
        if (x < 5)  //if���� ����� �ڵ尡 �� ���̸� { } ������ �� �ִ�. 
            Debug.Log("x�� 5���� �۽��ϴ�.");
        else if (x < 10)
        {
            Debug.Log("x�� 5���� ũ�ų� ����");
            Debug.Log("x�� 10���� �۽��ϴ�.");
        }
        else if (x < 15)
        {
            Debug.Log("x�� 10���� ũ�ų� ����");
            Debug.Log("x�� 15���� �۽��ϴ�.");
        }
        else
            Debug.Log("x�� 15���� ũ�ų� �����ϴ�.");

        // if���� 3������ ����
        Debug.Log("---- if���� ù��° ����");
        int xyz = 15;
        if (xyz == 4)
            Debug.Log("xyz�� 4�Դϴ�.");
        if (xyz == 5)
            Debug.Log("xyz�� 5�Դϴ�.");
        if (xyz == 6)
            Debug.Log("xyz�� 6�Դϴ�.");
        if (xyz == 5)
            Debug.Log("xyz�� 5�� Ȯ���մϴ�.");

        Debug.Log("---- if�� �ι�° ����");
        if (xyz == 4)
            Debug.Log("xyz�� 4�Դϴ�.");
        else if (xyz == 5)
            Debug.Log("xyz�� 5�Դϴ�.");
        else if (xyz == 6)
            Debug.Log("xyz�� 6�Դϴ�.");
        else if (xyz == 5)
            Debug.Log("xyz�� 5�� Ȯ���մϴ�.");

        Debug.Log("---- if�� ����° ����");
        if (xyz == 4)
            Debug.Log("xyz�� 4�Դϴ�.");
        else if (xyz == 5)
            Debug.Log("xyz�� 5�Դϴ�.");
        else if (xyz == 6)
            Debug.Log("xyz�� 6�Դϴ�.");
        else
            Debug.Log("xyz�� 4, 5, 6 �� �ƴմϴ�.");

        // switch ~ case �� ����
        int a_ii = 20;
        switch (a_ii % 2)
        {
            case 0:
                Debug.Log("¦���Դϴ�.");
                break;

            case 1:
                Debug.Log("Ȧ���Դϴ�.");
                break;
        }

        if ((a_ii % 2) == 0)
            Debug.Log("¦���Դϴ�.");
        else if ((a_ii % 2) == 1)
            Debug.Log("Ȧ���Դϴ�.");

        char a_Day = '��';   //C# char���� 2byte (�ѱ� �ѱ��ڵ� ������ �� �ִ�.)
        // a_Day = '��'; --> ������ �������Դϴ�.
        // a_Day = 'ȭ'; --> ������ ȭ�����Դϴ�.
        // a_Day = '��'; --> ������ ������Դϴ�.
        // a_Day = '��'; --> �ش��ϴ� ������ ��Ȯ�� �Է��� �ּ���.
        // switch ~ case ���� if ~ else if ������ ������ ������.

        switch (a_Day)
        {
            case '��':
                Debug.Log("������ �Ͽ����Դϴ�.");
                break;

            case '��':
                Debug.Log("������ �������Դϴ�.");
                break;

            case 'ȭ':
            case '��':
                Debug.Log("������ ȭ���� �ϼ���, ������ �ϼ���...");
                //Debug.Log("������ �������Դϴ�.");
                break;

            case '��':
                Debug.Log("������ ������Դϴ�.");
                break;

            case '��':
                Debug.Log("������ �ݿ����Դϴ�.");
                break;

            case '��':
                Debug.Log("������ ������Դϴ�.");
                break;

            default:
                Debug.Log("�ش��ϴ� ������ ��Ȯ�� �Է��� �ּ���.");
                break;
        }//switch(a_Day)

        if (a_Day == '��')
            Debug.Log("������ �Ͽ����Դϴ�.");
        else if (a_Day == '��')
            Debug.Log("������ �������Դϴ�.");
        else if (a_Day == 'ȭ' || a_Day == '��')
            Debug.Log("������ ȭ���� �ϼ���, ������ �ϼ���...");
        else if (a_Day == '��')
            Debug.Log("������ ������Դϴ�.");
        else if (a_Day == '��')
            Debug.Log("������ �ݿ����Դϴ�.");
        else if (a_Day == '��')
            Debug.Log("������ ������Դϴ�.");
        else
            Debug.Log("�ش��ϴ� ������ ��Ȯ�� �Է��� �ּ���.");

    }

    // Update is called once per frame
    void Update()
    {
        // ����Ƽ �����Ϳ��� Ű���� �Է��� �� �ȸ��� �� Ȯ���� ������ ����
        // 1, GameView â�� �ѹ� Ŭ���� �ش�.
        // (����Ƽ ������ GameView â�� ��Ŀ�� ���¸� ���� ����� ����...)
        // 2, �� / �� Ű�� ������ �ִ� ���¿��� (�ѱ� �Է� ���´� �ȵȴ�.)
        // �ȵǴ� ��찡 ���� �� �ִ�.
        // (����Ű�� ���� �Է� ���¿����� ���� �Է� �޴´�.)

        // ����Ƽ C#���� �������� ������ ���
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            float a_FRd = Random.Range(0.0f, 10.0f);
            //0.0f ~ 10.0f ���� ������ ���ڸ� �߻����� ��
            Debug.Log(a_FRd);

            //int a_Rand = Random.Range(1, 7);
            ////1���� 100���� ������ ���ڸ� �߻����� ��
            //Debug.Log(a_Rand);
        }
    }
}
