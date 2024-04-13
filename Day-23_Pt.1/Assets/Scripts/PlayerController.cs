using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;
    float walkSpeed = 3.0f;

    int m_ReserveJump = 0;      // 점프 예약 변수

    float hp = 3.0f;
    public Image[] hpImage;

    GameObject m_OverlapBlock = null;
    //보상이나 화살 두세번 연속 충돌 방지

    //dash
    ParticleSystem dashParticle;
    bool isDash = false;
    float dashPower = 30.0f;
    float dashDelayTime = 1.0f;
    float dashDelay = 1.0f;
    float dashTime = 0.0f;
    float dashMaxTime= 0.1f;
    public Image dashGaugeImg;
    //~dash

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;

        this.dashParticle = GetComponentInChildren<ParticleSystem>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true) 
        {
            m_ReserveJump = 3;
        }

        //점프한다.
        if((0 < m_ReserveJump) && 
            (-0.05f <= rigid2D.velocity.y && rigid2D.velocity.y <= 0.02f) ) //&& rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0.0f);
            this.rigid2D.AddForce(transform.up * this.jumpForce);

            m_ReserveJump = 0;
        }

        if (0 < m_ReserveJump)
            m_ReserveJump--;

        //좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //플레이어의 속도
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        ////스피트 제한
        //if(speedx < this.maxWalkSpeed)
        //{
        //    this.rigid2D.AddForce(transform.right * key * this.walkForce);
        //}

        //캐릭터 이동
        rigid2D.velocity = new Vector2((key * walkSpeed), rigid2D.velocity.y);

        //움직이는 방향에 따라 반전한다.
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //플레이어 속도에 맞춰 애니메이션 속도를 바꾼다.
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //플레이어가 화면 밖으로 나갔다면 처음부터
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }

        //dash 

        if(Input.GetKeyDown(KeyCode.F))
                isDash = true;

        if (dashDelayTime < dashDelay) //dashdelay = 1.0f
        {
            dashDelayTime += Time.deltaTime;
            isDash = false;
        }
        else //쿨타임이 돌지않을때
        {
            if(isDash == true)
            {
                dashParticle.Play();
                dashTime += Time.deltaTime;
                if(dashTime <= dashMaxTime) //dashMatime == 0.1f //0.1초 동안 만 밀어주기
                {
                    this.rigid2D.velocity = transform.right * transform.localScale.x * dashPower;
                
                }
                else
                {
                    isDash = false;
                    dashDelayTime = 0.0f;
                    dashTime = 0.0f;
                }


            }
        }

        dashGaugeImg.fillAmount = dashDelayTime / dashDelay;

        //~dash


        //--- 화면 밖으로 못 나가게 하기
        Vector3 pos = transform.position;
        if (pos.x < -2.5f) pos.x = -2.5f;
        if (pos.x > 2.5f) pos.x = 2.5f;
        transform.position = pos;
        //--- 화면 밖으로 못 나가게 하기


    }//void Update()

    //골 도착
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name.Contains("flag") == true)
        {
            //Debug.Log("골");
            SceneManager.LoadScene("ClearScene");
        }
        else if(coll.gameObject.name.Contains("WaterRoot") == true)
        {
            Die();
        }
        else if(coll.gameObject.name.Contains("arrowPrefab") == true)
        {
                       /* DestroyImmediate(coll.gameObject);*///다음번 프레임에 제거이나 즉시 제거로 하면 바로 제거
            if (m_OverlapBlock != coll.gameObject) //새로운 화살일때만 체크하고 충돌을 일으키나 두세번 연속 충돌 방지한다.
            {
                hp -= 1.0f;
                HpImgUpdate();
                if(hp <= 0.0f) //죽었을 때
                {
                    Die();
                }

                //Debug.Log("화살과 충돌");

                m_OverlapBlock = coll.gameObject;
            }
           
        }

        //에너지 증가 로직
        else if(coll.gameObject.name.Contains("fish")== true)
        {

            if(m_OverlapBlock != coll.gameObject)
            {
                hp += 0.5f;
                if (3.0f < hp)
                    hp = 3.0f;
                HpImgUpdate();

                m_OverlapBlock = coll.gameObject;
            }
            Destroy(coll.gameObject);

        }
        //~에너지 증가 로직

    }

    void Die()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    void HpImgUpdate()
    {
        float a_CacHp = 0.0f;
        for(int ii = 0; ii < hpImage.Length; ii++) 
        {

            a_CacHp = hp - (float)ii;
            if (a_CacHp < 0.0f)
                a_CacHp = 0.0f;//음수가 안됨

            if (1.0 < a_CacHp) 
                a_CacHp = 1.0f;
            if (0.45 < a_CacHp && a_CacHp < 0.55f)
                a_CacHp = 0.445f;
            hpImage[ii].fillAmount = a_CacHp;
        
        }
    }
}
