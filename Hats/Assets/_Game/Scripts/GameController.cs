using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public int score;
   public float currentTime;
   [SerializeField]private float startTime;
   public bool gameStarted;
   private UiController uiController;
    void Start()
    {
        score=0;
        currentTime=startTime;
        gameStarted = false;
        uiController = FindObjectOfType<UiController>();
    }

    // Update is called once per frame
    void Update(){}

    public void StartGame(){
        score=0;
        currentTime=startTime;
        gameStarted = true;
        InvokeCountDownTime();
    }

    public void BackMainMenu(){
        score=0;
        currentTime=0f;
        gameStarted=false;
        CancelInvoke("CountDownTime"); 
    }


    public void InvokeCountDownTime(){
        InvokeRepeating("CountDownTime", 1f, 1f);
    }
    public void CountDownTime(){
        if(currentTime>0f && gameStarted){
            currentTime-=1f;
        }else{
            uiController.PanelGameOver.gameObject.SetActive(true);
            uiController.panelGame.gameObject.SetActive(false);
            gameStarted=false;
            currentTime=0f;
            CancelInvoke("CountDownTime"); 
            return;
        }
        
    }
}
