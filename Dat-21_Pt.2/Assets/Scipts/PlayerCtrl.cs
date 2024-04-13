using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpPower = 680.0f;

    // 애니메이터
    Animator animator;

   float walkForce = 30.0f; //걷기 
   float maxWalkSpeed = 2.0f; //최대 걷기 속도
   //float threshold = 0.2f; //속도 제한


    // Start is called before the first frame update
    void Start()
    {
        Application. targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();//애니메이터 연ㅁ결 
    }

    // Update is called once per frame
    void Update()
    {


      //점프
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpPower);
        }



        //핸드폰
        if (Input.GetKeyDown(0) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger"); //점프 애니메이션
            this.rigid2D.AddForce(transform.up * this.jumpPower);
        }
        //~핸드폰



        //좌우이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        //~좌우이동


        ////핸드폰 좌우이동
        //int key = 0;
        //if (Input.acceleration.x > this.threshold) key = 1;
        //if (Input.acceleration.x < -this.threshold) key = -1;
        ////~핸드폰 좌우이동


        //플레이어 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x); 
        //~플레이어 속도


        //+속도 제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        //~속도 제한

        //+ 움직이는 방향에  따라 반전

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        //~ 움직이는 방향에 따라 반전

        //플레이어 속도에 따라 애니메이션 속도 조절
        this.animator.speed = speedx / 2.0f;


        //플레이어의 속도에 맞춰 애니메이션 속도를 바꿈
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }


        //플레이어가 화면 밖으로 나갔을 때
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
        //처음부터 다시



  
    }
    //+ 골 도착
    void OnTriggerEnter2D(Collider2D other)
    {
      
        //Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
    //~골 도착

}
