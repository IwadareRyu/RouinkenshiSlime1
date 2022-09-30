using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mimikku : MonoBehaviour
{
    [Tooltip("�v���C���[")]
    [SerializeField] GameObject _player;
    [Tooltip("�v���C���[�̈ʒu")]
    [SerializeField] Vector2 _playerTrams;
    [Tooltip("�����΂������ʒu")]
    [SerializeField] GameObject _muzzleE;
    [Tooltip("�I(�댯�M��)���o���ʒu")]
    [SerializeField] GameObject _muzzle2;
    [Tooltip("!(�댯�M��)")]
    [SerializeField] GameObject _bikkuri;
    [Tooltip("�܂�������ԋ�")]
    [SerializeField] GameObject _bullet;
    [Tooltip("�v���C���[�Ɍ������Ĕ�ԋ�")]
    [SerializeField] GameObject _playerBullet;
    [Tooltip("���g�̌���")]
    float minas;
    public float _minasmimikku => minas;
    [Tooltip("���[�v����ۂɏo��G�t�F�N�g")]
    [SerializeField] GameObject _warp;
    [Tooltip("�q���𐶐�����ʒu(��)")]
    [SerializeField] GameObject[] _muzzleU;
    [Tooltip("�q���𐶐�����ʒu(��)")]
    [SerializeField] GameObject[] _muzzleL;
    [Tooltip("�q���𐶐�����ʒu(�E)")]
    [SerializeField] GameObject[] _muzzleR;
    [Tooltip("���[�v����ʒu")]
    [SerializeField] Transform[] _warpMuzzle;
    [Tooltip("�ォ��~���Ă���~�~�b�N�q��")]
    [SerializeField] GameObject _parentsmimikku;
    [Tooltip("���E����~���Ă���~�~�b�N�q��")]
    [SerializeField] GameObject _parentsmimikkuLR;
    [Tooltip("���g(this.gameobject���Ɣ��̕�������ł��Ȃ��B)")]
    [SerializeField] GameObject _myMimikku;
    [Tooltip("���g(���̂ق�)")]
    [SerializeField] GameObject _hakomimikku;
    [Tooltip("�����_���ϐ�")]
    int _ram2;
    [Tooltip("�U�����Ă��鎞�Ԃ�bool�^")]
    public bool _attackTime;
    [Tooltip("���g�̃A�j���[�V����")]
    Animator _anim;
    [Tooltip("dotween�Ŏ��g���ړ����鎞��")]
    float _time = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_attackTime)
        {
            //false�ɂ��ăR���[�`�������Ȃ��悤�ɂ���
            _attackTime = false;
            Instantiate(_bikkuri, _muzzle2.transform.position, Quaternion.identity);
            _anim.Play("mumukku2");
            //�R���[�`���X�^�[�g
            StartCoroutine(EnemyTime());
        }
    }
    private void FixedUpdate()
    {
        //���g�̌������v���C���[�̈ʒu�ɍ��킹�ĕύX����B
        _playerTrams = (_player.transform.position - this.transform.position).normalized;
        FlipX(_playerTrams);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        StartCoroutine("Dammage");
    //    }

    //}
    void FlipX(Vector2 horizontal)
    {
        //����
        if (horizontal.x < 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            minas = 1;
        }
        else if (horizontal.x > 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            minas = -1;
        }

    }
    IEnumerator EnemyTime()
    {
        //������*3
        yield return new WaitForSeconds(0.2f);
        for (var i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(_bullet, _muzzleE.transform.position, Quaternion.identity);
        }
        //���̈ʒu�ֈړ�
        yield return new WaitForSeconds(3f);
        _myMimikku.transform.DOMove(_warpMuzzle[0].position, _time).SetEase(Ease.Linear);
        _anim.Play("Syokanmae");
        
        //10��~�~�b�N�q��(������)�̏���
        for(var i = 0;i<10;i++)
        {
            yield return new WaitForSeconds(2f);
            int ram1 = Random.Range(0, 3);
            _ram2 = ram1;
            Instantiate(_parentsmimikku, _muzzleU[_ram2].transform.position,Quaternion.identity);
        }

        //���ɍs�����E�ɍs�����������_���ϐ��Ń����_���ɂ���B
        yield return new WaitForSeconds(5f);
        int ram = Random.Range(1, 3);
        Debug.Log(ram);
        _anim.Play("BeforeAttack");

        if(ram == 1)
        {
            /*���̃p�^�[��*/
            //���g���ړ�������B
            _myMimikku.transform.DOMove(_warpMuzzle[ram].position, _time).SetEase(Ease.Linear);

            for (var i = 0;i < 10;i++)
            {
                yield return new WaitForSeconds(2f);
                SyokanTime(_muzzleL);
            }

        }
        else
        {
            /*�E�̃p�^�[��*/
            //���g���ړ�������B
            _myMimikku.transform.DOMove(_warpMuzzle[ram].position, _time).SetEase(Ease.Linear);

            for (var i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(2f);
                SyokanTime(_muzzleR);
            }

        }
        //�����E�̑ҋ@�ꏊ�Ƀ��[�v�����Ĕ��ɂȂ�B
        yield return new WaitForSeconds(5f);
        ram = Random.Range(3, 5);
        Instantiate(_warp, transform.position, Quaternion.identity);
        _myMimikku.transform.position = _warpMuzzle[ram].position;
        Instantiate(_warp, transform.position, Quaternion.identity);
        _hakomimikku.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    void SyokanTime(GameObject[] _muzzleLR)
    {
        //���ƃ~�~�b�N(���E)������������B
        Instantiate(_bikkuri, _muzzle2.transform.position, Quaternion.identity);
        int ram1 = Random.Range(0, 3);
        Instantiate(_parentsmimikkuLR, _muzzleLR[ram1].transform.position, Quaternion.identity);
        Instantiate(_playerBullet, _muzzleE.transform.position, Quaternion.identity);
    }

}
