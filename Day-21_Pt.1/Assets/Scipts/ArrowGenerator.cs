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

    float m_DwSpeedCtrl = -0.1f; //��ü ���ϼӵ� ���� ����

     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���̵� ����
        m_DwSpeedCtrl -= (Time.deltaTime * 0.005f); //���ϼӵ� �������ϱ�
        if (m_DwSpeedCtrl < -0.3f)
            m_DwSpeedCtrl = -0.3f;
        span -= (Time.deltaTime * 0.03f);
        if (span < 0.1f)
            span = 0.1f;
        //~���̵� ����

        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = null; //go= ���ӿ�����Ʈ
            int dice = Random.Range(1, 11);
            if(dice <= this.ratio)
            {
                //����� ����

                go = Instantiate(applePrefab);

                go.GetComponent<AppleController>().m_DownSpeed = m_DwSpeedCtrl;

            }

            else
            {
               go = Instantiate(arrowPrefab);

                go.GetComponent<ArrowController>().m_DownSpeed = m_DwSpeedCtrl;//�ַο���Ʈ�ѿ� ����� speed�� ���ϼӵ� �ҷ�����

            }
            
           

            int px = Random.Range(-8, 9);
            //8���͸� ������ ���ؼ� �ٽ� ����(-8~8)
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
