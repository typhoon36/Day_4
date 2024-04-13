using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulette_Con : MonoBehaviour
{
    float rotSpeed = 0; // 회전 속도
    int a_Num = 0;
    float RotZ = 0.0f;
    bool isRotating = false; // 회전 중인지 여부를 나타내는 변수

    public Image m_PwBarImg = null;

    public Text PwText;
    public Text Title_Text;

    public Image Rolltry_Num_1 = null;
    public Text Num1_Text;
    public Image Rolltry_Num_2 = null;
    public Text Num2_Text;
    public Image Rolltry_Num_3 = null;
    public Text Num3_Text;
    public Image Rolltry_Num_4 = null;
    public Text Num4_Text;
    public Image Rolltry_Num_S = null;
    public Text NumS_Text;

    public Button ResetBtn;

    private Text fixedText; // 현재 고정된 텍스트

    // 현재 고정된 텍스트의 인덱스
    int fixedTextIndex = 0;

    // 모든 고정 텍스트를 순서대로 저장하는 배열
    Text[] fixedTexts = new Text[4];


    // 게임 시작 시 호출되는 함수
    void Start()
    {
        ResetBtn.onClick.AddListener(ResetBtn_Click);


        // 고정 텍스트 배열 초기화
        fixedTexts[0] = Num1_Text;
        fixedTexts[1] = Num2_Text;
        fixedTexts[2] = Num3_Text;
        fixedTexts[3] = Num4_Text;

        Application.targetFrameRate = 60; // 프레임 속도 설정
        QualitySettings.vSyncCount = 0;

        fixedText = Num1_Text; // Num1_Text를 초기 고정 텍스트로 설정
    }

    // 매 프레임마다 호출되는 함수
    void Update()
    {
        // 마우스 왼쪽 버튼이 눌린 상태일 때
        if (Input.GetMouseButton(0))
        {
            this.rotSpeed = 10; // 회전 속도 유지
            isRotating = true; // 회전 중 상태 설정
        }
        // 마우스 왼쪽 버튼이 떼어진 상태이고 회전 속도가 아직 충분히 높을 때
        else if (Mathf.Abs(this.rotSpeed) > 0.01f)
        {
            this.rotSpeed *= 0.98f; // 회전 속도 감소
        }
        // 마우스 왼쪽 버튼이 떼어진 상태이고 회전 속도가 충분히 낮아졌을 때
        else
        {
            isRotating = false; // 회전 중 상태 해제
        }

        // 회전 중일 때
        if (isRotating)
        {
            transform.Rotate(0, 0, this.rotSpeed); // 휠 회전

            // Z축 기준 현재 회전 각도 얻기
            RotZ = transform.eulerAngles.z;

            // 회전 각도에 따라 결과 번호 결정
            if (18.3 <= RotZ && RotZ < 56)
                a_Num = 8;
            else if (56 <= RotZ && RotZ < 90.6)
                a_Num = 9;
            else if (90.6 <= RotZ && RotZ < 126.1)
                a_Num = 0;
            else if (142 <= RotZ && RotZ < 162.2)
                a_Num = 1;
            else if (162.2 <= RotZ && RotZ < 198.5)
                a_Num= 2;
            else if (198.5 <= RotZ && RotZ < 233.8)
                a_Num = 3;
            else if (233.8 <= RotZ && RotZ < 269.1)
                a_Num = 4;
            else if (269.1 <= RotZ && RotZ < 304.4)
                a_Num = 5;
            else if (304.4 <= RotZ && RotZ < 339.7)
                a_Num = 6;
            else
                a_Num = 7;

            this.rotSpeed *= 0.98f; // 감속

            m_PwBarImg.fillAmount = rotSpeed / 10.0f; // 진행 바 업데이트

            // 회전 완료 후에는 현재 고정된 텍스트 업데이트
            if (Mathf.Abs(this.rotSpeed) < 0.01f)
            {
                UpdateFixedText();
            }
        }
    }

    // 현재 고정된 텍스트 업데이트 함수
    void UpdateFixedText()
    {
        // 현재 고정된 텍스트에 현재 번호 표시
        fixedTexts[fixedTextIndex].text = a_Num.ToString();

        // 다음 번 회전에 사용될 고정 텍스트 설정
        fixedTextIndex = (fixedTextIndex + 1) % 4;
    }

    void ResetBtn_Click()
    {
        Num1_Text.text = "0";
        Num2_Text.text = "0";
        Num3_Text.text = "0";
        Num4_Text.text = "0";
       
    }


}
