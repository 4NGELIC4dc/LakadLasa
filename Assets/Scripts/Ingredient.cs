using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public bool isCorrectIngredient;
    public string ingredientID; // Add this field

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.Instance != null && PlayerController.Instance.pickSFX != null)
            {
                PlayerController.Instance.sfxAudioSource.volume = GameSettingsManager.Instance.sfxVolume;
                PlayerController.Instance.sfxAudioSource.PlayOneShot(PlayerController.Instance.pickSFX, GameSettingsManager.Instance.sfxVolume);
            }

            if (PlayerController.Instance != null)
            {
                PlayerController.Instance.CollectIngredient(this);

                if (!isCorrectIngredient && GameSettingsManager.Instance.isHapticsEnabled)
                {
#if UNITY_ANDROID
                    Handheld.Vibrate();
#endif
                }
            }

            Destroy(gameObject);
        }
    }
}
