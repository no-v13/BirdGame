using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 이동을 할 수 있게함
using TMPro;


public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel; //겜오버 씬에서 scoreLabel을 겜매니저가 알게해서 텍스트 쓸 것임

    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score",0);
                                     //Score 키가 저장 안되어 있으면 디폴트값을 0으로 저장해라
    
        scoreLabel.text = score.ToString(); //score을 문자열 변환시켜서 scoreLabel.text에 저장
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgainPressed() //PlayAgain누르면 게임씬으로 돌아가게
    {
        SceneManager.LoadScene("GameScene"); //GameScene이란 이름의 씬을 로드함
        //LoadScene으로 게임씬을 불러올때-> 반드시 빌드세팅에서 새 씬을 등록해야 함!!!
    }
    public void QuitPressed()
    {
        Application.Quit(); //빌드를 만들었을때 작동시켜서 프로그램 종료시킴

    }
}
