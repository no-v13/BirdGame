using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour //����Ƽ �⺻ ���- �̰� �վ�� componant�� ���� �� ����
{
    public float speed =3; //����Ƽ ��׶��带 õõ�� �����ų��
    public float size = 19.2f; //����Ƽ �ν�����-��濡�� size�� ���̰Բ�!

    // Start is called before the first frame update
    void Start() //������Ʈ ����� ó���� �ѹ� ����
    {
       

    }

    // Update is called once per frame
    void Update() //���� ���൵�� �� �����Ӹ��� ����
    {
        transform.Translate(new Vector3(-1, 0, 0)*speed*Time.deltaTime); //�� ��ü�� ȭ�鿡�� �����̰ڴٴ� ��& ���⼱ �������� �帣�� �� ����: Vector3(-1, 0, 0))
      //=>��ġ���� ������  //=> Vecter3.left�� ǥ������                 //������Ʈ ȣ���� ���� ���� �Լ��� �Ҹ��� ���� �ɸ��� �ð��� �ǹ�
        if (transform.position.x < -size)
        {
            transform.Translate(new Vector3(2*size , 0, 0));
        }
        
    }
}
