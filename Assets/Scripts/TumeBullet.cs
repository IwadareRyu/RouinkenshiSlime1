using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumeBullet : CopyBase
{
    [SerializeField] GameObject _copyTumeBullet;
    private GameObject Mazzle;
    private Transform _atari;
    [SerializeField]float _speed = 5f;
    Rigidbody2D rb;
    PlayerButtobi _flip;
    public override void CopyTech()
    {

        Mazzle = GameObject.FindGameObjectWithTag("Mazzle");
        _atari = Mazzle.GetComponent<Transform>();
        Instantiate(_copyTumeBullet, _atari.position, Quaternion.identity);
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
    }
}