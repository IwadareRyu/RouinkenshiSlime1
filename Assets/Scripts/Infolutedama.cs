using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infolutedama : MonoBehaviour
{
    [Tooltip("�����̈ʒu")]
    Vector2 _senterPos;
    [Tooltip("���ʒu")]
    Vector2 _rotaPos;
    [Tooltip("�ŏ��̈ʒu")]
    float _startTime;
    [Tooltip("�~�^���̑���")]
    [SerializeField] float _speed = 2f;
    [SerializeField] GameObject _hit;
    [Tooltip("���v��肩�����v����1��-1����͂���B")]
    [SerializeField,Range(1,-1)] float _minas = 1f;
    [Tooltip("�~�̑傫��")]
    [SerializeField]float _radius = 3f;
    [Tooltip("�~�^�����n�߂�ʒu")]
    [SerializeField] float _startCirclePos;
    // Start is called before the first frame update
    void Start()
    {
        _senterPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        //������SetParents���g���Ēǔ����������L�����̎q�ɂ���̂��悢�Ǝv���B

        //�~�^���̃X�^�[�g�ʒu
        _startTime = Time.time + _startCirclePos;
        //���݂̈ʒu������悤�ɂ��Ă���B
        _rotaPos = _senterPos;
        //��������̋�����x��y�̃|�W�V�����̈ʒu�Ōv�Z����B
        _rotaPos.x += _radius * Mathf.Cos(2 * Mathf.PI * _speed * _startTime *_minas);
        _rotaPos.y += _radius * Mathf.Sin(2 * Mathf.PI * _speed * _startTime *_minas);
        //���݂̈ʒu��������B
        transform.position = _rotaPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player" && !GM.star)
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5f);
            GM.StartCoroutine("StarTime");
        }

    }
}
