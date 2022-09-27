using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimikkuLR : CopyBase
{
    float _minas;
    Rigidbody2D _rb;
    private GameObject _playerpos;
    float _speed = 5f;
    Vector2 _playerTrans;
    [SerializeField] GameObject _copyBullet;
    private GameObject Mazzle;
    private Transform _atari;

    // Start is called before the first frame update
    void Start()
    {
        _playerpos = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        //�v���C���[�̈ʒu�Ǝ����̈ʒu���v�Z���āA������ς���B
        _playerTrans = (_playerpos.transform.position - transform.position).normalized;
        FlipXBullet(_playerTrans);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FlipXBullet(Vector2 horizontal)
    {
        //�v���C���[�������̍��ɂ����獶�ɁA�E�ɂ�����E��velocity�œ������B
        if (horizontal.x > 0f)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            _rb.velocity = Vector2.right * _speed * 1;
        }
        else if (horizontal.x < 0f)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            _rb.velocity =  Vector2.right * _speed * -1;
        }
    }
    //�����蔻��ɓ���������A�����̃R�s�[�𐶐�����B
    public override void CopyTech()
    {
        Mazzle = GameObject.FindGameObjectWithTag("Mazzle");
        _atari = Mazzle.GetComponent<Transform>();
        Instantiate(_copyBullet, _atari.position, Quaternion.identity);
    }
}
