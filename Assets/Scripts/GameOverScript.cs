using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _GameOver;


    private HealthMeneger _healthMeneger;

    // Start is called before the first frame update
    void Start()
    {
        _healthMeneger = GameObject.Find("HealthMeneger").GetComponent<HealthMeneger>();
    }
    void OnTriggerEnter2D(Collider2D others)
    {
        if (others.CompareTag("Player"))
        {
            if (gameObject.name == "Wall")
            {
                Time.timeScale = 0;
                _GameOver.SetActive(true);
            }
            else
            {
                if (_healthMeneger._HeartNumber > 0)
                {
                    _healthMeneger._listOfHealths[_healthMeneger._HeartNumber-1].gameObject.SetActive(false);
                    _healthMeneger._HeartNumber--;
                    print(_healthMeneger._HeartNumber);
                }

                if (_healthMeneger._HeartNumber < 1)
                {
                    Time.timeScale = 0;
                    _GameOver.SetActive(true);
                }
                
            }
        }
    }
}
