using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnamy : MonoBehaviour
{
    [SerializeField] int _score = 100;
    [SerializeField] int _enemyHP = 1;
    [SerializeField] GameObject _zangeki;
    [SerializeField] GameObject _hit;
    [SerializeField] GameObject _mimikku;
    [SerializeField] GameObject _mimikkuGekiha;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("�~�~�b�N�̏ꍇ�̓~�~�b�N�ƃ~�~�b�N���j�ɃR���|�[�l���g�����܂��傤�B");
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyHP <= 0)
        {
            if (!_mimikku)
            {
                Destroy(this.gameObject);
            }
            else
            {
                if (_mimikku && _mimikkuGekiha)
                {
                    Instantiate(_mimikkuGekiha, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Atari"))
        {
            Instantiate(_zangeki, transform.position, Quaternion.identity);
            _enemyHP --;
        }
        if (collision.gameObject.tag == ("Bullet"))
        {
            FindObjectOfType<GameManager>().AddScore(_score * 10);
            Destroy(collision.gameObject);
            Instantiate(_hit, transform.position, Quaternion.identity);
            _enemyHP--;
        }
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5f);

        }
    }
}
