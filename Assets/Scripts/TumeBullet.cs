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
    [Tooltip("��(1)�ɔ�΂����E(-1)�ɔ�΂����B")]
    [SerializeField,Range(1,-1)] float _minas = 1;

    /// <summary>�R�s�[�𐶐�����B</summary>
    public override void CopyTech()
    {

        Mazzle = GameObject.FindGameObjectWithTag("Mazzle");
        _atari = Mazzle.GetComponent<Transform>();
        Instantiate(_copyTumeBullet, _atari.position, Quaternion.identity);
    }
    private void Start()
    {
        //�����΂��B
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * _speed * _minas;
    }
}