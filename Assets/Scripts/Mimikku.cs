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
    [SerializeField] GameObject _mazzleE;
    [Tooltip("�I(�댯�M��)���o���ʒu")]
    [SerializeField] GameObject _mazzle2;
    [Tooltip("!(�댯�M��)")]
    [SerializeField] GameObject _bikkuri;
    [Tooltip("�܂�������ԋ�")]
    [SerializeField] GameObject _bullet;
    [Tooltip("�v���C���[�Ɍ������Ĕ�ԋ�")]
    [SerializeField] GameObject _playerBullet;
    [Tooltip("���g�̌���")]
    float minas;
    public float _minasmimikku => minas;
    [Tooltip("���[�v����ʒu")]
    [SerializeField] GameObject _warp;
    [Tooltip("�q���𐶐�����ʒu(��)")]
    [SerializeField] GameObject[] _mazzleU;
    [Tooltip("�q���𐶐�����ʒu(��)")]
    [SerializeField] GameObject[] _mazzleL;
    [Tooltip("�q���𐶐�����ʒu(�E)")]
    [SerializeField] GameObject[] _mazzleR;
    [Tooltip("���[�v����ʒu")]
    [SerializeField] Transform[] _warpMazzle;
    [Tooltip("�ォ��~���Ă���~�~�b�N�q��")]
    [SerializeField] GameObject _parentsmimikku;
    [Tooltip("���E����~���Ă���~�~�b�N�q��")]
    [SerializeField] GameObject _parentsmimikkuLR;
    [Tooltip("���g(this.gameobject���Ɣ��̕�������ł��Ȃ��B)")]
    [SerializeField] GameObject _myMimikku;
    [Tooltip("���g(���̂ق�)")]
    [SerializeField] GameObject _hakomimikku;
    [Tooltip("�����_���ϐ�")]
    int ram2;
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
            Instantiate(_bikkuri, _mazzle2.transform.position, Quaternion.identity);
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
        yield return new WaitForSeconds(0.5f);
        Instantiate(_bullet, _mazzleE.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(_bullet, _mazzleE.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(_bullet, _mazzleE.transform.position, Quaternion.identity);
        //���̈ʒu�ֈړ�
        yield return new WaitForSeconds(3f);
        _myMimikku.transform.DOMove(_warpMazzle[0].position, _time).SetEase(Ease.Linear);
        _anim.Play("Syokanmae");
        
        //10��~�~�b�N�q��(������)�̏���
        for(var i = 0;i<10;i++)
        {
            yield return new WaitForSeconds(2f);
            int ram1 = Random.Range(0, 3);
            ram2 = ram1;
            Instantiate(_parentsmimikku, _mazzleU[ram2].transform.position,Quaternion.identity);
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
            _myMimikku.transform.DOMove(_warpMazzle[ram].position, _time).SetEase(Ease.Linear);

            for (var i = 0;i < 10;i++)
            {
                //���ƃ~�~�b�N(���E)������������B
                yield return new WaitForSeconds(2f);
                Instantiate(_bikkuri, _mazzle2.transform.position, Quaternion.identity);
                int ram1 = Random.Range(0, 3);
                Instantiate(_parentsmimikkuLR, _mazzleL[ram1].transform.position, Quaternion.identity);
                Instantiate(_playerBullet, _mazzleE.transform.position, Quaternion.identity);
            }

        }
        else
        {
            /*�E�̃p�^�[��*/
            //���g���ړ�������B
            _myMimikku.transform.DOMove(_warpMazzle[ram].position, _time).SetEase(Ease.Linear);

            for (var i = 0; i < 10; i++)
            {
                //���ƃ~�~�b�N(���E)������������B
                yield return new WaitForSeconds(2f);
                Instantiate(_bikkuri, _mazzle2.transform.position, Quaternion.identity);
                int ram1 = Random.Range(0, 3);
                Instantiate(_parentsmimikkuLR, _mazzleR[ram1].transform.position, Quaternion.identity);
                Instantiate(_playerBullet, _mazzleE.transform.position, Quaternion.identity);
            }

        }
        //�����E�̑ҋ@�ꏊ�Ƀ��[�v�����Ĕ��ɂȂ�B
        yield return new WaitForSeconds(5f);
        ram = Random.Range(3, 5);
        Instantiate(_warp, transform.position, Quaternion.identity);
        _myMimikku.transform.position = _warpMazzle[ram].position;
        Instantiate(_warp, transform.position, Quaternion.identity);
        _hakomimikku.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
