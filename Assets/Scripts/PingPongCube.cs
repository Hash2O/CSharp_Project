using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongCube : MonoBehaviour
{
    public float _xSpeed = 1.0f;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        //Déplacement
        transform.Translate(direction * Time.deltaTime);

        //Conditions
        if (transform.position.x <= 0)
        {
            //Debug.Log("Depart");
            direction = new Vector3(_xSpeed, 0, 0);
        }
        else if (transform.position.x > 1)
        {
            //Debug.Log("Au dela de la limite");
            direction = new Vector3(- _xSpeed, 0, 0);
        }
    }
}
