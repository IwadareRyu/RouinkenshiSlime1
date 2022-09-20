using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] float _maxLife = 100;
    [SerializeField] string _resultText = "ResultScore";
    [SerializeField] GameObject _gameOverCanvas;
    string _reScore;
    [SerializeField]int _score = 0;
    int _maxScore = 999999;
    [SerializeField]float _life = 100;
    bool _isStarted;
    [SerializeField] bool _godmode;
    [SerializeField] Slider _lifeGauge;
    [SerializeField] float _gaugeInterval = 1f;
    bool _isgameOver;
    public bool _gameover => _isgameOver;
    int _gameoverScore = -99999;
    // Start is called before the first frame update
    void Start()
    {
        _lifeGauge = _lifeGauge.GetComponent<Slider>();
        if(FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            ShowScore();
            _isStarted = true;
        }
        _life = _maxLife;
        _scoreText.text = _score.ToString("D6");
        AddScore(0);
        ChangeValue(1f);
    }

    private void ShowScore()
    {
        GameObject go = GameObject.Find(_resultText);
        Text text = go?.GetComponent<Text>();

        if(text)
        {
            text.text = _reScore;
        }

    }

    public void AddScore(int score)
    {

        if (!_godmode)
        {
            int tempScore = _score;
            _score = Mathf.Min(_score + score,_maxScore);
            DOTween.To(() => tempScore, x => { _scoreText.text = string.Format("{0:D6}",x.ToString("000000;-00000;")); },_score, _gaugeInterval).OnComplete(() => _scoreText.text = string.Format("{0:D6}",_score.ToString("000000;-00000;")));
            _scoreText.text = string.Format("{0:D6}",_score.ToString("000000;-00000;"));
        }

    }

    public void AddLife(float life)
    {

        if (!_godmode)
        {
            _life = Mathf.Min(_life + life,_maxLife);
            ChangeValue(_lifeGauge.value + life / _maxLife);
        }

    }
    void ChangeValue(float value)
    {
        DOTween.To(() => _lifeGauge.value, x => _lifeGauge.value = x, value, _gaugeInterval);
    }

    public void SetName(Text input)
    {
        _reScore = input.text;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (_isStarted) ShowScore();
    }

    public void Continue()
    {
        AddScore(_gameoverScore);
        _life = 100;
        ChangeValue(1f);
        _gameOverCanvas.SetActive(false);
        _isgameOver = false; 
        _godmode = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (_life <= 0)
        {
            _isgameOver = true;
            _gameOverCanvas.SetActive(true);
        }
    }
}
