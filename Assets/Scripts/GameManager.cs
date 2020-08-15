using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    //
    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    //
    public PlayerMovement thePlayer;
    private Vector3 playerStartPoint; 
    //
    private PlatformDestroyer[] platformList;
    //
    private ScoreManager theScoreManager;
    //
    public DeathMenu theDeathScene;
    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint=platformGenerator.position;
        playerStartPoint=thePlayer.transform.position;
        //
        theScoreManager=FindObjectOfType<ScoreManager>();
    }
    
    public void RestartGame()
    {
        theScoreManager.scoreIncreasing=false;
        thePlayer.gameObject.SetActive(false);
        //StartCoroutine("RestartGameCo");
        //
        theDeathScene.gameObject.SetActive(true);
    }
    //#17 After Death Menu
    public  void Reset() 
    {
        theDeathScene.gameObject.SetActive(false);
        platformList=FindObjectsOfType<PlatformDestroyer>();
        for(int i=0;i<platformList.Length;i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position=playerStartPoint;
        platformGenerator.position=platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        //Reset Score last moment
        theScoreManager.scoreCount=0;
        theScoreManager.scoreIncreasing=true;
    }
    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing=false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList=FindObjectsOfType<PlatformDestroyer>();
        for(int i=0;i<platformList.Length;i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position=playerStartPoint;
        platformGenerator.position=platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        //Reset Score last moment
        theScoreManager.scoreCount=0;
        theScoreManager.scoreIncreasing=true;
    }*/
    
}
