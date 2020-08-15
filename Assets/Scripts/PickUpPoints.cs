using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour
{   
    public int scoreToGive;
    private ScoreManager theScoreManager;
    //#19 sound Effect
    private AudioSource coinSound;
    // Start is called before the first frame update
    void Start()
    {
        theScoreManager=FindObjectOfType<ScoreManager>();
        coinSound=GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player")
        {
            theScoreManager.AddScore(scoreToGive);
            //theScoreManager.scoreCount+=scoreToGive;
            gameObject.SetActive(false);
        }
        if(coinSound.isPlaying)
        {
            coinSound.Stop();
            coinSound.Play();
        }
        else
        {
            coinSound.Play();
        }
    }
}
