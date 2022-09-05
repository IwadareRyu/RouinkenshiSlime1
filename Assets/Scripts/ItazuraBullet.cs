using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItazuraBullet : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    Rigidbody2D rb;
    PlayerButtobi _flip;
    [SerializeField] GameObject _hit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _flip = GameObject.FindWithTag("HomingEnemy").GetComponent<PlayerButtobi>();
        rb.velocity = Vector2.left * _speed * _flip._minasmimikku;
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
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5);
        }
    }
}
