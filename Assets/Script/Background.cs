using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour //유니티 기본 상속- 이게 잇어야 componant에 붙일 수 있음
{
    public float speed =3; //유니티 백그라운드를 천천히 실행시킬것
    public float size = 19.2f; //유니티 인스펙터-배경에서 size를 보이게끔!

    // Start is called before the first frame update
    void Start() //오브젝트 실행시 처음에 한번 실행
    {
       

    }

    // Update is called once per frame
    void Update() //게임 실행도중 매 프레임마다 실행
    {
        transform.Translate(new Vector3(-1, 0, 0)*speed*Time.deltaTime); //이 물체를 화면에서 움직이겠다는 뜻& 여기선 왼쪽으로 흐르게 할 것임: Vector3(-1, 0, 0))
      //=>위치정보 가져옴  //=> Vecter3.left로 표현가능                 //업데이트 호출후 다음 업뎃 함수가 불릴때 까지 걸리는 시간을 의미
        if (transform.position.x < -size)
        {
            transform.Translate(new Vector3(2*size , 0, 0));
        }
        
    }
}
