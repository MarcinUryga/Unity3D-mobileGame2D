using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    private int _actualScore;
    private int _highScore;

    public Text highScore;
    public Text actualScore;

    // Use this for initialization
    void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        _actualScore = 0;
        highScore.text = _highScore.ToString();
    }

    public int GetHighScore()
    {
        return _highScore;
    }

    public void addPoint()
    {
        _actualScore++;
        actualScore.text = _actualScore.ToString();
    }

    public bool TrySetHighScore()
    {
        if (_actualScore <= _highScore)
            return false;

        _highScore = _actualScore;
        PlayerPrefs.SetInt("HighScore", _actualScore);
        return true;
    }
}
