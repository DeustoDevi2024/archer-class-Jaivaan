using UnityEngine;
using UnityEngine.InputSystem;

namespace Archer
{

    public class Move : MonoBehaviour
    {

        // Exponer en una variable la velocidad de caminar
        private float walkSpeed;
        // Exponer en una variable la velocidad de rotación
        private float rotateSpeed;

        [SerializeField]
        private InputActionAsset inputActionAsset;

        [SerializeField]
        private float particlesModifier;

        [SerializeField]
        private ParticleSystem particleSystem;

        private Rigidbody playerRigidbody;

        private InputAction moveAction;

        private Animator animator;

        private Jump jump;

        private void Awake()
        {
            // Coger una referencia al Rigidbody del jugador
            playerRigidbody = GetComponent<Rigidbody>();

            animator = GetComponent<Animator>();

            inputActionAsset.Enable();
            moveAction = inputActionAsset.FindAction("Move");

            jump = GetComponent<Jump>();
        }

        private void Start()
        {
            var gameConfig = AppLogic.Instance.GetGameConfig();
            walkSpeed = gameConfig.walkSpeed;
            rotateSpeed = gameConfig.rotateSpeed;
        }

        // Para mover con el Rigidbody, usamos la función FixedUpdate
        private void FixedUpdate()
        {
            // Coger, con la clase Input, los ejes Horizontal y Vertical
            //var horizontal = Input.GetAxis("Horizontal");
            //var vertical = Input.GetAxis("Vertical");

            var movement = moveAction.ReadValue<Vector2>();

            // Llamar a las funciones de caminar y rotar con los valores del input
            Walk(movement.y);
            Rotate(movement.x);

            animator.SetFloat("VerticalSpeed", playerRigidbody.velocity.y);
        }

        private void Walk(float amount)
        {
            // Mover con el transform
            //transform.Translate(Vector3.forward * Time.deltaTime * walkSpeed * amount);

            var emission = particleSystem.emission;
            if (jump.IsGrounded)
            {
                emission.rateOverTime = amount * walkSpeed * particlesModifier;
            }
            else
            {
                emission.rateOverTime = 0;
            }

            animator.SetFloat("HorizontalSpeed", amount * walkSpeed);

            // Mover con el Rigidbody
            playerRigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * walkSpeed * amount);
        }

        private void Rotate(float amount)
        {
            // Rotar con el transform
            //transform.Rotate(Vector3.up * amount * Time.deltaTime * rotateSpeed);

            // Rotar con el Rigidbody
            playerRigidbody.MoveRotation(Quaternion.Euler(transform.eulerAngles + Vector3.up * amount * Time.deltaTime * rotateSpeed));
        }

    }

}