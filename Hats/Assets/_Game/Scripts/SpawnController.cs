using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;





public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float topDistance,lateralMargin;
    private UnityEngine.Vector2 screenWidth;

    private GameController gameController;

    public Transform allBallsParent;

    private void Awake() 
    {
        Initialize();
    }
    void Start()
    {
        InvokeRepeating("SpawnInvoke",2.0f,Random.Range(2.0f,3.0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Initialize()
    {
        screenWidth = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector2(Screen.safeArea.width,Screen.safeArea.height));
        UnityEngine.Vector2 heightPosition = new UnityEngine.Vector2(transform.position.x,Camera.main.orthographicSize+topDistance);
        transform.position = heightPosition;
        gameController=FindObjectOfType<GameController>();
    }
    private IEnumerator Spawn(){
        if(gameController.gameStarted){
            yield return new WaitForSeconds(0f);
            transform.position =  new UnityEngine.Vector2(Random.Range(-screenWidth.x + lateralMargin,screenWidth.x-lateralMargin),transform.position.y);
            GameObject tempBallPrefab = Instantiate(ballPrefab, transform.position, UnityEngine.Quaternion.identity) as GameObject;
            tempBallPrefab.transform.parent = allBallsParent;
        }else{
            yield return null;
        }
    }

    private void SpawnInvoke(){
        StartCoroutine(Spawn());
    }
}
