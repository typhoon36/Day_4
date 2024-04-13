using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//��������Ʈ �Լ� (c,c++ �Լ� ������)  :�븮�� �Լ�


public class DLT_Class
{
    public delegate void DLT_StrType(string c); //�������� ����
    static DLT_StrType DltStrMtd;  //��������(����)

    public static void AddListener(DLT_StrType a_DltMtd)
    {
        DltStrMtd = a_DltMtd;
    }
    public static void PrintTest(string  a_Str)
    {
        if(DltStrMtd != null) 
        DltStrMtd(a_Str);
    }


}

public class Test_02 : MonoBehaviour
{
    delegate int DLT_Type(int x); // �������� ���� 
    DLT_Type DltMethod;           //���� ����


    int Hamsu2X(int a)
    {
        a = a * 2;
        return a;
    }

    int Hamsu3x(int a)
    {
        a = a * 3;
        return a;
    }

    int Hamsu4X(int a)
    {
        a = a * 4;
        return a;
    }

    void Skill_1 (string a_Name)
    {
        Debug.Log(a_Name + "����(��) ���� ��ų�� ����ϼ̽��ϴ�.");
    }

    void Skill_2(string a_Name)
    {
        Debug.Log(a_Name + "�� ��(��) ���� ��ų ���.");

    }
    
    void Skill_3(string a_Name) 
    {
        Debug.Log(a_Name + "�� ��(��) ���� �ֵθ��� ��ų ���.");
    }



    Button m_TempBtn;
    List<int> ABC = new List<int>();

    int MyComp(int a , int b)
    {
        return a.CompareTo(b);
    }


    void TempClick()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        DLT_Class.AddListener(Skill_1);
        //DLT_Class.AddListener(Skill_2);
        //DLT_Class.AddListener(Skill_3);


        m_TempBtn.onClick.AddListener(TempClick); //����Ƽ �����Լ�
        ABC.Sort(MyComp); //����Ƽ ���� �Լ�
    }

    int m_Index = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
           
           
            if(m_Index == 0)
                DltMethod = Hamsu2X;
            
            else if (m_Index == 1)
                DltMethod = Hamsu3x;

            else if (m_Index == 2)
                DltMethod = Hamsu4X;

            m_Index++;
            if (3 <= m_Index)
                m_Index = 0;

        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            if (DltMethod != null)
                Debug.Log(DltMethod(11));
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            DLT_Class.PrintTest("����");
        }

    }



}
