using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float speed = 0.1f;

    private Rigidbody2D myBody;

	// Use this for initialization
	void Awake () {

        myBody = GetComponent<Rigidbody2D>();
		
	}


	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
       

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            GravitySwitch();
        }

    }

    void MoveRight()
    {
        Vector2 position = transform.position;
        position.x += speed;
        transform.position = position;
    }

    void MoveLeft()
    {
        Vector3 position = transform.position;
        position.x -= speed;
        transform.position = position;
    }

    void GravitySwitch()
    {
        myBody.gravityScale *= -1;
    }
}
