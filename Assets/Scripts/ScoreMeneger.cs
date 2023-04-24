using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreMeneger : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _ScoreText;

    public int _score;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _ScoreText.text = _score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
