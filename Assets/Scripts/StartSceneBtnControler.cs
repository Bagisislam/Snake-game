using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneBtnControler : MonoBehaviour
{
    [SerializeField]
    private GameObject _informationPanel;
    [SerializeField]
    private GameObject _startGameCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _startGameCanvas.SetActive(true);
        Time.timeScale = 0;
        _informationPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_informationPanel.activeSelf == true && Input.anyKeyDown == true)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }
    }

    public void StartGameBtn()
    {
        _informationPanel.gameObject.SetActive(true);
        _startGameCanvas.gameObject.SetActive(false);
    }

    public void QuitGameBtn()
    {
        Application.Quit();
    }

}
