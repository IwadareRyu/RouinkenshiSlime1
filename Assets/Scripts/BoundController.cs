using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float Speed = 3f;
    float h;
    [SerializeField] float _jumpPower;
    [Tooltip("攻撃のクールタイム")]
    bool _cooltime;
    [Tooltip("攻撃の当たり範囲")]
    [SerializeField] GameObject _Attack;
    [Tooltip("攻撃のアニメーション")]
    Animator AttackAni;
    [Tooltip("攻撃のSEのオブジェクト")]
    [SerializeField] GameObject AttackSE;
    [Tooltip("足場生成する場所のオブジェクト")]
    [SerializeField] GameObject _mazzleG;
    [Tooltip("足場のオブジェクト")]
    [SerializeField] GameObject _createG;
    [Tooltip("足場を生成を制限するbool型")]
    bool _createTime;
    [Tooltip("右を向いていたら+1、左を向いていたら-1。")]
    float minas = 1;
    public float _minas => minas;
    GameManager _gm;
    [Tooltip("リトライするための変数。")]
    SceneLoader _activeLoad;

    // Start is called before the first frame update
    void Start()
    {
        //それぞれの要素をGetConponentする。
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
            //プレイヤーの左右の動き。
            h = Input.GetAxis("Horizontal");
            FlipX(h);
            //攻撃
            if (Input.GetButtonDown("Fire1") && !_cooltime)
            {
                _cooltime = true;
                AttackAni.Play("AttackAni");
                Instantiate(AttackSE, this.transform.position, this.transform.rotation);
                StartCoroutine(Attacktime());
            }
            //足場の生成
            if (Input.GetButtonDown("Jump") && !_createTime)
            {
                Instantiate(_createG, _mazzleG.transform.position, Quaternion.identity);
                _createTime = true;
            }
            //リトライ
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
        //左右に入力されたときの動きの計算。
        _rb.velocity = new Vector2(h * Speed,_rb.velocity.y);
    }

    void FlipX(float horizontal)
    {
        //左に動いたら左を向く、右に動いたら右を向く。
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
    /// <summary> 攻撃の時間</summary>

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
        //何かに当たったとき音を再生する。
        if (audio != null)
        {
            audio.Play();
        }
        //地面か敵に当たった時、上に力を加える。
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
