using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//델리케이트 함수 (c,c++ 함수 포인터)  :대리자 함수


public class DLT_Class
{
    public delegate void DLT_StrType(string c); //데이터형 선언
    static DLT_StrType DltStrMtd;  //변수선언(소켓)

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
    delegate int DLT_Type(int x); // 데이터형 선언 
    DLT_Type DltMethod;           //변수 선언


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
        Debug.Log(a_Name + "님이(가) 스턴 스킬을 사용하셨습니다.");
    }

    void Skill_2(string a_Name)
    {
        Debug.Log(a_Name + "님 이(가) 흡혈 스킬 사용.");

    }
    
    void Skill_3(string a_Name) 
    {
        Debug.Log(a_Name + "님 이(가) 도끼 휘두르기 스킬 사용.");
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


        m_TempBtn.onClick.AddListener(TempClick); //유니티 제공함수
        ABC.Sort(MyComp); //유니티 제공 함수
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
            DLT_Class.PrintTest("전사");
        }

    }



}
