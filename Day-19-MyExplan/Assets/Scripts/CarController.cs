using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Car_State
{
    Start,
    Move,
    Stop,
    End
}
public class Car_Ctrl : MonoBehaviour
{
    float Speed = 0;
    Vector2 startPos;

    public Car_State state = Car_State.Start;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//프레임 60 고정
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == Car_State.End)
            return;

        MouseSwipe();
        if (transform.position.x < -7.0f)
        {
            transform.position = new Vector2(-7.0f, -3.7f); //새 위치 조정
        }
    }

    void MouseSwipe()
    {
        if (state == Car_State.Start)
        {
            if (Input.GetMouseButtonDown(0))
            {
                state = Car_State.Start;
                startPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                state = Car_State.Move;
                Vector3 endPos = Input.mousePosition;
                float swipeLength = endPos.x - startPos.x;

                Speed = swipeLength / 500.0f;

                GetComponent<AudioSource>().Play();
            }
        }

        if (state == Car_State.Move)
        {
            CarMove();
        }
    }

    void CarMove() //차의 움직임 메서드
    {
        transform.Translate(Speed, 0, 0);

        Speed *= 0.98f;

        if (Speed <= 0.003)
        {
            Speed = 0.0f;
            state = Car_State.Stop;
        }
    }
}
