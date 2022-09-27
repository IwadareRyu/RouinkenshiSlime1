using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumeBulletCopy : MonoBehaviour
{
    [SerializeField] float _speed = 15f;
    Rigidbody2D rb;
    BoundController _muki;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _muki = GameObject.FindWithTag("Player").GetComponent<BoundController>();
        //�v���C���[�̌����ɍ��킹�č����E�ɋ����΂��B(���̌���(Scale)���ς���B)
        rb.velocity = Vector2.right * _speed * _muki._minas;
        transform.localScale = new Vector3(_muki._minas, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}
