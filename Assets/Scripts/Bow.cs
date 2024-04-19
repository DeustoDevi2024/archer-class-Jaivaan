using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Archer
{


    public class Bow : MonoBehaviour
    {

        // Referencia a la acción de Input para disparar
        [SerializeField]
        private InputActionReference fireInputReference;

        // Una referencia al prefab de la flecha
        [SerializeField]
        private GameObject arrowPrefab;

        // Cantidad de fuerza que aplicaremos al disparar la flecha
        [SerializeField]
        private float force;
        
        // Una referencia a un transform que servirá de punto de referencia para disparar la flecha
        [SerializeField]
        private Transform handPosition;

      

        private Animator animator;

        private void Awake()
        {
           
            // Nos subscribimos al evento de input de disparo (el espacio o el botón A).
            fireInputReference.action.performed += Action_performed;

            animator = GetComponent<Animator>();
        }

        private void Action_performed(InputAction.CallbackContext obj)
        {
            // Cuando se pulsa espacio, producimos un disparo
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
          

            yield return new WaitForSeconds(0.3f);


            // Instanciar una flecha
           

            // Colocar la flecha en el punto de referencia de la mano de la arquera
         

            // Orientar la flecha hacia delante con respecto a la arquera
           

            // Aplicar una fuerza a la flecha para que salga disparada
          
        }
    }

}