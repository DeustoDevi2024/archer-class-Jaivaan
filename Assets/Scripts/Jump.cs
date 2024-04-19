using UnityEngine;
using UnityEngine.InputSystem;

namespace Archer
{

    public class Jump : MonoBehaviour
    {

        // Fuerza de salto
        [SerializeField]
        private float jumpForce = 100;

        // Layers de Unity que consideramos que son suelo
        [SerializeField]
        private LayerMask layerMask;

        private Rigidbody playerRigidbody;

        // Obtener una referencia a la acción del salto
        [SerializeField]
        private InputActionReference jumpActionReference;

        // Actualizaremos esta variable para saber si el personaje está en el suelo.
        // Permitiremos el salto sólo si el personaje está en el suelo.
        private int groundCollisions;

        private Animator animator;

        public bool IsGrounded {
            get
            {
                return groundCollisions > 0;
            }
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();

            // Obtener una referencia al Rigidbody
            playerRigidbody = GetComponent<Rigidbody>();

            // Subscribir que se ha producido el input del salto
            jumpActionReference.action.performed += Action_performed;
        }

        // Se llama cuando se ha producido el input del salto
        private void Action_performed(InputAction.CallbackContext obj)
        {
            // Si el personaje está en el suelo y el jugador pulsa espacio...
            if (IsGrounded)
            {
                // ... hacemos que el personaje salte aplicando una fuerza hacía arriba
                playerRigidbody.AddForce(Vector3.up * jumpForce);

                animator.SetTrigger("Jump");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // Si el objeto contra el que chocamos (collision.gameObject) está en las capas que consideramos suelo (layerMask)...
            if (layerMask == (layerMask | 1 << collision.gameObject.layer))
            {
                // ... establecemos que el personaje está en el suelo
                groundCollisions++;

                animator.SetBool("Grounded", IsGrounded);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            // Al dejar de estar en contacto con un objeto que sea suelo...
            if (layerMask == (layerMask | 1 << collision.gameObject.layer))
            {
                // ... establecemos que el personaje ya no está en el suelo
                groundCollisions--;

                animator.SetBool("Grounded", IsGrounded);
            }
        }
    }

}