using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGen : MonoBehaviour
{
    public GameObject arrowPrefab; // 화살 프리팹
    public GameObject warningImagePrefab; // 경고 이미지 프리팹
    public float span = 15.0f; // 화살 생성 주기를 처음에는 더 길게 설정
    public float warningTime = 2.0f; // 경고 시간
    public float delta = 0; // 시간 계산용 변수
    private GameObject player; // 플레이어 오브젝트
    private GameObject currentWarningImage; // 현재 경고 이미지

    void Start()
    {
        player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            Vector3 arrowPosition = new Vector3(player.transform.position.x, 23, 0);

            // 새로운 경고 이미지 인스턴스를 생성하고 플레이어와 동일한 위치에 배치
            if (currentWarningImage != null)
            {
                Destroy(currentWarningImage); // 이전 경고 이미지 삭제
            }
            currentWarningImage = Instantiate(warningImagePrefab, player.transform.position, Quaternion.identity);

            // 일정 시간 후에 화살 생성
            StartCoroutine(CreateArrowAfterWarning(arrowPosition));

            // 화살 생성 주기를 점차 줄임
            if (span > 1.0f)
            {
                span -= 0.01f;
            }
        }
    }

    IEnumerator CreateArrowAfterWarning(Vector3 position)
    {
        // 경고 시간 동안 대기
        yield return new WaitForSeconds(warningTime);

        // 화살 생성
        GameObject go = Instantiate(arrowPrefab) as GameObject;
        go.transform.position = position;

        // 화살이 떨어지기 시작하면 경고 이미지를 삭제
        Destroy(currentWarningImage);
    }
}
