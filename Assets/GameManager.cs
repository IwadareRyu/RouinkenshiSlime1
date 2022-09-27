using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [Tooltip("プレイヤーのSpriteRenderer")]
    private SpriteRenderer pl;
    [SerializeField] Text _scoreText;
    [Tooltip("ライフの限界値")]
    [SerializeField] float _maxLife = 70f;
    [SerializeField] string _resultText = "ResultScore";
    [SerializeField] GameObject _gameOverCanvas;
    string _reScore;
    [Tooltip("現在のスコアの値")]
    [SerializeField]int _score = 0;
    [Tooltip("スコアの限界値")]
    int _maxScore = 999999;
    [Tooltip("現在のライフ値")]
    float _life;
    [Tooltip("無敵モード(デバック用でもある)")]
    [SerializeField] bool _godmode;
    [SerializeField] Slider _lifeGauge;
    [SerializeField] float _gaugeInterval = 1f;
    [Tooltip("GameOver時")]
    bool _isgameOver;
    public bool _gameover => _isgameOver;
    int _gameoverScore = -99999;
    [Tooltip("無敵時間")]
    bool _star;
    public bool star => _star;
    // Start is called before the first frame update
    void Start()
    {
        //GetConponent
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        _lifeGauge = _lifeGauge.GetComponent<Slider>();
        //DontDestroyOnLoadにGameManagerがあれば自身を破壊、なければ自身をDontDestroyOnLoadに移動してスコアに初期値を代入。
        if(FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            ShowScore();
        }
        //ライフの限界値を現在のライフに代入する。
        _life = _maxLife;
        //スコアの初期化
        _scoreText.text = _score.ToString("D6");
        AddScore(0);
        //ライフゲージの初期化。
        ChangeValue(1f);
    }
    /// <summary>リザルトシーンの際、scoreを表示する。</summary>
    private void ShowScore()
    {
        GameObject go = GameObject.Find(_resultText);
        Text text = go?.GetComponent<Text>();
        if (text)
        {
            text.text = _reScore;
        }

    }
    /// <summary>スコアの追加</summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {

        if (!_godmode)
        {
            //スコアを加算する前のスコアを代入する。
            int tempScore = _score;
            //2つの値の小さいほうが_scoreに代入される。
            _score = Mathf.Min(_score + score,_maxScore);
            //スコアを加算する前のスコアから、後のスコアまでの値を小さい値を代入しながら後のスコアの値になるまで代入する。
            DOTween.To(() => tempScore, x => { _scoreText.text = string.Format("{0:D6}",x.ToString("000000;-00000;")); },_score, _gaugeInterval).OnComplete(() => _scoreText.text = string.Format("{0:D6}",_score.ToString("000000;-00000;")));
            _scoreText.text = string.Format("{0:D6}",_score.ToString("000000;-00000;"));
        }

    }
    /// <summary>ライフの追加</summary>
    /// <param name="life"></param>
    public void AddLife(float life)
    {

        if (!_godmode)
        {
            _life = Mathf.Min(_life + life,_maxLife);
            ChangeValue(_lifeGauge.value + (life / _maxLife));
        }

    }
    /// <summary> ゲージ減る前と減った後の値を計算して、減った後の値まで値を減らす。</summary>
    /// <param name="value"></param>
    void ChangeValue(float value)
    {
        DOTween.To(() => _lifeGauge.value, x => _lifeGauge.value = x, value, _gaugeInterval).OnComplete(() => _lifeGauge.value = value);
    }
    //リザルトシーンへスコアを代入する。
    public void SetName(Text input)
    {
        _reScore = input.text;
    }
    /// <summary>無敵モード時の動作</summary>
    public void Continue()
    {
        pl.color = Color.yellow;
        AddScore(_gameoverScore);
        _life = 100;
        ChangeValue(1f);
        _gameOverCanvas.SetActive(false);
        _isgameOver = false; 
        _godmode = true;
        _star = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Fire3が押されたら即死する。
        if(Input.GetButtonDown("Fire3"))
        {
            AddLife(-100f);
        }
        //ライフが0になったらゲームオーバーになる。
        if (_life <= 0)
        {
            _isgameOver = true;
            _gameOverCanvas.SetActive(true);
        }
    }
    /// <summary>無敵時間</summary>
    /// <returns></returns>
    public IEnumerator StarTime()
    {
        //_starをtrueにして一定時間無敵時間を発生させる。
        SpriteRenderer pl = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
        _star = true;
        pl.color = new Color32(140,162,255,255);
        yield return new WaitForSeconds(1f);
        _star = false;
        pl.color = Color.white;
    }
}
