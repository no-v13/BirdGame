using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
        if (transform.position.x < -10)
        {
            Destroy(gameObject); //gameObject 붙어있는 앨 없애-> 화면 밖으로 사라지게 함: 메모리 절약도 하구
        }
    }

    
}
