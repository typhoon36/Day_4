using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    GameObject player;

    public Text CurHeight_Text;
    public Text BestHeight_Text;

    float m_Height = 0.0f;      //�������
    public static float m_CurBHeight = 0.0f;    //���� �ְ� ����
    public static float m_BestHeight = 0.0f;    //�ְ� ��� ����

    // Start is called before the first frame update
    void Start()
    {
        Load();

        player = GameObject.Find("cat");
        m_CurBHeight = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //-- ���̰� ���
        m_Height = player.transform.position.y;
        if (m_Height < 0.0f)
            m_Height = 0.0f;

        if (m_CurBHeight < m_Height)
            m_CurBHeight = m_Height;

        if(m_BestHeight < m_CurBHeight)
        {
            m_BestHeight = m_CurBHeight;
            Save();
        }

        if (CurHeight_Text != null)
            CurHeight_Text.text = "���� : " + m_CurBHeight.ToString("N2")+"m";

        if (BestHeight_Text != null)
            BestHeight_Text.text = "�ְ��� : " + m_BestHeight.ToString("N2")+"m";
        //-- ���̰� ���
    }

    public static void Save()
    {
        PlayerPrefs.SetFloat("HighScore", m_BestHeight);
    }

    public static void Load()
    {
        m_BestHeight = PlayerPrefs.GetFloat("HighScore", 0.0f);
    }
}
