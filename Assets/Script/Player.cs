using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; //씬 전환하기 위함


public class Player : MonoBehaviour
{
    public float gravity = 10f; //캐릭터가 떨어지게끔 만듦
    public float accel = 10f;  //위로 올라갈 때 가속도 
    float v; //현재속도

    public AudioClip upSound;
    public AudioClip downSound;

    // Start is called before the first frame update
    void Start()
    {
        v = 0; //처음 실행시 속도= 0
    }

    // Update is called once per frame
    void Update()
    {//edit- projectSetting- Input Manager에서 제공하는 키 사용
        /* GetButton = 현재 누르고 있는 상태인지 아닌지
         * GetButton down= 혹시 방금 눌렀냐? 꾹 누르는 순간 포착
         * GetButton up= 손을 떼는 순간 포착
         */
        if (Input.GetButtonDown("Jump"))
        {//키를 눌ㄹㅓㅆ을 때 
            GetComponent<AudioSource>().PlayOneShot(upSound);
            //같은 오브젝트에 붙은 다른 컴포넌트 부를 때 씀 
        }
        if (Input.GetButtonUp("Jump"))
        {//키에서 손 뗐을 때  
            GetComponent<AudioSource>().PlayOneShot(downSound);
        }
        if (Input.GetButton("Jump")) //Jump키가 눌려있는 상태시에 조건문안에 들어옴
        {
            v -= accel * Time.deltaTime; // y 좌표가 마이너스면 위쪽
        }
        else
        {
            v += gravity * Time.deltaTime; // y 좌표가 +면 아래쪽-> 중력 영향을 받는다
        }
    }//update


    private void FixedUpdate() //MonoBehaviour 기본 제공 -> 물리시뮬시 '일정간격'으로 이 함수가 호출됨을 보장
    //어떤 물체의 위치& 어떤 물체와 상호작용(부딫힘 등)할 때 사용
    {
        transform.Translate(Vector2.down*v*Time.fixedDeltaTime); // FixedUpdate 함수에선 델타타임말고 fixedDeltaTime 사용
                          //=new Vector2(0,-1)로 표현가능
    }
    private void OnCollisionEnter2D(Collision2D collision) //이 스크립트가 다른 collider와 충돌시 자동으로 호출
    {           //다른물체와 부딫혔을때 벌어지는 이벤트에서  
        if (collision.gameObject.tag=="wall") //내가 부딫힌게 벽이라면
        {//충돌정보.상대방.태그를 비교해라 = 충돌한 게임오브젝트의 태그가 벽이면?겜오버 -> 씬 이동 필요
           
            float score =GameManager.Instance.score;//충돌하면 겜매니저가 인스턴스가 들고있는 스코어를 불러옴
            PlayerPrefs.SetInt("Score",(int)score); 
            //=>게임을 꺼도 저장
            PlayerPrefs.Save();//  PlayerPrefs저장해서 나중에 켜도 저장&씬 이동간에도 데이터 소실X
            SceneManager.LoadScene("GameOverScene"); //씬이동함
        }


    }
}
