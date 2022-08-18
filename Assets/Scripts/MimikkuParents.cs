using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimikkuParents : CopyBase
{
    private GameObject Mazzle;
    private Transform _atari;
    [SerializeField] GameObject _copyTumeBullet;
    Rigidbody2D _rb;
    float _speed = 3f;
    private GameObject _playerpos;
    [SerializeField] float _playerOffest = 2f;
    [SerializeField] float _cavePower = 2f;
    float _thisX;
    bool rotation0;
    public override void CopyTech()
    {
        Mazzle = GameObject.FindGameObjectWithTag("Mazzle");
        _atari = Mazzle.GetComponent<Transform>();
        Instantiate(_copyTumeBullet, _atari.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerpos = GameObject.FindGameObjectWithTag("Player");
        _rb.velocity = Vector2.down * _speed;
        transform.Rotate(new Vector3(0, 0, -90f));
    }
    private void Update()
    {
        if(_playerpos)
        {
            if(transform.position.y - _playerpos.transform.position.y < _playerOffest)
            {
                if(_thisX == 0)
                {
                  _thisX = ( _playerpos.transform.position.x > transform.position.x) ? 1 : -1;
                }
                if (!rotation0)
                {
                    transform.Rotate(new Vector3(0, 0, 90f));
                    rotation0 = true;
                }
                FlipX(_thisX);
                _rb.AddForce(_thisX * Vector2.right * _cavePower);
            }
        }
    }
    void FlipX(float horizontal)
    {
        if(horizontal > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if(horizontal< 0)
        {
            transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
