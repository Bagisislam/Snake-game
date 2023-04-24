using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMeneger : MonoBehaviour
{
    public List<GameObject> _listOfHealths = new List<GameObject>();

    public int _HeartNumber { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _HeartNumber = 1;
        for (int i = 1; i < _listOfHealths.Count; i++)
        {
            _listOfHealths[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}
