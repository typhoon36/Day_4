using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    GameObject hpGauge;
    Image m_HpImg = null;
    public GameObject UI_MaskGroup;

    public Text Gold_Text;


    int m_Gold = 0;


    [Header("-------게임오버-----")]
    public GameObject GameOverPanel;
    public Text GoGoldText;
    public Button ReplayBtn;


    private void Awake()
    {
        if(UI_MaskGroup != null )
            UI_MaskGroup.SetActive( true );
    }


    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1.0f; //일시정지를 풀겠다-static이라 계속 유지되기에 초기화 먼저.

        this.hpGauge = GameObject.Find("hpGauge");

        if(this.hpGauge != null )
            m_HpImg = this.hpGauge.GetComponent<Image>();

        if (ReplayBtn != null)
            ReplayBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GameScnene");
            });

    }

    public void DecreaseHp()
    {
        if (m_HpImg == null)
            return;
        m_HpImg.fillAmount -= 0.1f;

        if(m_HpImg.fillAmount <= 0.0f) //주인공 체력 0이면
        {
            GameOverPanel.SetActive(true);
            GoGoldText.text = "Gold : " + m_Gold; //누적 골드값 갱신


            Time.timeScale = 0.0f;//일시정지

        }
    }


    public void add_Gold()
    {
        if (m_HpImg == null || Gold_Text == null)
            return;

        if (m_HpImg.fillAmount <= 0)
            return; //게임 종료

        m_Gold += 10;

        Gold_Text.text = "Gold : " + m_Gold;

    }


    // Update is called once per frame
    void Update()
    {
      
    }
}
