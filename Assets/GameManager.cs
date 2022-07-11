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
    int _life = 100;
    bool _isStarted;
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
        AddScore(0);
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
        _score += score;
        _scoreText.text = _score.ToString("D5");
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
