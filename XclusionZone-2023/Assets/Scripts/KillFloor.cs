using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public int damageAmount = 999; // Set a high damage amount to ensure the character dies

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        if (other.CompareTag("Player")) // Assuming your player has the tag "Player"
        {
            print("A");
            print(other);
            PlayerHealth playerHealth = other.transform.parent.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                //playerHealth.TakeDamage(damageAmount);
                playerHealth.Die();
                print("B");
            }
        }
    }
}
