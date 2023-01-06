using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongSpacebar : MonoBehaviour
{
    public float _xSpeed = 1.0f;
    private Vector3 direction;
    public bool isMovingRight;
    // Start is called before the first frame update
    void Start()
    {
        isMovingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Déplacement
        transform.Translate(direction * Time.deltaTime);

        //Conditions

        if (transform.position.x <= 0 || (Input.GetKeyDown(KeyCode.Space) && isMovingRight == false))
        {
                //Debug.Log("Depart");
                direction = new Vector3(_xSpeed, 0, 0);
                isMovingRight = true;
        }
        else if (transform.position.x > 5 || (Input.GetKeyDown(KeyCode.Space) && isMovingRight == true))
        {
            //Debug.Log("Au dela de la limite");
            direction = new Vector3(-_xSpeed, 0, 0);
            isMovingRight = false;
        }

    }
}
