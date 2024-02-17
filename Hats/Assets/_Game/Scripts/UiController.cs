using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{

private GameController gameController;
public GameObject panelMainMenu;
    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonExit(){
    /*    //PC ou Celular
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        } */

        // Android
        AndroidJavaObject actvity = new AndroidJavaClass("com.unity3d.player.UnitPlayer").GetStatic<AndroidJavaObject>
        ("currentActivity");
        actvity.Call<bool>("moveTaskToBack",true);
        
    }
    public void ButtonStartGame(){
        gameController.gameStarted = true;
        panelMainMenu.gameObject.SetActive(false);

    }
}
