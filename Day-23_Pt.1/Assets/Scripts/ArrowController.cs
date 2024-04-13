
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    float speed = 5.0f;
    GameObject player;

    public Image WarningImg;
    float waitTIme = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTIme > 0.0f)
        {
            waitTIme -= Time.deltaTime;
            warningDirect();
            return;
        }
        if(WarningImg.gameObject.activeSelf == true)
        {
            WarningImg.gameObject.SetActive(false);
        }

    


        transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
        if (transform.position.y < player.transform.position.y - 10.0f)
            Destroy(gameObject);
    }

    public void InitArrow(float a_PosX)
    {
        player = GameObject.Find("cat");
        transform.position = new(a_PosX * 1.1f,
                                player.transform.position.y + 10.0f, 0.0f);
        //���⼭ * 1.1f�� ȭ���� �������� ��ġ�� ������ �߾ӿ� �����ֱ� ���ؼ�...

        // ��� �̹��� ��ġ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        WarningImg.transform.position = new Vector3(screenPos.x,
            WarningImg.transform.position.y, WarningImg.transform.position.z);

        //Camera.main.ScreenToWorldPoint(screenPos); //��ũ�� ��ǥ�� ����� ��ȯ



    }

    float alpha = -6.0f;

    void warningDirect()
    {
        if(WarningImg ==null)
        {
            return;
        }

        if(WarningImg.color.a <= 0.0f)
        {
            alpha = 6.0f;
        }
        else if(WarningImg.color.a >= 1.0f)
        {
            alpha = -6.0f;
        }

        WarningImg.color = new Color(1, 1, 1, WarningImg.color.a + alpha * Time.deltaTime);

    }

}
