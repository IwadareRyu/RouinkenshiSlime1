using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HebiDama : CopyBase
{
    [SerializeField] GameObject _copyHebidama;
    private GameObject Mazzle;
    float _speed = 10f;
    Rigidbody2D rb;
    //�����蔻��ɓ������������̃I�u�W�F�N�g�����B
    public override void CopyTech()
    {
        Mazzle = GameObject.FindGameObjectWithTag("Atari");
        Instantiate(_copyHebidama, Mazzle.transform.position, Quaternion.identity);
    }
    private void Start()
    {
        //�ʒu�̏������B
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * _speed;
        Mazzle = GameObject.FindGameObjectWithTag("Hebi");
        float sin = Mazzle.transform.position.y +  Mathf.Sin(Time.time);
    }
    private void FixedUpdate()
    {
        //sin1��Time.time�œ������ď㉺�Ɉړ��B
        Mazzle = GameObject.FindGameObjectWithTag("Hebi");
        float sin = Mazzle.transform.position.y + Mathf.Sin(Time.time*10);
        Vector3 pos = transform.position;
        pos.y =sin;
        transform.position = pos;
    }
}