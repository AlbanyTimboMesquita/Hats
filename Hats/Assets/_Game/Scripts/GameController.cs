using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
   public int score;
   public float currentTime;
   [SerializeField]private float startTime;
   public bool gameStarted;
    void Start()
    {
        score=0;
        currentTime=startTime;
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {

        CountDownTime();
        
    }
    public void CountDownTime(){
        if(currentTime>0f && gameStarted){
            currentTime-=Time.deltaTime;
        }else{
            gameStarted=false;
            currentTime=0f;
            return;
        }
        
    }
}
