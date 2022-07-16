using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingCopy : MonoBehaviour
{
    Rigidbody2D rb;
    private GameObject Player;
    [SerializeField] float _speed = 15f;
    [SerializeField] float _limitSpeed = 5f;
    Transform _bulletTurn;
    private Transform _playerturn;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        _bulletTurn = GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("HomingEnemy");
        _playerturn = Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Vector3 vector3 = _playerturn.position - _bulletTurn.position;
        rb.AddForce(vector3.normalized * _speed);

        float speedX = Mathf.Clamp(rb.velocity.x, -_limitSpeed, _limitSpeed);
        float speedY = Mathf.Clamp(rb.velocity.y, -_limitSpeed, _limitSpeed);
        rb.velocity = new Vector3(speedX, speedY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
