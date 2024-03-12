using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour
{
    [SerializeField] Button btnStart;
    [SerializeField] Button btnQuit;

    private void Awake()
    {
        btnStart.onClick.AddListener(delegate { startGame(); });
        btnQuit.onClick.AddListener(delegate { quitGame(); });
    }

    private void startGame()
    {
        SceneManager.LoadScene(1);
    }

    private void quitGame()
    {
        Application.Quit();
    }
}
