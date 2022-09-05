using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtobi : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Vector2 _playerTrams;
    float transx;
    float transy;
    [SerializeField] GameObject _mazzleE;
    [SerializeField] GameObject _mazzle2;
    [SerializeField] GameObject _bikkuri;
    [SerializeField] GameObject _bullet;
    float minas;
    public float _minasmimikku => minas;
    [SerializeField] GameObject _warp;
    [SerializeField] GameObject[] _mazzleU;
    [SerializeField] GameObject[] _mazzleL;
    [SerializeField] GameObject[] _mazzleR;
    [SerializeField] Transform[] _warpMazzle;
    [SerializeField] GameObject _parentsmimikku;
    [SerializeField] GameObject _parentsmimikku2;
    [SerializeField] GameObject _myMimikku;
    [SerializeField] GameObject _hakomimikku;
    int ram2;
    public bool _attackTime;
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_attackTime)
        {
            _attackTime = false;
            Instantiate(_bikkuri, _mazzle2.transform.position, Quaternion.identity);
            _anim.Play("mumukku2");
            StartCoroutine(EnemyTime());
        }
    }
    private void FixedUpdate()
    {
        _playerTrams = (_player.transform.position - this.transform.position).normalized;
        FlipX(_playerTrams);
        transx = _player.transform.position.x;
        transy = _player.transform.position.y;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        StartCoroutine("Dammage");
    //    }

    //}
    void FlipX(Vector2 horizontal)
    {

        if (horizontal.x < 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            minas = 1;
        }
        else if (horizontal.x > 0)
        {
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            minas = -1;
        }
    }
    IEnumerator EnemyTime()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(_bullet, _mazzleE.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(_bullet, _mazzleE.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(_bullet, _mazzleE.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        Instantiate(_warp, transform.position, Quaternion.identity);
        _myMimikku.transform.position = _warpMazzle[0].position;
        Instantiate(_warp, transform.position, Quaternion.identity);
        _anim.Play("Syokanmae");
        for(var i = 0;i<10;i++)
        {
            yield return new WaitForSeconds(2f);
            int ram1 = Random.Range(0, 3);
            ram2 = ram1;
            Instantiate(_parentsmimikku, _mazzleU[ram2].transform.position,Quaternion.identity);
        }
        yield return new WaitForSeconds(5f);
        int ram = Random.Range(1, 3);
        Debug.Log(ram);
        _anim.Play("BeforeAttack");
        if(ram == 1)
        {
            Instantiate(_warp, transform.position, Quaternion.identity);
            _myMimikku.transform.position = _warpMazzle[ram].position;
            Instantiate(_warp, transform.position, Quaternion.identity);
            Instantiate(_bikkuri, _mazzle2.transform.position, Quaternion.identity);
            for (var i = 0;i < 10;i++)
            {
                yield return new WaitForSeconds(2f);
                int ram1 = Random.Range(0, 3);
                Instantiate(_parentsmimikku2, _mazzleL[ram1].transform.position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(_warp, transform.position, Quaternion.identity);
            _myMimikku.transform.position = _warpMazzle[ram].position;
            Instantiate(_warp, transform.position, Quaternion.identity);
            Instantiate(_bikkuri, _mazzle2.transform.position, Quaternion.identity);
            for (var i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(2f);
                int ram1 = Random.Range(0, 3);
                Instantiate(_parentsmimikku2, _mazzleR[ram1].transform.position, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(5f);
        ram = Random.Range(3, 5);
        Instantiate(_warp, transform.position, Quaternion.identity);
        _myMimikku.transform.position = _warpMazzle[ram].position;
        Instantiate(_warp, transform.position, Quaternion.identity);
        _hakomimikku.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
