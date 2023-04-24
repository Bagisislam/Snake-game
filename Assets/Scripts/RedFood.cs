using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

public class RedFood : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _listOfFoods = new List<GameObject>();
    private Collider2D _collider;
    SpriteRenderer _spriteRenderer;
    [SerializeField]
    private ScoreMeneger _scoreMeneger;
    private Color _colorYellow;
    HealrhSpawnScript _healrhSpawnScript;
    // Start is called before the first frame update
    void Start()
    {

        _healrhSpawnScript = GameObject.Find("YellowFood").GetComponent<HealrhSpawnScript>();

        _collider = GameObject.Find("SpawnBoundaries").GetComponent<Collider2D>();

        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

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
            _scoreMeneger.Score--;
            _healrhSpawnScript._currentTime = _healrhSpawnScript._startTime;
            _spriteRenderer.color = _colorYellow;
            RandomPositionYellow();
            RandomPositionLightGreen();
            RandomPositionRed();
        }

    }

}
