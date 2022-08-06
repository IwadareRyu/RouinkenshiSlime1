using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItazuraBullet : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    Rigidbody2D rb;
    PlayerButtobi _flip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _flip = GameObject.FindWithTag("HomingEnemy").GetComponent<PlayerButtobi>();
        rb.velocity = Vector2.left * _speed * _flip.minas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
