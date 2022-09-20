using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMoveBullet : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    Rigidbody2D rb;
    [SerializeField] GameObject _hit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * _speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5f);
        }
    }
}
