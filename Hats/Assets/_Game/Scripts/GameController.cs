using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   [HideInInspector]public int score, highScore;
   [HideInInspector]public float currentTime;
   [SerializeField]private float startTime;
   [HideInInspector]public bool gameStarted;
   private UiController uiController;
   private SpawnController spawnController;
   [SerializeField]private Transform player;
   private Vector2 playerPosition;
    void Start()
    {
        score=0;
        currentTime=startTime;
        gameStarted = false;
        uiController = FindObjectOfType<UiController>();
        spawnController= FindObjectOfType<SpawnController>();
        highScore=Getscore();
        uiController.txtTime.text = currentTime.ToString();
        //uiController.txtScore.text = "Score: "+score.ToString();
        playerPosition=player.position;
        
    }

    // Update is called once per frame
    void Update(){}

    public void DestroyAllBalls(){
        foreach(Transform child in spawnController.allBallsParent){
            Destroy(child.gameObject);
        }

    }

    public void SaveScore(){
        if (score>highScore){
        highScore=score;
        PlayerPrefs.SetInt("highScore",highScore);
        }else{
            return;
        }
    }
    public int Getscore(){
        
        return PlayerPrefs.GetInt("highScore");
    }

    public void StartGame(){
        SaveScore();
        score=0;
        currentTime=startTime;
        gameStarted = true;
        InvokeCountDownTime();
        player.position=playerPosition;
    }

    public void BackMainMenu(){
        score=0;
        currentTime=0f;
        gameStarted=false;
        CancelInvoke("CountDownTime");
        player.position=playerPosition; 
    }


    public void InvokeCountDownTime(){
        InvokeRepeating("CountDownTime", 0f, 1f);
    }
    public void CountDownTime(){
        uiController.txtTime.text = currentTime.ToString();
        //uiController.txtScore.text = "Score: "+score.ToString();
        if(currentTime>0f && gameStarted){
            currentTime-=1f;
        }else{
            uiController.PanelGameOver.gameObject.SetActive(true);
            uiController.panelGame.gameObject.SetActive(false);
            gameStarted=false;
            SaveScore();
            currentTime=0f;
            CancelInvoke("CountDownTime"); 

            return;
        }
        
    }
}
