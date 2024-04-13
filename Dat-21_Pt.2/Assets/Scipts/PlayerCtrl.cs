using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpPower = 680.0f;

    // �ִϸ�����
    Animator animator;

   float walkForce = 30.0f; //�ȱ� 
   float maxWalkSpeed = 2.0f; //�ִ� �ȱ� �ӵ�
   //float threshold = 0.2f; //�ӵ� ����


    // Start is called before the first frame update
    void Start()
    {
        Application. targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();//�ִϸ����� ������ 
    }

    // Update is called once per frame
    void Update()
    {


      //����
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.rigid2D.AddForce(transform.up * this.jumpPower);
        }



        //�ڵ���
        if (Input.GetKeyDown(0) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger"); //���� �ִϸ��̼�
            this.rigid2D.AddForce(transform.up * this.jumpPower);
        }
        //~�ڵ���



        //�¿��̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        //~�¿��̵�


        ////�ڵ��� �¿��̵�
        //int key = 0;
        //if (Input.acceleration.x > this.threshold) key = 1;
        //if (Input.acceleration.x < -this.threshold) key = -1;
        ////~�ڵ��� �¿��̵�


        //�÷��̾� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x); 
        //~�÷��̾� �ӵ�


        //+�ӵ� ����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        //~�ӵ� ����

        //+ �����̴� ���⿡  ���� ����

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        //~ �����̴� ���⿡ ���� ����

        //�÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ� ����
        this.animator.speed = speedx / 2.0f;


        //�÷��̾��� �ӵ��� ���� �ִϸ��̼� �ӵ��� �ٲ�
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }


        //�÷��̾ ȭ�� ������ ������ ��
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
        //ó������ �ٽ�



  
    }
    //+ �� ����
    void OnTriggerEnter2D(Collider2D other)
    {
      
        //Debug.Log("��");
        SceneManager.LoadScene("ClearScene");
    }
    //~�� ����

}
