using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMgr : MonoBehaviour
{
    public Text highScoreText;
    public Text currentScoreText;
    public Button rstBtn;
    public Button ClearDataBtn;

    // Start is called before the first frame update
    void Start()
    {
        if(GameMgr.m_BestHeight < GameMgr.m_CurBHeight)
        { GameMgr.m_BestHeight = GameMgr.m_CurBHeight;
            GameMgr.Save();
        }

        if(highScoreText != null)
            highScoreText.text = "�ְ��� : " + GameMgr.m_BestHeight.ToString("N2") + "m";
        if(currentScoreText != null)
            currentScoreText.text = "�̹���� : " + GameMgr.m_CurBHeight.ToString("N2") + "m";

        if(rstBtn != null)
            rstBtn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GameScene");
            });

        if (ClearDataBtn != null)
            ClearDataBtn.onClick.AddListener(CD_BtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void CD_BtnClick()
    {
        PlayerPrefs.DeleteAll();
        GameMgr.m_CurBHeight = 0.0f; //���尪 �ʱ�ȭ

        GameMgr.Load();

        if (highScoreText != null)
            highScoreText.text = "�ְ��� : " + GameMgr.m_BestHeight.ToString("N2") + "m";
        if (currentScoreText != null)
            currentScoreText.text = "�̹���� : " + GameMgr.m_CurBHeight.ToString("N2") + "m";


    }

}
