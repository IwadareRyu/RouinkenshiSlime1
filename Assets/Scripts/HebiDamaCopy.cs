using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HebiDamaCopy : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    Rigidbody2D rb;
    BoundController _muki;
    private GameObject Y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _muki = GameObject.FindWithTag("Player").GetComponent<BoundController>();
        rb.velocity = Vector2.right * _speed * _muki._minas;
        Transform MyTransform = this.gameObject.GetComponent<Transform>();
        MyTransform.transform.localScale = new Vector3(_muki._minas, 1, 1);
        Y = GameObject.FindGameObjectWithTag("Hebi");
        float sin = Y.transform.position.y + Mathf.Sin(Time.time * 10);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Y = GameObject.FindGameObjectWithTag("Hebi");
        float sin = Y.transform.position.y +  Mathf.Sin(Time.time * 10);
        Vector3 pos = transform.position;
        pos.y = sin;
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}