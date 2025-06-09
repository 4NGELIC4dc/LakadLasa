using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public bool isCorrectIngredient;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.Instance != null && PlayerController.Instance.pickSFX != null)
            {
                PlayerController.Instance.sfxAudioSource.PlayOneShot(PlayerController.Instance.pickSFX);
            }

            if (PlayerController.Instance != null)
            {
                PlayerController.Instance.CollectIngredient(this);
            }

            Destroy(gameObject);
        }
    }
}
