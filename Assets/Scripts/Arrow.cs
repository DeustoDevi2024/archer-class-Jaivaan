using UnityEngine;

namespace Archer
{

    public class Arrow : MonoBehaviour
    {

        private Rigidbody arrowRigidbody;
        private bool hit;

        private void Awake()
        {
            // Establecer las referencias de Rigidbody (para detener la flecha) y AudioSource (para el sonido de impacto)
            arrowRigidbody = GetComponent<Rigidbody>();
           
        }

        // El rigidbody de la flecha es tipo Trigger, para que no colisione
        private void OnTriggerEnter(Collider other)
        {
            // La flecha s�lo produce da�o y ruido en el primer impacto
            if (hit) {
                return;
            }

            // Si impacta con el jugador, lo ignoramos
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                return;
            }

            hit = true;

            // Reproducir el impacto de la flecha
            AudioSource impactSound = other.GetComponent<AudioSource>();
            if (impactSound != null)
            {
                impactSound.Play();
            }

            // Hacemos que la flecha sea hija del objeto contra el que impacta, para que se mueva con él
            transform.parent = other.transform;

            // Hacemos que la flecha sea kinematica para que no responda a nuevas aceleraciones (se quede clavada)
            arrowRigidbody.isKinematic = true;

            // Miramos a ver si el objeto contra el que ha impactado la flecha tiene un componente Enemy...
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                // ... Y si lo tiene, le hacemos daño (la siguiente comprobación es equivalente a hacer if (enemy != null) { enemy.Hit(); }
                enemy.Hit();
            }
        }

    }

}