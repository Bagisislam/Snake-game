using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PurpleHealthMeneger : MonoBehaviour
{
    HealthMeneger _healthMeneger;
    HealrhSpawnScript _healrhSpawnScript;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        _healthMeneger = GameObject.Find("HealthMeneger").GetComponent<HealthMeneger>();
        _healrhSpawnScript = GameObject.Find("YellowFood").GetComponent<HealrhSpawnScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_healthMeneger._HeartNumber >= 3)
        {
            _healthMeneger._HeartNumber = 3;
        }
    }

    void OnTriggerEnter2D(Collider2D others)
    {
        if (others.CompareTag("Player"))
        {
            _healrhSpawnScript._randomNumber = 1;
            _healrhSpawnScript._currentTime = _healrhSpawnScript._startTime;
            if (_healthMeneger._HeartNumber <= 2)
            {
                _healthMeneger._HeartNumber++;
            }
            

            print("can   " +_healthMeneger._HeartNumber);

            _healthMeneger._listOfHealths[_healthMeneger._HeartNumber - 1].SetActive(true);
        }
    }
}
