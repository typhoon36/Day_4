using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWaveCtrl : MonoBehaviour
{
    GameObject player;
    float destroyDistance = 10.0f;  //주인공 아래쪽으로 10m

    public GameObject[] Clouds;
    public GameObject Fish; //생선 프리팹 저장

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;

        //주인공으로부터 10m 아래 거리면 파괴
        if (transform.position.y < playerPos.y - destroyDistance)
            Destroy(gameObject);
    }

    public void SetHideCloud(int a_Count)
    {   //a_Count 몇개를 보이지 않게 할 건지 개수

        List<int> active = new List<int>();
        for (int i = 0; i < Clouds.Length; i++)
        {
            active.Add(i);
        }

        for (int i = 0; i < a_Count; i++)
        {
            int ran = Random.Range(0, active.Count);
            Clouds[active[ran]].SetActive(false);

            active.RemoveAt(ran);
        }

        active.Clear();

        //active가 켜져있는 구름을 기준으로 물고기 스폰
        //for(int i = 0; i < Clouds.Length; i++)
        //{
        //    if (Clouds[i].gameObject.activeSelf == true) 
        //    {


        //    }
        //}

        int range = 10;
        SpriteRenderer[] a_Cloudobj = GetComponentsInChildren<SpriteRenderer>();
        //GetComponentsInChildren 매개변수 기본값 false
        //false : 켜져있는 객체만 가져옴
        //true : 상관없이 모든 객체 가져옴
        //그러므로 지금은 active가 켜져있는 객체(구름)만 가져옴
        for (int i = 0; i < a_Cloudobj.Length; i++)
        {
            if (Random.Range(0, range)==0)

                SpawnFish(a_Cloudobj[i].transform.position);

        }



    }

    void SpawnFish(Vector3 a_Pos)
    {
        GameObject go = Instantiate(Fish);
        go.transform.position = a_Pos + Vector3.up * 0.8f;
    }

}

