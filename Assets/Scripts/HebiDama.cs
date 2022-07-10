using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HebiDama : CopyBase
{
    [SerializeField] GameObject _copyHebidama;
    private GameObject Mazzle;
    private Transform _atari;
    float _speed = 10f;
    Rigidbody2D rb;
    public override void CopyTech()
    {
        Mazzle = GameObject.Find("PlayerMazzle");
        _atari = Mazzle.GetComponent<Transform>();
        Instantiate(_copyHebidama, _atari.position, Quaternion.identity);
    }
    //private void Copy()
    //{
    //    Mazzle = GameObject.Find("PlayerMazzle");
    //    _atari = Mazzle.GetComponent<Transform>();
    //    Instantiate(_copyTumeBullet,_atari.position,Quaternion.identity);
    //}
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * _speed;
        float sin = Mathf.Sin(Time.time);
    }
    private void FixedUpdate()
    {
        float sin = Mathf.Sin(Time.time*10);
        Vector3 pos = transform.position;
        pos.y = sin;
        transform.position = pos;
    }
}