using UnityEngine;

public class RecipeEnterComplete : MonoBehaviour
{
    public Animator btnTortangTalongAnimator;
    public Animator btnBananacueAnimator;
    public Animator btnEscabechengIsdaAnimator;

    public void PlayButtonAnimations()
    {
        // Activate buttons before animating
        btnTortangTalongAnimator.gameObject.SetActive(true);
        btnBananacueAnimator.gameObject.SetActive(true);
        btnEscabechengIsdaAnimator.gameObject.SetActive(true);

        // Now play enter animations
        btnTortangTalongAnimator.SetTrigger("Enter");
        btnBananacueAnimator.SetTrigger("Enter");
        btnEscabechengIsdaAnimator.SetTrigger("Enter");
    }

}
