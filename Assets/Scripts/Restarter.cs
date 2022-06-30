using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        public EnemyHealth E_Health;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (other.tag == "Enemy")
            {
                E_Health.currentHealth = 0;
            }
        }
        private void Start()
        {
            E_Health = FindObjectOfType <EnemyHealth>();
        }
    }
}
