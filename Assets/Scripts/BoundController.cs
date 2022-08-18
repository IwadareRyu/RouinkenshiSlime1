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
    bool _createTime;
    SpriteRenderer ToshiyoriSp;
    public float minas;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        AttackAni =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("リストの長さ " + _copyList.Count);
        h = Input.GetAxis("Horizontal");
        FlipX(h);
        if(Input.GetButtonDown("Fire1") && !_cooltime)
        {
            //_Attack.gameObject.SetActive(true);
            //if (_copyList.Count > 0)
            //{
            //    CopyBase copy = _copyList[0];
            //    _copyList.RemoveAt(0);
            //    copy.CopyTech();
            //}
            _cooltime = true;
            AttackAni.Play("AttackAni");
            Instantiate(AttackSE, this.transform.position, this.transform.rotation);
            StartCoroutine(Attacktime());
        }
        if(Input.GetButtonDown("Jump") && !_createTime)
        {
            Instantiate(_createG, _mazzleG.transform.position, Quaternion.identity);
            _createTime = true;
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
        yield return new WaitForSeconds(2.0f);
        _cooltime = false;


    }
    /// <summary>一回GetCopyでここを呼んだのですが、Countの長さが変になります。 </summary>
    /// <param name="copy"></param>
    //public void GetCopy(CopyBase copy)
    //{
    //    //while(_copyList.Count < 6)
    //    //{
    //    _copyList.Add(copy);
    //    Debug.Log("リストの長さ " + _copyList.Count);
    //    //}
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (audio != null)
        {
            audio.Play();
        }

        Instantiate(Effect, transform.position, transform.rotation);
        if(collision.gameObject.tag =="Ground" || collision.gameObject.tag == "HomiGround")
        {
            _rb2d.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
            _createTime = false;
        }

        if(collision.gameObject.tag == "InsGround")
        {
            _rb2d.AddForce(Vector2.up * _jumpPower * 1.5f, ForceMode2D.Impulse);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //if(collision.gameObject.tag == "EnemyBullet")
    //    //{
    //    //    FindObjectOfType<GameManager>().AddLife(-3);
    //    //}
    //    //if (collision.gameObject.tag == "Enemy")
    //    //{
    //    //    FindObjectOfType<GameManager>().AddLife(-5);
    //    //}
    //}
}
