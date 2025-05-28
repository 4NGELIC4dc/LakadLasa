using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public bool isCorrectIngredient;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play SFX
            if (PlayerController.Instance != null && PlayerController.Instance.pickSFX != null)
            {
                PlayerController.Instance.sfxAudioSource.PlayOneShot(PlayerController.Instance.pickSFX);
            }

            // Add to player’s ingredient list
            if (PlayerController.Instance != null)
            {
                PlayerController.Instance.CollectIngredient(this);
            }

            Destroy(gameObject);
        }
    }
}
