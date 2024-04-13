using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("UI Components")]
    public Image[] lifeImages; // ���� �̹��� �迭
    public GameObject GameOverPanel; // ���� ���� �г�
    public Button ReplayBtn; // ���� ����� ��ư
    public Text recordText; // ��� �ؽ�Ʈ
    public Text Height_Text; // ���� �ؽ�Ʈ
    public Image dashCooldownImage; // ��� ��Ÿ�� �̹���
    public float dashCooldown = 5.0f; // ��� ��Ÿ�� (��)
    private bool canDash = true; // ��� ���� ����


    [Header("Gameplay Variables")]
    public int score = 0; // ����
    public float lifeDecreaseAmount = 0.1f; // ���� ���ҷ�
    Rigidbody2D rigid2D;
    Animator animator; // �ִϸ����� ������Ʈ �ҷ�����

    [Header("Player Movement Variables")]
    public  float hightstHeight = 4.6f; // �÷��̾ �����ؾ� �ϴ� �ִ� ����
    float jumpForce = 680.0f; // ���� ��
    float walkforce = 30.0f; // �ȱ� ��
    float dashForce = 10f; // ��� ��
    float maxWalkSpeed = 2.0f; // �ִ� ���� �ӵ�
    float minX = -3.26f; // ���� �� x ��ǥ
    float maxX = 3.11f; // ������ �� x ��ǥ
    float minY = -10f; // �Ʒ��� �� y ��ǥ
    bool isDashing = false; // ��� ������ ����


    public static PlayerController Instance;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>(); // �ִϸ����� �ҷ�����


        // ������ ���۵� �� ���� ���� �г��� ��Ȱ��ȭ
        GameOverPanel.SetActive(false);
        ReplayBtn.gameObject.SetActive(false);

        //���÷��� ��ư Ŭ��
        ReplayBtn.onClick.AddListener(ReplayBtnClick);

       
        hightstHeight = transform.position.y; // �ʱ� ���̸� ����
    }

    // Update is called once per frame
    void Update()
    {
        float height = transform.position.y;
        Height_Text.text = "���� : " + height.ToString("F2");

        if (height > hightstHeight)
        {
            hightstHeight = height;
            PlayerPrefs.SetFloat("HighestHeight", hightstHeight);
            PlayerPrefs.Save();
        }

        recordText.text = "�ְ� ���: " + PlayerPrefs.GetFloat("HighestHeight", 0).ToString("F2");
        // ���
        if (Input.GetKeyDown(KeyCode.F) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        // ����
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * jumpForce);
        }

        // �¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // �÷��̾� �ӵ� ����
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkforce);
        }

        // ����
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // �÷��̾� �ӵ��� ���� �ִϸ��̼� �ӵ� ����
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // ���� ó��: �ٱ����� ������ ���ϵ��� ���� �� ���� �� ��ε�
        if (transform.position.y < minY)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            RestrictMovement();
        }
    }

    // ��� ����
    IEnumerator Dash()
    {
        if (canDash)
        {
            isDashing = true; // ��� �� �÷��� ����
            canDash = false; // ��� �Ұ��� ���·� ����

            // ��� ���� �����Ͽ� �÷��̾ �̵���Ŵ
            rigid2D.velocity = new Vector2(transform.localScale.x * dashForce, rigid2D.velocity.y);

            yield return new WaitForSeconds(0.2f); // ��� �ð�

            isDashing = false; // ��� ����

            // ��Ÿ�� ����
            StartCoroutine(DashCooldown());
        }
    }


    // ��� ��Ÿ��
    IEnumerator DashCooldown()
    {
        float cooldownRemaining = dashCooldown;

        // ��Ÿ�� ����
        while (cooldownRemaining > 0)
        {
            // fillAmount ����
            dashCooldownImage.fillAmount = cooldownRemaining / dashCooldown;

            // 1������ ���
            yield return null;

            // ��Ÿ�� ����
            cooldownRemaining -= Time.deltaTime;
        }

        // fillAmount�� ������ ä��
        dashCooldownImage.fillAmount = 1;

        // ��� ���� ���·� ����
        canDash = true;
    }

    void Awake()
    {
        Instance = this; // Instance ���� �ʱ�ȭ
    }


    // �̵� ����
    public void RestrictMovement()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Max(clampedPosition.y, minY); // y ��ǥ�� minY �̻����� ����
        transform.position = clampedPosition;
    }


    // ���� ����� �� ���� ����
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Flag"))
        {
            SceneManager.LoadScene("ClearScene");
        }

        if (other.gameObject.CompareTag("Fish"))
        {
            // ����� ����
            for (int i = 0; i < lifeImages.Length; i++)
            {
                if (lifeImages[i].fillAmount < 1)
                {
                    lifeImages[i].fillAmount += 0.5f;
                    break;
                }
            }

            UpdateRecordText(); // ��� �ؽ�Ʈ ������Ʈ
            UpdateHighScore(); // �ְ� ���� ����


            Destroy(other.gameObject); // ����� ������Ʈ ����
        }

        if (other.gameObject.CompareTag("Water"))
        {
           GameOverPanel.SetActive(true);
            ReplayBtn.gameObject.SetActive(true);
            Time.timeScale = 0; // ���� �Ͻ� ����
        }
    }

    public void DecreaseLives()
    {
        // ���� ����
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (lifeImages[i].fillAmount > 0)
            {
                lifeImages[i].fillAmount -= lifeDecreaseAmount;
                break;
            }
        }

        bool allLivesLost = true; // ��� ������ �����Ǿ����� ���θ� ��Ÿ���� ����
        foreach (Image lifeImage in lifeImages)
        {
            if (lifeImage.fillAmount > 0)
            {
                allLivesLost = false;
                break;
            }
        }

        if (allLivesLost)
        {
            // ��� ������ �����Ǹ� ���� ���� �г��� Ȱ��ȭ
            GameOverPanel.SetActive(true);
            ReplayBtn.gameObject.SetActive(true);
            Time.timeScale = 0; // ���� �Ͻ� ����
        }
    }
    public void ReplayBtnClick()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1; // ���� �����
    }

    private void UpdateRecordText()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // �ְ� ���� ��������

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score); // �ְ� ���� ����
        }
    }
    private void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // �ְ� ���� ��������

        if (score > highScore)
        {
            PlayerPrefs.SetInt("�ְ��� :", score); // �ְ� ���� ����
        }
    }


}




