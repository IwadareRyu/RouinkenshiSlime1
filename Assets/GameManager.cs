using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _scoreText;
    [SerializeField] int _maxLife = 100;
    [SerializeField] string _resultText = "ResultScore";
    string _reScore;
    int _score = 0;
    [SerializeField]int _life = 100;
    bool _isStarted;
    [SerializeField] bool _godmode;
    [SerializeField] Slider _lifeGauge;
    // Start is called before the first frame update
    void Start()
    {
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
        AddLife(0);
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
            _score += score;
            _scoreText.text = _score.ToString("D6");
        }
    }
    public void SetName(Text input)
    {
        _reScore = input.text;
    }
    private void OnLevelWasLoaded(int level)
    {
        if (_isStarted) ShowScore();
    }
    public void AddLife(int life)
    {
        if (!_godmode)
        {
            _life += life;
            _lifeGauge.value = (float)_life / _maxLife;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
