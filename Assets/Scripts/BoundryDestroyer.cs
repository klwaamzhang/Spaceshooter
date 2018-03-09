using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundryDestroyer : MonoBehaviour {

    /*//Run when an object first enters into  collider zone
    //Run once!
    void OnTriggerEnter2D(Collider2D other)
    {

    }

    //Runs whenever an object is inside a collider
    //Run every frame
    void OnTriggerStay2D(Collider2D other)
    {

    }*/

    //Run whenever an object exists the collider zone
    //Run once
    void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
