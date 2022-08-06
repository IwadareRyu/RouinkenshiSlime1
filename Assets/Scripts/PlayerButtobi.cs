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
    public float minas;
    [SerializeField] GameObject _warp;
    [SerializeField] GameObject[] _mazzleU;
    [SerializeField] GameObject[] _mazzleL;
    [SerializeField] GameObject[] _mazzleR;
    [SerializeField] GameObject _parentsmimikku;
    int ram2;
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(_bikkuri, _mazzle2.transform.position, Quaternion.identity);
        StartCoroutine(EnemyTime());
    }

    // Update is called once per frame
    void Update()
    {

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
        transform.position = new Vector2(-2,1.5f);
        Instantiate(_warp, transform.position, Quaternion.identity);
        for(var i = 0;i<10;i++)
        {
            yield return new WaitForSeconds(2f);
            int ram1 = Random.Range(0, 3);
            ram2 = ram1;
            Instantiate(_parentsmimikku, _mazzleU[ram2].transform.position,Quaternion.identity);
        }
    }
}
