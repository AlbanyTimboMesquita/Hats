using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{

private GameController gameController;
public GameObject panelMainMenu,panelGame,panelPause,PanelGameOver;
public TMP_Text txtHighScore, txtTime, txtScore;
    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
        MostrarMaiorPontuacao();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStartGame(){
        
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.StartGame();
        MostrarMaiorPontuacao();

    }
    public void ButtonPause(){
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
        Time.timeScale=0f;


    }
    public void ButtonResume(){
        
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        Time.timeScale=1f;
    }
    public void ButtonRestart(){
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        PanelGameOver.gameObject.SetActive(false);
        gameController.StartGame();
        gameController.DestroyAllBalls();
    }
    public void ButtonBackMainMenu(){
        panelPause.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        PanelGameOver.gameObject.SetActive(false);
        gameController.BackMainMenu();
        MostrarMaiorPontuacao();
        gameController.DestroyAllBalls();
        Time.timeScale=1f;

    }
    public void MostrarMaiorPontuacao(){
        txtHighScore.text= gameController.Getscore().ToString();
    }
}
