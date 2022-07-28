using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] Transform rayStart;
    private Animator anim;
    private Rigidbody rb;
    private bool walkingRight = true;
    GameManager gameManager;
    float speedInc = 1f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
        
    }
    private void FixedUpdate()
    {
        if (!gameManager.isStarted) return;
        else
        {
            anim.SetTrigger("gameStarted");
        }
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime*speedInc;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            Switch();
        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            anim.SetTrigger("isFalling");
        }
        else
            anim.SetTrigger("notFalling");
        if (transform.position.y < -2)
        {
            gameManager.GameOver();
        }
        
    }
    private void Switch()
    {
        if (!gameManager.isStarted) return;
        walkingRight = !walkingRight;
        if (walkingRight)       
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            gameManager.GettingScore();
            Destroy(other.gameObject);
            speedInc += 0.1f;

        }



        }
}
