using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour
{
    Rigidbody2D _rb2d;
    [SerializeField] GameObject Effect;
    [SerializeField] float Speed = 3f;
    float h;
    [SerializeField] float _jumpPower;
    bool _cooltime;
    [SerializeField] GameObject _Attack;
    Animator AttackAni;
    [SerializeField] GameObject AttackSE;
    [SerializeField] GameObject _mazzleG;
    [SerializeField] GameObject _createG;
    [SerializeField] GameObject _damage;
    bool _createTime;
    float minas = 1;
    public float _minas => minas;
    GameManager _gm;
    SceneLoader _activeLoad;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        AttackAni =GetComponent<Animator>();
        _gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        _activeLoad = GameObject.FindGameObjectWithTag("GM").GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gm._gameover)
        {
            // Debug.Log("ƒŠƒXƒg‚Ì’·‚³ " + _copyList.Count);
            h = Input.GetAxis("Horizontal");
            FlipX(h);
            if (Input.GetButtonDown("Fire1") && !_cooltime)
            {
                _cooltime = true;
                AttackAni.Play("AttackAni");
                Instantiate(AttackSE, this.transform.position, this.transform.rotation);
                StartCoroutine(Attacktime());
            }
            if (Input.GetButtonDown("Jump") && !_createTime)
            {
                Instantiate(_createG, _mazzleG.transform.position, Quaternion.identity);
                _createTime = true;
            }
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
        _rb2d.velocity = new Vector2(h * Speed,_rb2d.velocity.y);
    }

    void FlipX(float horizontal)
    {

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

        if (audio != null)
        {
            audio.Play();
        }

        Instantiate(Effect, transform.position, transform.rotation);
        if(collision.gameObject.tag =="Ground" || collision.gameObject.tag == "HomiGround" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "HomingEnemy")
        {
            _rb2d.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _createTime = false;
        }

        if (collision.gameObject.tag == "InsGround")
        {
            _rb2d.AddForce(Vector2.up * _jumpPower * 1.5f, ForceMode2D.Impulse);
        }
    }
    public void Damage()
    {
        if(!_gm.star)
        Instantiate(_damage, transform.position, Quaternion.identity);
        _gm.StartCoroutine("StarTime");
    }
}
