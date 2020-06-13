using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        string tag = coll.collider.gameObject.tag;
        if (tag == "pick_me")
        {
            Destroy(coll.collider.gameObject);
        }
        if (tag == "avoid_me")
        {
            Destroy(coll.collider.gameObject);
        }
    }
}
