using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour
{   
    public int scoreToGive;
    private ScoreManager theScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        theScoreManager=FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player")
        {
            theScoreManager.AddScore(scoreToGive);
            //theScoreManager.scoreCount+=scoreToGive;
            gameObject.SetActive(false);
        }
    }
}
