using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{

    GameObject hpGauge;

    public Image GG_Dis;
    public Button ReplayBtn;

    // Start is called before the first frame update
    void Start()
    {
        
        this.hpGauge = GameObject.Find("hpGauge");

        if (ReplayBtn != null)
            ReplayBtn.onClick.AddListener(ResetGame);


    }

    public void DecreaseHp()
    {
        hpGauge.GetComponent<Image>().fillAmount -= 0.1f;


        if (hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            GG_Dis.gameObject.SetActive(true);

            Time.timeScale = 0; // ���� �Ͻ� ����


        }

    }


    public void InCreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount += 0.1f;
    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �ٽ� �ε��Ͽ� ���� ����
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   
}
