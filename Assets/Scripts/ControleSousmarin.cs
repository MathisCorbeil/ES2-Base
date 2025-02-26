using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControleSousmarin : MonoBehaviour
{
    [SerializeField] private float _vitessePromenade;
    private Rigidbody _rb;
    private Vector3 directionInput;
    private Animator _animator;
    // Start is called before the first frame update


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    


    void OnAvant(InputValue directionBase)
    {
       

        float directionAvecVitesse = directionBase.Get<float>() * _vitessePromenade;
        directionInput = new Vector3(0f, 0f, directionAvecVitesse);
       

        _animator.SetFloat("Deplacement_Avant", directionInput.magnitude);
        


    }

    void OnVerticale(InputValue directionBase){
        

          float directionAvecVitesse = directionBase.Get<float>() * _vitessePromenade;
        
        directionInput = new Vector3(0f, directionAvecVitesse, 0f);
      
        if(directionAvecVitesse < 0f)
        {
            _animator.SetBool("revers", true);

        }
        
            _animator.SetFloat("Deplacement_Verticale", directionInput.magnitude);
       
    }

    
    
    void OnBoost(InputValue etatBouton){
    if(etatBouton.isPressed){
    Debug.Log("patate");
          _vitessePromenade=_vitessePromenade * 2;
          

            
        }
      else
        {
            Debug.Log("patate_piler");
            _vitessePromenade = _vitessePromenade/2;
           

        }
      }

void FixedUpdate()
    {
        Vector3 mouvement = directionInput;
        _rb.AddForce(mouvement, ForceMode.VelocityChange);
    }



}


