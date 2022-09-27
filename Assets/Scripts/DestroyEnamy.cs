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
        //gameobject�̒��g���Ȃ��Ă��G���[���o���Ȃ�����
        Debug.LogWarning("�~�~�b�N�̏ꍇ�̓~�~�b�N�ƃ~�~�b�N���j�ɃR���|�[�l���g�����܂��傤�B");
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //�G��HP��0�ɂȂ�����
        if(_enemyHP <= 0)
        {
            //�~�~�b�N����Ȃ��Ȃ�j�󂳂��B
            if (!_mimikku)
            {
                //�C�x���g��bool��true�Ȃ�C�x���g���N����B
                if (_event)
                {
                    _action.Invoke();
                }
                Destroy(this.gameObject);
            }
            else
            {
                //3�̒��g������΁A�~�~�b�N���j�𐶐����āA�V�[�����[�h��true�ɂ��āA���g��j�󂷂�B
                if (_mimikku && _mimikkuGekiha && _sceneLoad)
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
        //�a���G�t�F�N�g�������Ď��g��HP�����炷�B
        if(collision.gameObject.tag == ("Atari"))
        {
            Instantiate(_zangeki, transform.position, Quaternion.identity);
            _enemyHP--;
        }
        //������G�t�F�N�g�������āA������������j�󂵂���A���g��HP�����炷�B
        if (collision.gameObject.tag == ("Bullet"))
        {
            FindObjectOfType<GameManager>().AddScore(_score * 10);
            Destroy(collision.gameObject);
            Instantiate(_hit, transform.position, Quaternion.identity);
            _enemyHP = _enemyHP - 2;
        }
        //�v���C���[������������A�v���C���[��HP�����炷�B
        if(collision.gameObject.tag == "Player" && !GM.star)
        {
            Instantiate(_hit, collision.transform.position, Quaternion.identity);
            FindObjectOfType<GameManager>().AddLife(-5f);
            GM.StartCoroutine("StarTime");
        }
        //�ђʌn�̋�
        if(collision.gameObject.tag == "MimikkuBullet" && !_taiho)
        {
            Instantiate(_hit, transform.position, Quaternion.identity);
            _enemyHP = _enemyHP - 2;
        }
    }
}
