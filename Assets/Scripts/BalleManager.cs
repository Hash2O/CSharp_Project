using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalleManager : MonoBehaviour
{
    public float _speed = 1000.0f;
    public Vector3 directionDeLaBalle;

    private Rigidbody balleRigidbody;

    [SerializeField] private int compteurGauche;
    [SerializeField] private int compteurDroit;

    public TextMeshProUGUI texteCompteurGauche;
    public TextMeshProUGUI texteCompteurDroit;


    // Start is called before the first frame update
    void Start()
    {
        balleRigidbody = GetComponent<Rigidbody>();
        compteurGauche = 0;
        compteurDroit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Engagement joueur gauche
        if(Input.GetKey(KeyCode.LeftShift))
        {
            balleRigidbody.AddRelativeForce(Vector3.right * _speed * Time.deltaTime, ForceMode.Impulse);
            balleRigidbody.AddRelativeTorque(0, RandomTorque(), 0);
        }

        //Engagement joueur droit
        if (Input.GetKey(KeyCode.RightShift))
        {
            balleRigidbody.AddRelativeForce(Vector3.left * _speed * Time.deltaTime, ForceMode.Impulse);
            balleRigidbody.AddRelativeTorque(0, RandomTorque(), 0);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("OutGauche"))
        { 
            compteurDroit++;
            Debug.Log("Nombre de points marqués par le joueur droit : " + compteurDroit);
            texteCompteurDroit.text = "Joueur Droit : " + compteurDroit;

        } else if(other.gameObject.CompareTag("OutDroit"))
        {
            compteurGauche++;
            Debug.Log("Nombre de points marqués par le joueur gauche: " + compteurGauche);
            texteCompteurGauche.text = "Joueur Gauche : " + compteurGauche;
        }
    }

    private float RandomTorque()
    {
        float randomTorque = Random.Range(-0.5f, 0.5f);
        return randomTorque;
    }

}
