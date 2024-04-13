using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Ready = 0,    //플레이어가 출발선에 있는 상태
    MoveIng = 1,  //움직이는 상태
    GameENd = 2   //모두 끝났을때
}
public class PlayerData
{
    public int m_Index = 0; //순서대로 번호
    public float m_SvLen = 0.0f; //각 깃발거리 저장용 변수
    public int m_Ranking = -1; //마이너스를 붙인 이유는 순위가 아직 부여되지않았다는 의미.(랭킹변수)
}


public class GameDirector : MonoBehaviour
{
    public static GameState s_State = GameState.Ready;//인게임 어디서나 쉽게접근하도록 만듬.-static으로 만들게되면 메모리가 계속 유지되어있어서 스타트에서 초기화를 해줘야함

    public Button ReplayBtn;


    GameObject car;
    GameObject flag;
    GameObject distanceText;

    float m_Length = 0.0f; //플레이 중인 유저의 거리 저장용 변수

    public Text[] PlayerUI;
    [HideInInspector] public int PlayerCount = 0;
    //0 일때 player 1이 플레이 중
    //1일시 2번
    //2일시 3.

    //각각 깃발까지의 거리를 저장하기위한 리스트
    //순위 저장용도도 포함
    List<PlayerData> m_playerList = new List<PlayerData>();



    // Start is called before the first frame update
    void Start()
    {
        s_State = GameState.Ready; //여기서 상태를 초기화 해줌


        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distanceText = GameObject.Find("Distance"); // 이동 거리를 표시할 UI 텍스트


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
        length = Mathf.Abs(length); //절대값 함수 //if(length < 0.0f) length = -length;
        this.distanceText.GetComponent<Text>().text = "목표 거리 : " + length.ToString("F2") + "m";
        m_Length = length; //멤버변수로 저장해서 매 프레임마다 일일이 하지않아도 됨.(깃발 객체를 찾아와야하니)
    } //update end



    public void RecordLength() //각 유저가 도착하면 기록을 화면에 표시 및 저장 로직
    {
        if (PlayerCount < PlayerUI.Length)
        {
            PlayerUI[PlayerCount].text =
                    "Player " + (PlayerCount + 1).ToString()
                    + " : " + m_Length.ToString("F2") + "m";

            PlayerData a_Node = new PlayerData();
            a_Node.m_Index = PlayerCount; //유저별 인덱스
            a_Node.m_SvLen = m_Length;// 깃발까지 거리
            m_playerList.Add(a_Node); //세명이 순서대로 깃발까지 멈출것.

            PlayerCount++;

        }

        //차량이 멈추는 순간마다 게임 종료 로직
        if (3 <= PlayerCount) //모두 플레이를 끝낸경우
        {
            s_State = GameState.GameENd;

            //순위 판정
            RanikingAlgorithm();
            //~순위 판정

            //리플레이버튼 활성화
            if (ReplayBtn != null)
                ReplayBtn.gameObject.SetActive(true);
            //~리플레이버튼 활성화

        }

    }//RecordLength end

    //정렬 조건 함수
    int SvLenComp(PlayerData a, PlayerData b)
    {
        return a.m_SvLen.CompareTo(b.m_SvLen); //오름차순 정렬
    }


    private void RanikingAlgorithm()
    {
        //깃발까지의 거리(m_PlayerList[0].mSvLien)기준으로 오름차순 정렬
        m_playerList.Sort(SvLenComp);

        //정리 및 출력

        PlayerData a_Player = null;
        for (int i = 0; m_playerList.Count > i ; i++)
        {

            a_Player = m_playerList[i];

            if (PlayerUI.Length <= a_Player.m_Index)
                continue;
            a_Player.m_Ranking = i + 1; //랭킹 저장


            //UI표시
            PlayerUI[a_Player.m_Index].text =
                "Player" + (a_Player.m_Index + 1).ToString() +  //플레이어 123
                 " : " + a_Player.m_SvLen.ToString("F2") + "m " +
                a_Player.m_Ranking.ToString() + " 등 " ;
        }//for문 end




    }


}
