using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

public class RandomFood : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _listOfFoods = new List<GameObject>();

    private Collider2D _collider;

    SpriteRenderer _spriteRenderer;

    HealrhSpawnScript _heroSpawnScript;

    private Color _colorYellow;

    [SerializeField]
    private ScoreMeneger _scoreMeneger;

    // Start is called before the first frame update
    void Start()
    {

        _heroSpawnScript = GameObject.Find("YellowFood").GetComponent<HealrhSpawnScript>();

        _collider = GameObject.Find("SpawnBoundaries").GetComponent<Collider2D>();

        _spriteRenderer = _listOfFoods[0].GetComponent<SpriteRenderer>();

        ColorUtility.TryParseHtmlString("#FFD400", out _colorYellow);

        _scoreMeneger = GameObject.Find("ScoreMeneger").GetComponent<ScoreMeneger>();

        RandomPositionYellow();
        RandomPositionLightGreen();
        RandomPositionRed();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void RandomPositionYellow()
    {
        var boundres = _collider.bounds;

        var x = Random.Range(Mathf.RoundToInt(boundres.min.x), Mathf.RoundToInt(boundres.max.x));
        var y = Random.Range(Mathf.RoundToInt(boundres.min.y), Mathf.RoundToInt(boundres.max.y));

        while (ChackFoodSpawn(new Vector2(x, y)))
        {
            transform.position = new Vector3(Mathf.RoundToInt(x), Mathf.RoundToInt(y), 0.0f);
            break;
        }
    }

    void RandomPositionRed()
    {
        var boundres = _collider.bounds;

        var x = Random.Range(Mathf.RoundToInt(boundres.min.x), Mathf.RoundToInt(boundres.max.x));
        var y = Random.Range(Mathf.RoundToInt(boundres.min.y), Mathf.RoundToInt(boundres.max.y));

        while (ChackFoodSpawn(new Vector2(x, y)))
        {
            _listOfFoods[0].transform.position = new Vector3(Mathf.RoundToInt(x), Mathf.RoundToInt(y), 0.0f);
            break;
        }
    }
    void RandomPositionLightGreen()
    {
        var boundres = _collider.bounds;

        var x = Random.Range(Mathf.RoundToInt(boundres.min.x), Mathf.RoundToInt(boundres.max.x));
        var y = Random.Range(Mathf.RoundToInt(boundres.min.y), Mathf.RoundToInt(boundres.max.y));

        while (ChackFoodSpawn(new Vector2(x, y)))
        {
            _listOfFoods[1].transform.position = new Vector3(Mathf.RoundToInt(x), Mathf.RoundToInt(y), 0.0f);
            break;
        }
    }

    private bool ChackFoodSpawn(Vector2 vector2)
    {
        foreach (var itmeFood in _listOfFoods)
        {
            var x = Mathf.RoundToInt(itmeFood.transform.position.x);
            var y = Mathf.RoundToInt(itmeFood.transform.position.y);

            if (new Vector2(x, y) == vector2)
            {
                return false;
            }
        }

        return true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _heroSpawnScript._currentTime = _heroSpawnScript._startTime;
            _scoreMeneger.Score++;
            _spriteRenderer.color = _colorYellow;
            RandomPositionYellow();
            RandomPositionLightGreen();
            RandomPositionRed();
        }

    }
}
