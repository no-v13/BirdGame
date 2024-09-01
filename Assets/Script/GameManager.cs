using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TMPro�� ����ؼ� UI�� �ؽ�Ʈ(���ھ�) �߰��� ���� 

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;// GameManager�� Instance(������)����

    //static= �ν��Ͻ� ���̵� ���ٰ����� ��������� �޼ҵ�
    //=���� ������ Ŭ������ �ν��Ͻ�ȭ ��Ű�� �ʾƵ� ���ٰ���

    public GameObject wallPrefab;//���� �ð��� ������ Wall�� ���� ȭ�鿡 ǥ��

    public float spawnTerm = 4; //��� �������� ���� ���� ���ΰ�

    public TextMeshProUGUI scoreLabel;// TextMeshProUGUI -> TMPro�� ���
    public float score;////TMPro�� ���ھ� �Է�

    float spawnTimer; // ������ �����ð� �˾Ƴ�

    private void Awake() //start�� ��� �꺸�� ���� �Ҹ�
    {
        Instance = this; //���� �Ŵ����� �ν��Ͻ��� �ܺο��� �����ϱ� ���� ��    
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
        spawnTimer += Time.deltaTime; //���� �Ҹ� ������ �帥�ð��� �߰��� ����

        score += Time.deltaTime;
        scoreLabel.text = ((int)score).ToString();

        if (spawnTimer > spawnTerm) // �帥 �ð��� �����Һ��� ������ٸ� ���� �������?
        {
            spawnTimer -= spawnTerm; //�׷� Ÿ�̸ӿ��� ������ ��-> �׷� �ٽ� ī��Ʈ�� ����

            GameObject obj = Instantiate(wallPrefab); //wallPrefab�̶� ���� ���� ������Ʈ�� ��
            obj.transform.position = new Vector2(10,Random.Range(-2.75f,2.75f)); //������Ʈ ��ġ ����
                                                //������10-> ȭ�� �ۿ��� ��Ÿ���� ���ڱ� ����
        }
    }
}
