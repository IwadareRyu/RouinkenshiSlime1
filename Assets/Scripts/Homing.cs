using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : CopyBase
{
    Rigidbody2D rb;
    [SerializeField] GameObject _copyTumeBullet;
    private GameObject Mazzle;
    private GameObject Player;
    private Transform _atari;
    [SerializeField] float _speed = 15f;
    [SerializeField] float _limitSpeed = 5f;
    Transform _bulletTurn;
    private Transform _playerturn;


    public override void CopyTech()
    {
        Mazzle = GameObject.FindGameObjectWithTag("Mazzle");
        _atari = Mazzle.GetComponent<Transform>();
        Instantiate(_copyTumeBullet, _atari.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        _bulletTurn = GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player");
        _playerturn = Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!liftHoming)
        {
            Vector3 vector2 = _playerturn.position - _bulletTurn.position;
            rb.AddForce(vector2.normalized * _speed);

            float speedX = Mathf.Clamp(rb.velocity.x, -_limitSpeed, _limitSpeed);
            float speedY = Mathf.Clamp(rb.velocity.y, -_limitSpeed, _limitSpeed);
            rb.velocity = new Vector3(speedX, speedY);
        }
        else
        {
            rb.AddForce(_bulletTurn.position.normalized * -_speed);
        }
    }
}
