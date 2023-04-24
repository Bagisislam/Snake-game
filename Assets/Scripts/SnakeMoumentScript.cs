using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeMoumentScript : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    [SerializeField]
    private List<GameObject> _listOfTalls = new List<GameObject>();
    [SerializeField]
    private GameObject _prefebTalls;

    private Vector2 _up = Vector2.up;
    private Vector2 _down = Vector2.down;
    private Vector2 _left = Vector2.left;
    private Vector2 _right = Vector2.right;

    [SerializeField]
    private GameObject _GameOver;


    private HealthMeneger _healthMeneger;

    // Start is called before the first frame update
    void Start()
    {

        _healthMeneger = GameObject.Find("HealthMeneger").GetComponent<HealthMeneger>();


        _listOfTalls.Add(this.gameObject);

        _speed = Time.fixedDeltaTime = 0.10f;

        Entity.Up = true;
        Entity.KeyA = true;
        Entity.KeyD = true;
        Entity.KeyS = true;
        Entity.KeyW = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.A) && Entity.KeyA == true && gameObject.transform.position != Vector3.right)
        {

            Entity.Left = true;
            Entity.Down = false;
            Entity.Right = false;
            Entity.Up = false;
            Entity.KeyA = true;
            Entity.KeyD = false;
            Entity.KeyS = true;
            Entity.KeyW = true;
        }

        if (Input.GetKeyDown(KeyCode.D) && Entity.KeyD == true && gameObject.transform.position != Vector3.left)
        {

            Entity.Right = true;
            Entity.Left = false;
            Entity.Down = false;
            Entity.Up = false;
            Entity.KeyD = true;
            Entity.KeyA = false;
            Entity.KeyW = true;
            Entity.KeyS = true;
        }

        if (Input.GetKeyDown(KeyCode.S) && Entity.KeyS == true && gameObject.transform.position != Vector3.up)
        {

            Entity.Down = true;
            Entity.Right = false;
            Entity.Left = false;
            Entity.Up = false;
            Entity.KeyS = true;
            Entity.KeyW = false;
            Entity.KeyA = true;
            Entity.KeyD = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && Entity.KeyW == true && gameObject.transform.position != Vector3.down)
        {

            Entity.Up = true;
            Entity.Down = false;
            Entity.Right = false;
            Entity.Left = false;
            Entity.KeyW = true;
            Entity.KeyS = false;
            Entity.KeyA = true;
            Entity.KeyD = true;
        }

    }

    private void FixedUpdate()
    {

        for (int i = _listOfTalls.Count - 1; i > 0; i--)
        {
            _listOfTalls[i].transform.position = _listOfTalls[i - 1].transform.position;
        }
        if (Entity.Up == true)
        {
            Direction(_up);

        }

        if (Entity.Down == true)
        {
            Direction(_down);

        }

        if (Entity.Left == true)
        {
            Direction(_left);

        }

        if (Entity.Right == true)
        {
            Direction(_right);

        }
    }

    private void Direction(Vector3 axis)
    {

        transform.position = new Vector3(((Mathf.RoundToInt(transform.position.x) + axis.x)),
            ((Mathf.RoundToInt(transform.position.y) + axis.y)), 0.0f);

    }

    void Growoin()
    {
        var talls = Instantiate(_prefebTalls);
        talls.transform.position = _listOfTalls[_listOfTalls.Count - 1].transform.position;

        _listOfTalls.Add(talls);

    }

    void OnTriggerEnter2D(Collider2D others)
    {
        if (others.CompareTag("Food"))
        {
            Growoin();
        }

        if (others.CompareTag("Talls"))
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
                    _healthMeneger._listOfHealths[_healthMeneger._HeartNumber - 1].gameObject.SetActive(false);
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

static class Entity
{
    public static bool? Left { get; set; }
    public static bool? Right { get; set; }
    public static bool? Up { get; set; }
    public static bool? Down { get; set; }
    public static bool? KeyA { get; set; }
    public static bool? KeyD { get; set; }
    public static bool? KeyS { get; set; }
    public static bool? KeyW { get; set; }
}