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
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("ミミックの場合はミミックとミミック撃破にコンポーネントをつけましょう。");
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
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
            _enemyHP--;
        }
        if (collision.gameObject.tag == ("Bullet"))
        {
            FindObjectOfType<GameManager>().AddScore(_score * 10);
            Destroy(collision.gameObject);
            Instantiate(_hit, transform.position, Quaternion.identity);
            _enemyHP = _enemyHP - 2;
        }
        if(collision.gameObject.tag == "Player" && !GM.star)
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5f);
            GM.StartCoroutine("StarTime");
        }
    }
}
