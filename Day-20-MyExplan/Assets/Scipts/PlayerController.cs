using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int Gold = 0; //골드 변수 추가

    public Text Gold_Text;

    public Image GG_Dis;

    public void GG()
    {
        GG_Dis.gameObject.SetActive(true); // GG_Dis 활성화
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//60프레임 고정

        QualitySettings.vSyncCount = 0; //주사율
    }

    // Update is called once per frame
    void Update()
    {
        //왼쪽 화살표가 눌렸을때

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-3, 0, 0);//왼쪽으로 3움직인다
        }

        //오른쪽 화살표가 눌렸을때

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.Translate(3, 0, 0); //오른쪽으로 3 움직인다.

        }


       

    }

    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(3, 0, 0);
    }

    public void EatAp()
    {
        Gold++;

        Gold_Text.text = "Gold : " + Gold;
    }

   

}
