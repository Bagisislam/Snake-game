using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealrhSpawnScript : MonoBehaviour
{
    internal float _startTime = 0;
    internal float _currentTime;

    [SerializeField]
    private GameObject _purpleFood;


    internal bool _triggert;

    internal int _randomNumber;

    private HealthMeneger _healthMeneger;

    // Start is called before the first frame update
    void Start()
    {
        _healthMeneger = GameObject.Find("HealthMeneger").GetComponent<HealthMeneger>();
        _triggert = false;
        _currentTime = _startTime;
        _purpleFood.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_triggert != true || _randomNumber % 10 != 0 || _currentTime > 5 || _healthMeneger._HeartNumber > 3)
        {
            _purpleFood.SetActive(false);
            _currentTime = _startTime;
            _triggert = false;
        }
        if (_triggert == true && _randomNumber % 10 == 0 && _currentTime <= 5 && _healthMeneger._HeartNumber < 3)
        {
            _currentTime += 1 * Time.deltaTime;
            _purpleFood.SetActive(true);
        }

        if (_triggert == false)
        {
            _purpleFood.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D others)
    {
        if (others.CompareTag("Player"))
        {
            _randomNumber = Random.Range(1,99);
            _triggert = true;
        }
    }
}
