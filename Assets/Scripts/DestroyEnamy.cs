using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyEnamy : MonoBehaviour
{
    [SerializeField] int _score = 100;
    [SerializeField] int _enemyHP = 1;
    [SerializeField] GameObject _zangeki;
    [SerializeField] GameObject _hit;
    [SerializeField] GameObject _mimikku;
    [SerializeField] GameObject _mimikkuGekiha;
    [SerializeField] GameObject _sceneLoad;
    private GameManager GM;
    [SerializeField]bool _taiho;
    [SerializeField] bool _event;
    [SerializeField] UnityEvent _action;
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
                if (_event)
                {
                    _action.Invoke();
                }
                Destroy(this.gameObject);
            }
            else
            {
                if (_mimikku && _mimikkuGekiha)
                {
                    Instantiate(_mimikkuGekiha, transform.position, Quaternion.identity);
                    _sceneLoad.SetActive(true);
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
        if(collision.gameObject.tag == "MimikkuBullet" && !_taiho)
        {
            Instantiate(_hit, transform.position, Quaternion.identity);
            _enemyHP = _enemyHP - 2;
        }
    }
}
