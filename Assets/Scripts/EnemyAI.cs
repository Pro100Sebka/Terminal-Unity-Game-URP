
using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private float speed;
    private int up_Down;
    
    
    void Update()
    {
        var pos = transform.position;
        pos.y = ball.position.y;
        transform.position = pos;
        
        if (up_Down == 0 )
        {
            if (3.8 > transform.position.y)
            {
                transform.Translate(Vector3.up * (Time.deltaTime * speed));
            }
        }
        else
        {
            if (transform.position.y > -3.8)
            {
                transform.Translate(Vector3.down * (Time.deltaTime * speed));
            }
        }
    }
}
