using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumeBulletCopy : MonoBehaviour
{
    [SerializeField] float _speed = 15f;
    Rigidbody2D rb;
    [SerializeField] BoundController _muki;
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
}
