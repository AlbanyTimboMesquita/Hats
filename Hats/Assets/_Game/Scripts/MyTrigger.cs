using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrigger : MonoBehaviour
{
    private GameController gameController;
    private UiController uiController;
    public AudioSource audioPlayer;

    private void Start() {
        gameController = FindObjectOfType<GameController>();
        uiController = FindObjectOfType<UiController>();
        audioPlayer = FindObjectOfType<AudioSource>();
        
    }
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Destroyer")){
            Destroy(this.gameObject);
        }else if(target.gameObject.CompareTag("Point")){
                gameController.score+=23;
                audioPlayer.Play();
                uiController.txtScore.text = gameController.score.ToString();
                Destroy(this.gameObject);
        }
        
    }
}
