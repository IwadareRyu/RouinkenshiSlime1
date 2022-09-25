using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infolutedama : MonoBehaviour
{
    Vector2 _senterPos;
    Vector2 _rotaPos;
    float _startTime;
    //円運動の速さ
    [SerializeField] float _speed = 2f;
    //この変数は関係ない。
    [SerializeField] GameObject _hit;
    //時計回りか反時計回りを1か-1を入力する。
    [SerializeField,Range(1,-1)] float _minas = 1f;
    //円の大きさ
    [SerializeField]float _radius = 3f;
    //円運動を始める位置
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
        //ここでSetParentsを使って追尾させたいキャラの子にするのがよいと思う。

        //円運動のスタート位置
        _startTime = Time.time + _startCirclePos;
        //現在の位置から回るようにしている。
        _rotaPos = _senterPos;
        //中央からの距離をxとyのポジションの位置で計算する。
        _rotaPos.x += _radius * Mathf.Sin(2 * Mathf.PI * _speed * _startTime *_minas);
        _rotaPos.y += _radius * Mathf.Cos(2 * Mathf.PI * _speed * _startTime *_minas);
        //現在の位置を代入する。
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
