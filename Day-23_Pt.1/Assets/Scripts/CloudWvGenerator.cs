using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWvGenerator : MonoBehaviour
{
    public GameObject CloudWave;
    GameObject player;
    float createHeight = 10.0f;
    float recentHeight = -2.5f; //마지막 생성된 구름층의 높이

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cat");

        //for(int ii = 0; ii < 50; ii++)
        //{
        //    SpawnCloudWave(recentHeight);
        //    recentHeight += 2.5f;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position;

        //일정 높이에 구름층 생성
        if(recentHeight < playerPos.y + createHeight)
        {
            SpawnCloudWave(recentHeight);
            recentHeight += 2.5f;
        }

    }//void Update()

    void SpawnCloudWave(float a_Height)
    {
        int a_HideCount = 0;
        if (a_Height < 15.0f)
            a_HideCount = 0;
        else if(a_Height < 30.0f)
            a_HideCount = Random.Range(0, 2);  // 0 ~ 1
        else if(a_Height < 45.0f)
            a_HideCount = Random.Range(0, 3);  // 0 ~ 2
        else if (a_Height < 60.0f)
            a_HideCount = Random.Range(1, 3);  // 1 ~ 2
        else if (a_Height < 75.0f)
            a_HideCount = Random.Range(1, 4);  // 1 ~ 3
        else
            a_HideCount = Random.Range(2, 4);  // 2 ~ 3

        GameObject go = Instantiate(CloudWave);
        go.transform.position = new Vector3(0.0f, a_Height, 0.0f);
        go.GetComponent<CloudWaveCtrl>().SetHideCloud(a_HideCount);
    }
}
