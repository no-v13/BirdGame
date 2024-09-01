using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement; //�� ��ȯ�ϱ� ����


public class Player : MonoBehaviour
{
    public float gravity = 10f; //ĳ���Ͱ� �������Բ� ����
    public float accel = 10f;  //���� �ö� �� ���ӵ� 
    float v; //����ӵ�

    public AudioClip upSound;
    public AudioClip downSound;

    // Start is called before the first frame update
    void Start()
    {
        v = 0; //ó�� ����� �ӵ�= 0
    }

    // Update is called once per frame
    void Update()
    {//edit- projectSetting- Input Manager���� �����ϴ� Ű ���
        /* GetButton = ���� ������ �ִ� �������� �ƴ���
         * GetButton down= Ȥ�� ��� ������? �� ������ ���� ����
         * GetButton up= ���� ���� ���� ����
         */
        if (Input.GetButtonDown("Jump"))
        {//Ű�� �����ä��� �� 
            GetComponent<AudioSource>().PlayOneShot(upSound);
            //���� ������Ʈ�� ���� �ٸ� ������Ʈ �θ� �� �� 
        }
        if (Input.GetButtonUp("Jump"))
        {//Ű���� �� ���� ��  
            GetComponent<AudioSource>().PlayOneShot(downSound);
        }
        if (Input.GetButton("Jump")) //JumpŰ�� �����ִ� ���½ÿ� ���ǹ��ȿ� ����
        {
            v -= accel * Time.deltaTime; // y ��ǥ�� ���̳ʽ��� ����
        }
        else
        {
            v += gravity * Time.deltaTime; // y ��ǥ�� +�� �Ʒ���-> �߷� ������ �޴´�
        }
    }//update


    private void FixedUpdate() //MonoBehaviour �⺻ ���� -> �����ùĽ� '��������'���� �� �Լ��� ȣ����� ����
    //� ��ü�� ��ġ& � ��ü�� ��ȣ�ۿ�(�΋H�� ��)�� �� ���
    {
        transform.Translate(Vector2.down*v*Time.fixedDeltaTime); // FixedUpdate �Լ����� ��ŸŸ�Ӹ��� fixedDeltaTime ���
                          //=new Vector2(0,-1)�� ǥ������
    }
    private void OnCollisionEnter2D(Collision2D collision) //�� ��ũ��Ʈ�� �ٸ� collider�� �浹�� �ڵ����� ȣ��
    {           //�ٸ���ü�� �΋H������ �������� �̺�Ʈ����  
        if (collision.gameObject.tag=="wall") //���� �΋H���� ���̶��
        {//�浹����.����.�±׸� ���ض� = �浹�� ���ӿ�����Ʈ�� �±װ� ���̸�?�׿��� -> �� �̵� �ʿ�
           
            float score =GameManager.Instance.score;//�浹�ϸ� �׸Ŵ����� �ν��Ͻ��� ����ִ� ���ھ �ҷ���
            PlayerPrefs.SetInt("Score",(int)score); 
            //=>������ ���� ����
            PlayerPrefs.Save();//  PlayerPrefs�����ؼ� ���߿� �ѵ� ����&�� �̵������� ������ �ҽ�X
            SceneManager.LoadScene("GameOverScene"); //���̵���
        }


    }
}
