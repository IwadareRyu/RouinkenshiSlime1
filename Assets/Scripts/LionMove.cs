using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionMove : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _power;
    [SerializeField] float _movepower;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //����AddForce�Ń��C�I���𐁂���΂��B
        _rb.AddForce(Vector2.left * _power, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //���Ƀ��C�I���𓮂����B
        _rb.velocity = new Vector2(-1 * _movepower, _rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
