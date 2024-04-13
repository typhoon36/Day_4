using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems; //UI ���� ���ӽ����̽��� ����
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMgr : MonoBehaviour
{
    //----------UI ���� ����
    [HideInInspector] public int m_NumCount = 0; //�ζ� ��ȣ �ε��� ī��Ʈ�� ����
    public Text[] NumberTexts; //�ζ� ��ȣ ǥ�� UI����� ����

    public Button Reset_Btn = null;

    //~����



    // Start is called before the first frame update
    void Start()
    {
        if (Reset_Btn != null)
            Reset_Btn.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("InGameScene");
            });
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetNumber(int a_Num)
    {
        if (m_NumCount < NumberTexts.Length)
        {
            NumberTexts[m_NumCount].text = a_Num.ToString();
            m_NumCount++;
        }
    }

    public static bool IsPointerOverUIObject() //UGUI�� UI���� ���� ��ŷ�Ǵ��� Ȯ���ϴ� �Լ�
    {
        PointerEventData a_EDCurPos = new PointerEventData(EventSystem.current); //������ �̺�Ʈ �ý����� �������� ����

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID) //�ڵ������� �Ʒ��� üũ

			List<RaycastResult> results = new List<RaycastResult>();
			for (int i = 0; i < Input.touchCount; ++i)
			{
				a_EDCurPos.position = Input.GetTouch(i).position;  
				results.Clear();
				EventSystem.current.RaycastAll(a_EDCurPos, results);
                if (0 < results.Count)
                    return true;
			}

			return false;
#else
        a_EDCurPos.position = Input.mousePosition; //���� �̺�Ʈ �ý����� ��ġ�� ������ ��������.
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(a_EDCurPos, results);//���콺 ��ǥ�� �Ѱܼ� z�� ����
        return (0 < results.Count);
#endif
    }//public bool IsPointerOverUIObject() 


}
