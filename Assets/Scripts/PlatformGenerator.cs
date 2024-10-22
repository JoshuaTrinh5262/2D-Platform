﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    private float distanceBetween;
    //private float platformWidth;
    //
    public float distanceBetweenMax;
    public float distanceBetweenMin;
    //#7 - Randomising Platforms
    public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;
    //
    public ObjectPooler[] theObjectPools;
    //#9 Platform Height
    public float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    //public ObjectPooler theObjectPool; 
    //#14 Random Coin Placement
    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;
    //#20 Extra Danger Spikes
    public ObjectPooler spikePool;
    public float randomSpikeThreshold;


    // Start is called before the first frame update
    void Start()
    {
        //platformWidth=thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths=new float[theObjectPools.Length];
        for(int i=0;i<theObjectPools.Length;i++)
        {
            //platformWidths[i]=thePlatforms[i].GetComponent<BoxCollider2D>().size.x;
            platformWidths[i]=theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight=transform.position.y;
        maxHeight=maxHeightPoint.position.y;
        //
        theCoinGenerator=FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<generationPoint.position.x)
        {
            distanceBetween=Random.Range(distanceBetweenMin,distanceBetweenMax);
            platformSelector=Random.Range(0,thePlatforms.Length);
            heightChange=transform.position.y+Random.Range(maxHeightChange,-maxHeightChange);
            //transform.position=new Vector3(transform.position.x+platformWidths[platformSelector]+distanceBetween,transform.position.y,transform.position.z);
            if(heightChange>maxHeight)
            {
                heightChange=maxHeight;
            }
            else
            {
                if(heightChange<minHeight)
                {
                      heightChange=minHeight;                  
                }
            }
            transform.position=new Vector3(transform.position.x+(platformWidths[platformSelector]/2)+distanceBetween,heightChange,transform.position.z);
            //Instantiate(thePlatform,transform.position,transform.rotation);
            //Instantiate(thePlatforms[platformSelector],transform.position,transform.rotation);
            
            /*GameObject newPlatform=theObjectPool.GetPooledObject();
            newPlatform.transform.position=transform.position;
            newPlatform.transform.rotation=transform.rotation;
            newPlatform.SetActive(true);*/

            GameObject newPlatform=theObjectPools[platformSelector].GetPooledObject();
            newPlatform.transform.position=transform.position;
            newPlatform.transform.rotation=transform.rotation;
            newPlatform.SetActive(true);
            //#14 Random Coin Placement
            if(Random.Range(0f,100f)<randomCoinThreshold)
            {
                //generate Coin above platform
                theCoinGenerator.SpawnCoins(new Vector3(transform.position.x,transform.position.y+1,transform.position.z));
            }
            //#20 Extra Danger Spikes
            if(Random.Range(0f,100f)<randomSpikeThreshold)
            {
                GameObject newSpike=spikePool.GetPooledObject();

                float spikeXPosition=Random.Range(-platformWidths[platformSelector]/2f+1f,platformWidths[platformSelector]/2f-1f);
                Vector3 spikePosition=new Vector3(spikeXPosition,1f,0f);
                newSpike.transform.position=transform.position+spikePosition;
                newSpike.transform.rotation=transform.rotation;
                newSpike.SetActive(true);
            }
            //
            transform.position=new Vector3(transform.position.x+(platformWidths[platformSelector]/2f)+distanceBetween,transform.position.y,transform.position.z);
        }
    }
}
