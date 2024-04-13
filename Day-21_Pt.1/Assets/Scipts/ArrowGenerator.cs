using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject applePrefab;

    float span = 1.0f;
    float delta = 0;

    int ratio = 3;

    float m_DwSpeedCtrl = -0.1f; //전체 낙하속도 제어 변수

     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //난이도 설정
        m_DwSpeedCtrl -= (Time.deltaTime * 0.005f); //낙하속도 빠르게하기
        if (m_DwSpeedCtrl < -0.3f)
            m_DwSpeedCtrl = -0.3f;
        span -= (Time.deltaTime * 0.03f);
        if (span < 0.1f)
            span = 0.1f;
        //~난이도 설정

        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = null; //go= 게임오브젝트
            int dice = Random.Range(1, 11);
            if(dice <= this.ratio)
            {
                //사과가 스폰

                go = Instantiate(applePrefab);

                go.GetComponent<AppleController>().m_DownSpeed = m_DwSpeedCtrl;

            }

            else
            {
               go = Instantiate(arrowPrefab);

                go.GetComponent<ArrowController>().m_DownSpeed = m_DwSpeedCtrl;//애로우컨트롤에 선언된 speed의 낙하속도 불러오기

            }
            
           

            int px = Random.Range(-8, 9);
            //8미터를 스폰을 안해서 다시 수정(-8~8)
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
