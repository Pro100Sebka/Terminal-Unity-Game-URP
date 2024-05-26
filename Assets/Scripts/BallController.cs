using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private  float speed; // Швидкість руху м'яча
    [SerializeField] private GameObject gameOverScreen;
    public int aiScore;
    public int playerScore;
    [SerializeField] public TextMeshProUGUI score;
    [SerializeField] private AudioSource bounce;
    [SerializeField] private float radius;
    private RaycastHit2D hitGlobal;
    private Vector2 directionGlobal;

    void Start()
    {
        ResetBall();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Cmd");
        }


        var hits = Physics2D.CircleCastAll(transform.position,radius,Vector2.zero);
            //Physics2D.OverlapCircle(transform.position, radius);
            foreach (var hit in hits)
            {
                if (hit != null )
                {
                    float deltaX = transform.position.x - hit.point.x; // тут скрипт просто відскакує в протиполжном напрямку
                    float deltaY = transform.position.y - hit.point.y;
                    Vector2 direction = new Vector2(deltaX + Random.Range(-0.1f, 0.1f) , deltaY + Random.Range(-0.1f, 0.1f)).normalized;
                    rb.velocity = direction * speed;
                    hitGlobal = hit;
                    directionGlobal = direction;
                    return;
                }
            }
        
          



        if (transform.position.x <= -9)
        {
            aiScore += 1; ResetBall(); 
            score.text = playerScore.ToString() + " : " + aiScore.ToString();
        }
        else if (transform.position.x >= 9)
        {
            playerScore += 1; ResetBall();
            score.text = playerScore.ToString() + " : " + aiScore.ToString();
        }
        

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawSphere(transform.position, radius);
        Gizmos.DrawRay(hitGlobal.transform.position ,directionGlobal);
    }


    private void ResetBall()
    {
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector3(1f,0.1f,0f)* speed;
    }
    
}
