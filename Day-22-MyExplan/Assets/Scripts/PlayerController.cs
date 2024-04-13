using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("UI Components")]
    public Image[] lifeImages; // 생명 이미지 배열
    public GameObject GameOverPanel; // 게임 오버 패널
    public Button ReplayBtn; // 게임 재시작 버튼
    public Text recordText; // 기록 텍스트
    public Text Height_Text; // 높이 텍스트
    public Image dashCooldownImage; // 대시 쿨타임 이미지
    public float dashCooldown = 5.0f; // 대시 쿨타임 (초)
    private bool canDash = true; // 대시 가능 여부


    [Header("Gameplay Variables")]
    public int score = 0; // 점수
    public float lifeDecreaseAmount = 0.1f; // 생명 감소량
    Rigidbody2D rigid2D;
    Animator animator; // 애니메이터 컴포넌트 불러오기

    [Header("Player Movement Variables")]
    public  float hightstHeight = 4.6f; // 플레이어가 도달해야 하는 최대 높이
    float jumpForce = 680.0f; // 점프 힘
    float walkforce = 30.0f; // 걷기 힘
    float dashForce = 10f; // 대시 힘
    float maxWalkSpeed = 2.0f; // 최대 걸음 속도
    float minX = -3.26f; // 왼쪽 끝 x 좌표
    float maxX = 3.11f; // 오른쪽 끝 x 좌표
    float minY = -10f; // 아래쪽 끝 y 좌표
    bool isDashing = false; // 대시 중인지 여부


    public static PlayerController Instance;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>(); // 애니메이터 불러오기


        // 게임이 시작될 때 게임 오버 패널을 비활성화
        GameOverPanel.SetActive(false);
        ReplayBtn.gameObject.SetActive(false);

        //리플레이 버튼 클릭
        ReplayBtn.onClick.AddListener(ReplayBtnClick);

       
        hightstHeight = transform.position.y; // 초기 높이를 설정
    }

    // Update is called once per frame
    void Update()
    {
        float height = transform.position.y;
        Height_Text.text = "높이 : " + height.ToString("F2");

        if (height > hightstHeight)
        {
            hightstHeight = height;
            PlayerPrefs.SetFloat("HighestHeight", hightstHeight);
            PlayerPrefs.Save();
        }

        recordText.text = "최고 기록: " + PlayerPrefs.GetFloat("HighestHeight", 0).ToString("F2");
        // 대시
        if (Input.GetKeyDown(KeyCode.F) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * jumpForce);
        }

        // 좌우 이동
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        // 플레이어 속도 제한
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkforce);
        }

        // 반전
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // 플레이어 속도에 맞춰 애니메이션 속도 조절
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

        // 예외 처리: 바깥으로 나가지 못하도록 제한 및 게임 씬 재로딩
        if (transform.position.y < minY)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            RestrictMovement();
        }
    }

    // 대시 구현
    IEnumerator Dash()
    {
        if (canDash)
        {
            isDashing = true; // 대시 중 플래그 설정
            canDash = false; // 대시 불가능 상태로 변경

            // 대시 힘을 적용하여 플레이어를 이동시킴
            rigid2D.velocity = new Vector2(transform.localScale.x * dashForce, rigid2D.velocity.y);

            yield return new WaitForSeconds(0.2f); // 대시 시간

            isDashing = false; // 대시 종료

            // 쿨타임 시작
            StartCoroutine(DashCooldown());
        }
    }


    // 대시 쿨타임
    IEnumerator DashCooldown()
    {
        float cooldownRemaining = dashCooldown;

        // 쿨타임 동안
        while (cooldownRemaining > 0)
        {
            // fillAmount 갱신
            dashCooldownImage.fillAmount = cooldownRemaining / dashCooldown;

            // 1프레임 대기
            yield return null;

            // 쿨타임 감소
            cooldownRemaining -= Time.deltaTime;
        }

        // fillAmount를 완전히 채움
        dashCooldownImage.fillAmount = 1;

        // 대시 가능 상태로 변경
        canDash = true;
    }

    void Awake()
    {
        Instance = this; // Instance 변수 초기화
    }


    // 이동 제한
    public void RestrictMovement()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.y = Mathf.Max(clampedPosition.y, minY); // y 좌표를 minY 이상으로 제한
        transform.position = clampedPosition;
    }


    // 물에 닿았을 때 생명 감소
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Flag"))
        {
            SceneManager.LoadScene("ClearScene");
        }

        if (other.gameObject.CompareTag("Fish"))
        {
            // 생명력 증가
            for (int i = 0; i < lifeImages.Length; i++)
            {
                if (lifeImages[i].fillAmount < 1)
                {
                    lifeImages[i].fillAmount += 0.5f;
                    break;
                }
            }

            UpdateRecordText(); // 기록 텍스트 업데이트
            UpdateHighScore(); // 최고 점수 갱신


            Destroy(other.gameObject); // 물고기 오브젝트 삭제
        }

        if (other.gameObject.CompareTag("Water"))
        {
           GameOverPanel.SetActive(true);
            ReplayBtn.gameObject.SetActive(true);
            Time.timeScale = 0; // 게임 일시 정지
        }
    }

    public void DecreaseLives()
    {
        // 생명 감소
        for (int i = 0; i < lifeImages.Length; i++)
        {
            if (lifeImages[i].fillAmount > 0)
            {
                lifeImages[i].fillAmount -= lifeDecreaseAmount;
                break;
            }
        }

        bool allLivesLost = true; // 모든 생명이 소진되었는지 여부를 나타내는 변수
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
            // 모든 생명이 소진되면 게임 오버 패널을 활성화
            GameOverPanel.SetActive(true);
            ReplayBtn.gameObject.SetActive(true);
            Time.timeScale = 0; // 게임 일시 정지
        }
    }
    public void ReplayBtnClick()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1; // 게임 재시작
    }

    private void UpdateRecordText()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // 최고 점수 가져오기

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score); // 최고 점수 갱신
        }
    }
    private void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // 최고 점수 가져오기

        if (score > highScore)
        {
            PlayerPrefs.SetInt("최고기록 :", score); // 최고 점수 갱신
        }
    }


}




