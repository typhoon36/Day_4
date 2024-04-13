using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Ready = 0,    //�÷��̾ ��߼��� �ִ� ����
    MoveIng = 1,  //�����̴� ����
    GameENd = 2   //��� ��������
}
public class PlayerData
{
    public int m_Index = 0; //������� ��ȣ
    public float m_SvLen = 0.0f; //�� ��߰Ÿ� ����� ����
    public int m_Ranking = -1; //���̳ʽ��� ���� ������ ������ ���� �ο������ʾҴٴ� �ǹ�.(��ŷ����)
}


public class GameDirector : MonoBehaviour
{
    public static GameState s_State = GameState.Ready;//�ΰ��� ��𼭳� ���������ϵ��� ����.-static���� ����ԵǸ� �޸𸮰� ��� �����Ǿ��־ ��ŸƮ���� �ʱ�ȭ�� �������

    public Button ReplayBtn;


    GameObject car;
    GameObject flag;
    GameObject distanceText;

    float m_Length = 0.0f; //�÷��� ���� ������ �Ÿ� ����� ����

    public Text[] PlayerUI;
    [HideInInspector] public int PlayerCount = 0;
    //0 �϶� player 1�� �÷��� ��
    //1�Ͻ� 2��
    //2�Ͻ� 3.

    //���� ��߱����� �Ÿ��� �����ϱ����� ����Ʈ
    //���� ����뵵�� ����
    List<PlayerData> m_playerList = new List<PlayerData>();



    // Start is called before the first frame update
    void Start()
    {
        s_State = GameState.Ready; //���⼭ ���¸� �ʱ�ȭ ����


        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distanceText = GameObject.Find("Distance"); // �̵� �Ÿ��� ǥ���� UI �ؽ�Ʈ


        if (ReplayBtn != null)
            ReplayBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GameScene");
            });

    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        length = Mathf.Abs(length); //���밪 �Լ� //if(length < 0.0f) length = -length;
        this.distanceText.GetComponent<Text>().text = "��ǥ �Ÿ� : " + length.ToString("F2") + "m";
        m_Length = length; //��������� �����ؼ� �� �����Ӹ��� ������ �����ʾƵ� ��.(��� ��ü�� ã�ƿ;��ϴ�)
    } //update end



    public void RecordLength() //�� ������ �����ϸ� ����� ȭ�鿡 ǥ�� �� ���� ����
    {
        if (PlayerCount < PlayerUI.Length)
        {
            PlayerUI[PlayerCount].text =
                    "Player " + (PlayerCount + 1).ToString()
                    + " : " + m_Length.ToString("F2") + "m";

            PlayerData a_Node = new PlayerData();
            a_Node.m_Index = PlayerCount; //������ �ε���
            a_Node.m_SvLen = m_Length;// ��߱��� �Ÿ�
            m_playerList.Add(a_Node); //������ ������� ��߱��� �����.

            PlayerCount++;

        }

        //������ ���ߴ� �������� ���� ���� ����
        if (3 <= PlayerCount) //��� �÷��̸� �������
        {
            s_State = GameState.GameENd;

            //���� ����
            RanikingAlgorithm();
            //~���� ����

            //���÷��̹�ư Ȱ��ȭ
            if (ReplayBtn != null)
                ReplayBtn.gameObject.SetActive(true);
            //~���÷��̹�ư Ȱ��ȭ

        }

    }//RecordLength end

    //���� ���� �Լ�
    int SvLenComp(PlayerData a, PlayerData b)
    {
        return a.m_SvLen.CompareTo(b.m_SvLen); //�������� ����
    }


    private void RanikingAlgorithm()
    {
        //��߱����� �Ÿ�(m_PlayerList[0].mSvLien)�������� �������� ����
        m_playerList.Sort(SvLenComp);

        //���� �� ���

        PlayerData a_Player = null;
        for (int i = 0; m_playerList.Count > i ; i++)
        {

            a_Player = m_playerList[i];

            if (PlayerUI.Length <= a_Player.m_Index)
                continue;
            a_Player.m_Ranking = i + 1; //��ŷ ����


            //UIǥ��
            PlayerUI[a_Player.m_Index].text =
                "Player" + (a_Player.m_Index + 1).ToString() +  //�÷��̾� 123
                 " : " + a_Player.m_SvLen.ToString("F2") + "m " +
                a_Player.m_Ranking.ToString() + " �� " ;
        }//for�� end




    }


}
