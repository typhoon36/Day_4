using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems; //UI 조작 네임스페이스로 선언
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameMgr : MonoBehaviour
{
    //----------UI 관련 변수
    [HideInInspector] public int m_NumCount = 0; //로또 번호 인덱스 카운트용 변수
    public Text[] NumberTexts; //로또 번호 표시 UI연결용 변수

    public Button Reset_Btn = null;

    //~변수



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

    public static bool IsPointerOverUIObject() //UGUI의 UI들이 먼저 피킹되는지 확인하는 함수
    {
        PointerEventData a_EDCurPos = new PointerEventData(EventSystem.current); //현재의 이벤트 시스템을 가져오라 선언

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID) //핸드폰에선 아래에 체크

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
        a_EDCurPos.position = Input.mousePosition; //현재 이벤트 시스템의 위치를 포지션 가져다줌.
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(a_EDCurPos, results);//마우스 좌표를 넘겨서 z축 레이
        return (0 < results.Count);
#endif
    }//public bool IsPointerOverUIObject() 


}
