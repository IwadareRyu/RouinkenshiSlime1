using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HebiDamaCopy : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    Rigidbody2D rb;
    BoundController _muki;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _muki = GameObject.FindWithTag("Player").GetComponent<BoundController>();
        rb.velocity = Vector2.right * _speed * _muki.minas;
        Transform MyTransform = this.gameObject.GetComponent<Transform>();
        MyTransform.transform.localScale = new Vector3(_muki.minas, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float sin = Mathf.Sin(Time.time * 10);
        Vector3 pos = transform.position;
        pos.y = sin;
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}