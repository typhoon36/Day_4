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

    int m_ReserveJump = 0;      // ���� ���� ����

    float hp = 3.0f;
    public Image[] hpImage;

    GameObject m_OverlapBlock = null;
    //�����̳� ȭ�� �μ��� ���� �浹 ����

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

        //�����Ѵ�.
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

        //�¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //�÷��̾��� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        ////����Ʈ ����
        //if(speedx < this.maxWalkSpeed)
        //{
        //    this.rigid2D.AddForce(transform.right * key * this.walkForce);
        //}

        //ĳ���� �̵�
        rigid2D.velocity = new Vector2((key * walkSpeed), rigid2D.velocity.y);

        //�����̴� ���⿡ ���� �����Ѵ�.
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //�÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ۴�.
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        //�÷��̾ ȭ�� ������ �����ٸ� ó������
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
        else //��Ÿ���� ����������
        {
            if(isDash == true)
            {
                dashParticle.Play();
                dashTime += Time.deltaTime;
                if(dashTime <= dashMaxTime) //dashMatime == 0.1f //0.1�� ���� �� �о��ֱ�
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


        //--- ȭ�� ������ �� ������ �ϱ�
        Vector3 pos = transform.position;
        if (pos.x < -2.5f) pos.x = -2.5f;
        if (pos.x > 2.5f) pos.x = 2.5f;
        transform.position = pos;
        //--- ȭ�� ������ �� ������ �ϱ�


    }//void Update()

    //�� ����
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name.Contains("flag") == true)
        {
            //Debug.Log("��");
            SceneManager.LoadScene("ClearScene");
        }
        else if(coll.gameObject.name.Contains("WaterRoot") == true)
        {
            Die();
        }
        else if(coll.gameObject.name.Contains("arrowPrefab") == true)
        {
                       /* DestroyImmediate(coll.gameObject);*///������ �����ӿ� �����̳� ��� ���ŷ� �ϸ� �ٷ� ����
            if (m_OverlapBlock != coll.gameObject) //���ο� ȭ���϶��� üũ�ϰ� �浹�� ����Ű�� �μ��� ���� �浹 �����Ѵ�.
            {
                hp -= 1.0f;
                HpImgUpdate();
                if(hp <= 0.0f) //�׾��� ��
                {
                    Die();
                }

                //Debug.Log("ȭ��� �浹");

                m_OverlapBlock = coll.gameObject;
            }
           
        }

        //������ ���� ����
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
        //~������ ���� ����

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
                a_CacHp = 0.0f;//������ �ȵ�

            if (1.0 < a_CacHp) 
                a_CacHp = 1.0f;
            if (0.45 < a_CacHp && a_CacHp < 0.55f)
                a_CacHp = 0.445f;
            hpImage[ii].fillAmount = a_CacHp;
        
        }
    }
}
