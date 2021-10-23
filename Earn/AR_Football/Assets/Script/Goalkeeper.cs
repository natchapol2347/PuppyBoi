using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    private bool isMovingRight = true;
    private float strafeSpeed = 25f;
    private float boundary = 12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x > boundary)
            isMovingRight = false;
        if (transform.position.x < -boundary)
            isMovingRight = true;

        if (isMovingRight == true)
        {
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * strafeSpeed);
        }
        if (isMovingRight == false)
        {
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * strafeSpeed);
        }
        
        
    }

        


}

