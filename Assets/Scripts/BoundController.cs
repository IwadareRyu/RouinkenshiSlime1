using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float Speed = 3f;
    float h;
    [SerializeField] float _jumpPower;
    [Tooltip("�U���̃N�[���^�C��")]
    bool _cooltime;
    [Tooltip("�U���̓�����͈�")]
    [SerializeField] GameObject _Attack;
    [Tooltip("�U���̃A�j���[�V����")]
    Animator AttackAni;
    [Tooltip("�U����SE�̃I�u�W�F�N�g")]
    [SerializeField] GameObject AttackSE;
    [Tooltip("���ꐶ������ꏊ�̃I�u�W�F�N�g")]
    [SerializeField] GameObject _mazzleG;
    [Tooltip("����̃I�u�W�F�N�g")]
    [SerializeField] GameObject _createG;
    [Tooltip("����𐶐��𐧌�����bool�^")]
    bool _createTime;
    [Tooltip("�E�������Ă�����+1�A���������Ă�����-1�B")]
    float minas = 1;
    public float _minas => minas;
    GameManager _gm;
    [Tooltip("���g���C���邽�߂̕ϐ��B")]
    SceneLoader _activeLoad;

    // Start is called before the first frame update
    void Start()
    {
        //���ꂼ��̗v�f��GetConponent����B
        _rb = GetComponent<Rigidbody2D>();
        AttackAni =GetComponent<Animator>();
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        _activeLoad = GameObject.FindGameObjectWithTag("GM").GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gm._gameover)
        {
            //�v���C���[�̍��E�̓����B
            h = Input.GetAxis("Horizontal");
            FlipX(h);
            //�U��
            if (Input.GetButtonDown("Fire1") && !_cooltime)
            {
                _cooltime = true;
                AttackAni.Play("AttackAni");
                Instantiate(AttackSE, this.transform.position, this.transform.rotation);
                StartCoroutine(Attacktime());
            }
            //����̐���
            if (Input.GetButtonDown("Jump") && !_createTime)
            {
                Instantiate(_createG, _mazzleG.transform.position, Quaternion.identity);
                _createTime = true;
            }
            //���g���C
            if(Input.GetButtonDown("Fire2"))
            {
                _activeLoad.ActiveSceneLoad();
            }
        }
        else
        {
            h = 0;
        }
    }
    private void FixedUpdate()
    {
        //���E�ɓ��͂��ꂽ�Ƃ��̓����̌v�Z�B
        _rb.velocity = new Vector2(h * Speed,_rb.velocity.y);
    }

    void FlipX(float horizontal)
    {
        //���ɓ������獶�������A�E�ɓ�������E�������B
        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            minas = 1;
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            minas = -1;
        }
    }
    /// <summary> �U���̎���</summary>

    IEnumerator Attacktime()
    {
        yield return new WaitForSeconds(0.1f);
        _Attack.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _Attack.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        _Attack.gameObject.SetActive(true);
        Instantiate(AttackSE, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(0.3f);
        _Attack.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        _cooltime = false;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource audio = GetComponent<AudioSource>();
        //�����ɓ��������Ƃ������Đ�����B
        if (audio != null)
        {
            audio.Play();
        }
        //�n�ʂ��G�ɓ����������A��ɗ͂�������B
        if(collision.gameObject.tag =="Ground" || collision.gameObject.tag == "HomiGround" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "HomingEnemy")
        {
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _createTime = false;
        }
        if (collision.gameObject.tag == "InsGround")
        {
            _rb.AddForce(Vector2.up * _jumpPower * 1.5f, ForceMode2D.Impulse);
        }
    }
}
