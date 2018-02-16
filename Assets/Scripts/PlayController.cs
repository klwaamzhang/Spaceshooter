using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Boundary class
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayController : MonoBehaviour {

    //Public variables
    public float speed;
    public float nextFire = 0.1f;
    public Boundary boundary;
    public GameObject laser;
    public Transform laserSpawn;

    //Private variables
    private Rigidbody2D rBody;
    private float myTime = 0.0f;
    
    // Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();//Establishes a "connection" to the rigidbody2D component
    }
	
	// Update is called once per frame
	void Update () {
        myTime += Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);
            myTime = 0.0f;
        }
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");//Returns a value between -1 and 1 whenever left, right, a, or d is pushed
        float moveVertical = Input.GetAxis("Vertical");//Return a value between -1 and 1 whenever up, down, w, or s is pushed
        Debug.Log("H= " + moveHorizontal + "V= " + moveVertical);//Debug
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);//二维向量
        rBody.velocity = movement * speed;
        rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax));
    }
}
