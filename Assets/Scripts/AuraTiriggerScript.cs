using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using Color = UnityEngine.Color;
using ColorUtility = UnityEngine.ColorUtility;

public class AuraTiriggerScript : MonoBehaviour
{
    [SerializeField] 
    private SpriteRenderer _redFood;
    Color _colorRed;
    // Start is called before the first frame update
    void Start()
    {
        _redFood = GameObject.Find("RedFood").GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D others)
    {
        ColorUtility.TryParseHtmlString("#C50000", out _colorRed);

        if (others.CompareTag("Player"))
        {
            //C50000

            _redFood.color = _colorRed;
        }
    }

}
