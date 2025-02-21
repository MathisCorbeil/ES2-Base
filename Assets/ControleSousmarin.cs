using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControleSousmarin : MonoBehaviour
{
    [SerializeField] private float _vitessePromenade;
    private Rigidbody _rb;
    private Vector3 directionInput;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    


    void OnAvant(InputValue directionBase)
    {
        float directionAvecVitesse = directionBase.Get<float>() * _vitessePromenade;
        directionInput = new Vector3(0f, 0f, directionAvecVitesse);
        

    }

void FixedUpdate()
    {
        Vector3 mouvement = directionInput;
        _rb.AddForce(mouvement, ForceMode.VelocityChange);
    }



}


