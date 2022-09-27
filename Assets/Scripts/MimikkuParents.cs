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
    [Tooltip("�v���C���[��position")]
    private GameObject _playerpos;
    [Tooltip("�J�[�u����ꏊ�����߂�B")]
    [SerializeField] float _playerOffest = 2f;
    [Tooltip("�J�[�u�̑����B")]
    [SerializeField] float _cavePower = 2f;
    float _thisX;
    bool rotation0;
    /// <summary>�����̃R�s�[�𐶐�����֐�</summary>
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
        //���ɓ������B
        _rb.velocity = Vector2.down * _speed;
        //������ς���B
        transform.Rotate(new Vector3(0, 0, -90f));
    }
    private void Update()
    {

        //null����
        if(_playerpos)
        {

            //���g�ƃv���C���[��y�̋�����Offest�̒l��菬����������
            if(transform.position.y - _playerpos.transform.position.y < _playerOffest)
            {

                if(_thisX == 0)
                {
                    //���g�ƃv���C���[��x�̈ʒu���v���X(�v���C���[�����ɂ���)�Ȃ�1�A�}�C�i�X(�v���C���[���E�ɂ���)�Ȃ�-1��������B
                    _thisX = ( _playerpos.transform.position.x > transform.position.x) ? 1 : -1;
                }

                if (!rotation0)
                {
                    //���g��rotation�����ɖ߂��A�܂���]���Ȃ��悤bool�^��true�ɂ���(���Ȃ��Ƒ��]����)�B
                    transform.Rotate(new Vector3(0, 0, 90f));
                    rotation0 = true;
                }
                //��������B
                FlipX(_thisX);
                //�����E�ɗ͂�������B
                _rb.AddForce(_thisX * Vector2.right * _cavePower);

            }

        }

    }

    void FlipX(float horizontal)
    {
        //����
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
