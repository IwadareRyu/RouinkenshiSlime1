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
    [SerializeField] GameObject _sceneLoad;
    [SerializeField]bool _taiho;
    [SerializeField] bool _event;
    [SerializeField] UnityEvent _action;
    // Start is called before the first frame update
    void Start()
    {
        //gameobjectの中身がなくてもエラーを出さない処理
        Debug.LogWarning("ミミックの場合はミミックとミミック撃破にコンポーネントをつけましょう。");
    }

    // Update is called once per frame
    void Update()
    {
        //敵のHPが0になった時
        if(_enemyHP <= 0)
        {
            //イベントのboolがtrueならイベントが起こる。
            if (_event)
            {
                _action.Invoke();
            }
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //斬撃エフェクト生成して自身のHPを減らす。
        if(collision.gameObject.tag == ("Atari"))
        {
            Instantiate(_zangeki, transform.position, Quaternion.identity);
            _enemyHP--;
        }
        //当たりエフェクト生成して、当たった球を破壊した後、自身のHPを減らす。
        if (collision.gameObject.tag == ("Bullet"))
        {
            FindObjectOfType<GameManager>().AddScore(_score * 10);
            Destroy(collision.gameObject);
            Instantiate(_hit, transform.position, Quaternion.identity);
            _enemyHP = _enemyHP - 2;
        }
    }
}
