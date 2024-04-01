using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 제어문
// if : 조건문, 분기문
// if(조건식)
// {
//      실행될 코드
// }
// else if(조건식)
// {
//      실행될 코드
// }
// else
// {
//      실행될 코드
// }

// switch ~ case 문
// switch (조건식)  //조건식 결과로 나올 수 있는 값 : 정수형, 문자, 문자열
// {
//      case 상수:
//          실행될 코드;
//      break;
//
//      case 상수:
//          실행될 코드;
//      break;
//
//      default:    // else 로 끝나는 구문에 해당된다고 생각하면 됨
//          실행될 코드;
//      break;
// }

public class Test_01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 1;
        if (x == 1)
        {
            int y = 2;
            Debug.Log(x);
            Debug.Log(y);
        }

        // y = 11;  //자기 소속 종괄호를 벗어나서 사용하려고 했기 때문에 에러난다.

        x = 8;
        if (x < 5)  //if문의 실행될 코드가 한 줄이면 { } 생략할 수 있다. 
            Debug.Log("x는 5보다 작습니다.");
        else if (x < 10)
        {
            Debug.Log("x는 5보다 크거나 같고");
            Debug.Log("x는 10보다 작습니다.");
        }
        else if (x < 15)
        {
            Debug.Log("x는 10보다 크거나 같고");
            Debug.Log("x는 15보다 작습니다.");
        }
        else
            Debug.Log("x는 15보다 크거나 같습니다.");

        // if문의 3가지의 패턴
        Debug.Log("---- if문의 첫번째 패턴");
        int xyz = 15;
        if (xyz == 4)
            Debug.Log("xyz는 4입니다.");
        if (xyz == 5)
            Debug.Log("xyz는 5입니다.");
        if (xyz == 6)
            Debug.Log("xyz는 6입니다.");
        if (xyz == 5)
            Debug.Log("xyz는 5가 확실합니다.");

        Debug.Log("---- if문 두번째 패턴");
        if (xyz == 4)
            Debug.Log("xyz는 4입니다.");
        else if (xyz == 5)
            Debug.Log("xyz는 5입니다.");
        else if (xyz == 6)
            Debug.Log("xyz는 6입니다.");
        else if (xyz == 5)
            Debug.Log("xyz는 5가 확실합니다.");

        Debug.Log("---- if문 세번째 패턴");
        if (xyz == 4)
            Debug.Log("xyz는 4입니다.");
        else if (xyz == 5)
            Debug.Log("xyz는 5입니다.");
        else if (xyz == 6)
            Debug.Log("xyz는 6입니다.");
        else
            Debug.Log("xyz는 4, 5, 6 이 아닙니다.");

        // switch ~ case 문 예시
        int a_ii = 20;
        switch (a_ii % 2)
        {
            case 0:
                Debug.Log("짝수입니다.");
                break;

            case 1:
                Debug.Log("홀수입니다.");
                break;
        }

        if ((a_ii % 2) == 0)
            Debug.Log("짝수입니다.");
        else if ((a_ii % 2) == 1)
            Debug.Log("홀수입니다.");

        char a_Day = '월';   //C# char형은 2byte (한글 한글자도 저장할 수 있다.)
        // a_Day = '월'; --> 오늘은 월요일입니다.
        // a_Day = '화'; --> 오늘은 화요일입니다.
        // a_Day = '토'; --> 오늘은 토요일입니다.
        // a_Day = '글'; --> 해당하는 요일을 정확히 입렵해 주세요.
        // switch ~ case 문과 if ~ else if 문으로 구현해 보세요.

        switch (a_Day)
        {
            case '일':
                Debug.Log("오늘은 일요일입니다.");
                break;

            case '월':
                Debug.Log("오늘은 월요일입니다.");
                break;

            case '화':
            case '수':
                Debug.Log("오늘은 화요일 일수도, 수요일 일수도...");
                //Debug.Log("오늘은 수요일입니다.");
                break;

            case '목':
                Debug.Log("오늘은 목요일입니다.");
                break;

            case '금':
                Debug.Log("오늘은 금요일입니다.");
                break;

            case '토':
                Debug.Log("오늘은 토요일입니다.");
                break;

            default:
                Debug.Log("해당하는 요일을 정확히 입렵해 주세요.");
                break;
        }//switch(a_Day)

        if (a_Day == '일')
            Debug.Log("오늘은 일요일입니다.");
        else if (a_Day == '월')
            Debug.Log("오늘은 월요일입니다.");
        else if (a_Day == '화' || a_Day == '수')
            Debug.Log("오늘은 화요일 일수도, 수요일 일수도...");
        else if (a_Day == '목')
            Debug.Log("오늘은 목요일입니다.");
        else if (a_Day == '금')
            Debug.Log("오늘은 금요일입니다.");
        else if (a_Day == '토')
            Debug.Log("오늘은 토요일입니다.");
        else
            Debug.Log("해당하는 요일을 정확히 입렵해 주세요.");

    }

    // Update is called once per frame
    void Update()
    {
        // 유니티 에디터에서 키보드 입력이 잘 안먹힐 때 확인해 봐야할 사항
        // 1, GameView 창을 한번 클릭해 준다.
        // (유니티 에디터 GameView 창에 포커스 상태를 가게 만들기 위해...)
        // 2, 한 / 영 키가 눌려져 있는 상태에서 (한글 입력 상태는 안된다.)
        // 안되는 경우가 있을 수 있다.
        // (영문키는 영어 입력 상태에서만 정상 입력 받는다.)

        // 유니티 C#에서 랜덤값을 얻어오는 방법
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            float a_FRd = Random.Range(0.0f, 10.0f);
            //0.0f ~ 10.0f 까지 랜덤한 숫자를 발생시켜 줌
            Debug.Log(a_FRd);

            //int a_Rand = Random.Range(1, 7);
            ////1부터 100까지 랜덤한 숫자를 발생시켜 줌
            //Debug.Log(a_Rand);
        }
    }
}
