using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBullet : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    Rigidbody2D rb;
    [SerializeField] GameObject _hit;
    [SerializeField] float _minas = 1f;
    [Tooltip("�v���C���[�����g�ɓ����邩������Ȃ����B")]
    [SerializeField] bool _isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //���ɋ����o���B
        rb.velocity = Vector2.down * _speed * _minas;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //�ǂ��n�ʂɓ���������j��B
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        //�v���C���[�ւ̃_���[�W(!GM.star�͖��G���Ԃ���Ȃ��Ƃ�)
        if (collision.gameObject.tag == "Player" && !GM.star && !_isPlayer)
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5f);
            GM.StartCoroutine("StarTime");
        }
    }
}
