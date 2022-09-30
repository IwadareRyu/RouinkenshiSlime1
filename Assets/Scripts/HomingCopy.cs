using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingCopy : MonoBehaviour
{
    Rigidbody2D rb;
    private GameObject Enemy;
    [SerializeField] float _speed = 15f;
    [SerializeField] float _limitSpeed = 30f;
    [SerializeField] float _inpulseSpeed = 30f;
    Transform _bulletTurn;
    private Transform _enemyturn;
    [Tooltip("�v���C���[�̌��������o���邽�߂̕ϐ��B")]
    BoundController _muki;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        _bulletTurn = GetComponent<Transform>();
        Enemy = GameObject.FindGameObjectWithTag("HomingEnemy");
        _enemyturn = Enemy?.GetComponent<Transform>();

        if (Enemy)
        {
            //�v���C���[�̌��������o���A���̌����ɗ͂�������B
            _muki = GameObject.FindWithTag("Player").GetComponent<BoundController>();
            rb.AddForce(Vector2.right * _inpulseSpeed * _muki._minas, ForceMode2D.Impulse);
        }
        else
        {
            //�v���C���[�����Ȃ�������j�󂷂�B
            Destroy(gameObject);
        }
        Destroy(gameObject, 5.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        //�G�Ǝ����̋�����Ɍv�Z���Ēǔ�������B
        Vector3 vector3 = _enemyturn.position - _bulletTurn.position;
        rb.AddForce(vector3.normalized * _speed);
        FlipX(vector3.x);
        //�������Ȃ��悤��X,Y�̃X�s�[�h�̐����B
        float speedX = Mathf.Clamp(rb.velocity.x, -_limitSpeed, _limitSpeed);
        float speedY = Mathf.Clamp(rb.velocity.y, -_limitSpeed, _limitSpeed);
        rb.velocity = new Vector3(speedX, speedY);
    }
    /// <summary>���̌���(Scale)��ς���B</summary>
    /// <param name="horizontal"></param>
    void FlipX(float horizontal)
    {

        if (horizontal > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }

    }
}
