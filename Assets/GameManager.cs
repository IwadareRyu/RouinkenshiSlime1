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
    string _reScore;
    int _score = 0;
    int _maxScore = 999999;
    [SerializeField]float _life = 100;
    bool _isStarted;
    [SerializeField] bool _godmode;
    [SerializeField] Slider _lifeGauge;
    [SerializeField] float _gaugeInterval = 1f;
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
            _score = Mathf.Min(_score + score, _maxScore);
            DOTween.To(() => tempScore, x => { _scoreText.text = x.ToString("D6"); },_score, _gaugeInterval).OnComplete(() => _scoreText.text = _score.ToString("d6"));
            _scoreText.text = _score.ToString("D6");
        }

    }

    public void AddLife(float life)
    {

        if (!_godmode)
        {
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
