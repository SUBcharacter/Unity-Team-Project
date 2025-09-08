using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle"))
             return;

        transform.gameObject.SetActive(false);
    }

    void Control()
    {

    }

    void Retry()
    {
        transform.gameObject.SetActive(true);
    }
}
