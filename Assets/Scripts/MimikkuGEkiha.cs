using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MimikkuGEkiha : MonoBehaviour
{
    GameObject _player;
    Vector2 _playerTrams;
    float minas;
    Rigidbody2D _rb;
    [SerializeField]float _power = 5f;
    [SerializeField] GameObject _audio;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        //�R���[�`��
        StartCoroutine("GekihaTime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //�v���C���[�̈ʒu�Ǝ����̈ʒu���v�Z���āA������ς���B
        _playerTrams = (_player.transform.position - transform.position).normalized;
        FlipX(_playerTrams);
    }
    void FlipX(Vector2 horizontal)
    {
        //����
        if (horizontal.x < 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            minas = -1;
        }
        else if (horizontal.x > 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            minas = 1;
        }
    }
    /// <summary>���̎��Ԃ���������ɁA�΂ߏ�ɗ͂������A�����o���B</summary>
    /// <returns></returns>
    IEnumerator GekihaTime()
    {
        yield return new WaitForSeconds(3.5f);
        _rb.AddForce(Vector2.up * _power, ForceMode2D.Impulse);
        _rb.AddForce(Vector2.left * _power * minas, ForceMode2D.Impulse);
        _audio.SetActive(true);
    }
}
