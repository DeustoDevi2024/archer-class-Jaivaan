using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Archer
{


    public class Bow : MonoBehaviour
    {

        // Referencia a la acci�n de Input para disparar
        [SerializeField]
        private InputActionReference fireInputReference;

        // Una referencia al prefab de la flecha
        [SerializeField]
        private GameObject arrowPrefab;

        // Cantidad de fuerza que aplicaremos al disparar la flecha
        [SerializeField]
        private float force;
        
        // Una referencia a un transform que servir� de punto de referencia para disparar la flecha
        [SerializeField]
        private Transform handPosition;

      

        private Animator animator;
        private AudioSource audioSource;

        private void Awake()
        {
           
            // Nos subscribimos al evento de input de disparo (el espacio o el bot�n A).
            fireInputReference.action.performed += Action_performed;
            audioSource = GetComponent<AudioSource>();

            animator = GetComponent<Animator>();
        }

        private void Action_performed(InputAction.CallbackContext obj)
        {
            // Cuando se pulsa espacio, producimos un disparo
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
         // Instanciar una flecha 
            animator.SetTrigger("Shoot");
            yield return new WaitForSeconds(0.3f);

            // Colocar la flecha en el punto de referencia de la mano de la arquera
            GameObject newarrow = Instantiate(arrowPrefab);

            // Orientar la flecha hacia delante con respecto a la arquera
            newarrow.transform.position = handPosition.position;

            newarrow.transform.rotation = transform.rotation;

            // Aplicar una fuerza a la flecha para que salga disparada
            newarrow.GetComponent<Rigidbody>().AddForce(newarrow.transform.forward * force);
        }
    }

}