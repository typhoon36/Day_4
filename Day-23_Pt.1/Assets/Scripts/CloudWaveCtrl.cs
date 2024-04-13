using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudWaveCtrl : MonoBehaviour
{
    GameObject player;
    float destroyDistance = 10.0f;  //���ΰ� �Ʒ������� 10m

    public GameObject[] Clouds;
    public GameObject Fish; //���� ������ ����

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;

        //���ΰ����κ��� 10m �Ʒ� �Ÿ��� �ı�
        if (transform.position.y < playerPos.y - destroyDistance)
            Destroy(gameObject);
    }

    public void SetHideCloud(int a_Count)
    {   //a_Count ��� ������ �ʰ� �� ���� ����

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

        //active�� �����ִ� ������ �������� ����� ����
        //for(int i = 0; i < Clouds.Length; i++)
        //{
        //    if (Clouds[i].gameObject.activeSelf == true) 
        //    {


        //    }
        //}

        int range = 10;
        SpriteRenderer[] a_Cloudobj = GetComponentsInChildren<SpriteRenderer>();
        //GetComponentsInChildren �Ű����� �⺻�� false
        //false : �����ִ� ��ü�� ������
        //true : ������� ��� ��ü ������
        //�׷��Ƿ� ������ active�� �����ִ� ��ü(����)�� ������
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

