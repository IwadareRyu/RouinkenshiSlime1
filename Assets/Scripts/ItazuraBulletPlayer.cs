using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItazuraBulletPlayer : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] GameObject _hit;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player)
        {
            Vector2 v = player.transform.position - transform.position;
            v = v.normalized * _speed;

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = v;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5);
        }
    }
}
