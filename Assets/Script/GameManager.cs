using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TMPro를 사용해서 UI에 텍스트(스코어) 추가할 것임 

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;// GameManager의 Instance(변수명)만듦

    //static= 인스턴스 없이도 접근가능한 멤버변수나 메소드
    //=원본 가지고 클래스를 인스턴스화 시키지 않아도 접근가능

    public GameObject wallPrefab;//일정 시간이 지나면 Wall을 만들어서 화면에 표시

    public float spawnTerm = 4; //어느 간격으로 벽을 만들 것인가

    public TextMeshProUGUI scoreLabel;// TextMeshProUGUI -> TMPro를 사용
    public float score;////TMPro로 스코어 입력

    float spawnTimer; // 마지막 스폰시간 알아냄

    private void Awake() //start와 비슷 얘보다 먼저 불림
    {
        Instance = this; //게임 매니저의 인스턴스를 외부에서 접근하기 쉽게 함    
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime; //업뎃 불릴 때마다 흐른시간이 추가될 것임

        score += Time.deltaTime;
        scoreLabel.text = ((int)score).ToString();

        if (spawnTimer > spawnTerm) // 흐른 시간이 스폰텀보다 길어진다면 벽을 세우겠지?
        {
            spawnTimer -= spawnTerm; //그럼 타이머에서 간격을 빼-> 그럼 다시 카운트를 시작

            GameObject obj = Instantiate(wallPrefab); //wallPrefab이란 툴을 실제 오브젝트로 찍어냄
            obj.transform.position = new Vector2(10,Random.Range(-2.75f,2.75f)); //오브젝트 위치 지정
                                                //가로폭10-> 화면 밖에서 나타났음 좋겠기 때문
        }
    }
}
