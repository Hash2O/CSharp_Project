using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaquetteManager : MonoBehaviour
{
    [SerializeField] private GameObject raquette1;
    [SerializeField] private GameObject raquette2;

    private float verticalInput;
    private float horizontalInput;

    private float _speed = 5.0f;
    private float zMaxRange = 3.65f;

    // Start is called before the first frame update
    void Start()
    {
        raquette1 = GameObject.Find("Raquette 1");
        raquette2 = GameObject.Find("Raquette 2");

        Debug.Log("Les deux raquettes sont " + raquette1.name + " et " + raquette2.name);
    }

    // Update is called once per frame
    void Update()
    {
        //Raquette 1
        verticalInput = Input.GetAxis("Vertical");
        raquette1.transform.Translate(Vector3.forward * Time.deltaTime * _speed * verticalInput);

        //Raquette2
        horizontalInput = Input.GetAxis("Horizontal");
        raquette2.transform.Translate(Vector3.forward * Time.deltaTime * _speed * horizontalInput);

        //Limites du terrain raquette 1
        if (raquette1.transform.position.z > zMaxRange)
        {
            raquette1.transform.position = new Vector3(raquette1.transform.position.x, raquette1.transform.position.y, zMaxRange);
        } else if (raquette1.transform.position.z < -zMaxRange)
        {
            raquette1.transform.position = new Vector3(raquette1.transform.position.x, raquette1.transform.position.y, -zMaxRange);
        }

        //Limites du terrain raquette 2
        if (raquette2.transform.position.z > zMaxRange)
        {
            raquette2.transform.position = new Vector3(raquette2.transform.position.x, raquette2.transform.position.y, zMaxRange);
        }
        else if (raquette2.transform.position.z < -zMaxRange)
        {
            raquette2.transform.position = new Vector3(raquette2.transform.position.x, raquette2.transform.position.y, -zMaxRange);
        }

    }
}
