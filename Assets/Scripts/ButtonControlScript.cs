using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControlScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _textOfGameOver;

    [SerializeField]
    private GameObject _EndCanvas;
    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAgainBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void KeepUpGame()
    {
        Time.timeScale = 1.0f;
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
    public void StartGameBtn()
    {
        Time.timeScale = 1.0f;
    }
}
