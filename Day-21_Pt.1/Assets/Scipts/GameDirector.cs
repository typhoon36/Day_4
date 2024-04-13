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


    [Header("-------���ӿ���-----")]
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

        Time.timeScale = 1.0f; //�Ͻ������� Ǯ�ڴ�-static�̶� ��� �����Ǳ⿡ �ʱ�ȭ ����.

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

        if(m_HpImg.fillAmount <= 0.0f) //���ΰ� ü�� 0�̸�
        {
            GameOverPanel.SetActive(true);
            GoGoldText.text = "Gold : " + m_Gold; //���� ��尪 ����


            Time.timeScale = 0.0f;//�Ͻ�����

        }
    }


    public void add_Gold()
    {
        if (m_HpImg == null || Gold_Text == null)
            return;

        if (m_HpImg.fillAmount <= 0)
            return; //���� ����

        m_Gold += 10;

        Gold_Text.text = "Gold : " + m_Gold;

    }


    // Update is called once per frame
    void Update()
    {
      
    }
}
