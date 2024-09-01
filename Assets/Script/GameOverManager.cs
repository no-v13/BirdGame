using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //�� �̵��� �� �� �ְ���
using TMPro;


public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel; //�׿��� ������ scoreLabel�� �׸Ŵ����� �˰��ؼ� �ؽ�Ʈ �� ����

    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score",0);
                                     //Score Ű�� ���� �ȵǾ� ������ ����Ʈ���� 0���� �����ض�
    
        scoreLabel.text = score.ToString(); //score�� ���ڿ� ��ȯ���Ѽ� scoreLabel.text�� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgainPressed() //PlayAgain������ ���Ӿ����� ���ư���
    {
        SceneManager.LoadScene("GameScene"); //GameScene�̶� �̸��� ���� �ε���
        //LoadScene���� ���Ӿ��� �ҷ��ö�-> �ݵ�� ���弼�ÿ��� �� ���� ����ؾ� ��!!!
    }
    public void QuitPressed()
    {
        Application.Quit(); //���带 ��������� �۵����Ѽ� ���α׷� �����Ŵ

    }
}
