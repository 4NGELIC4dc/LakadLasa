using UnityEngine;

public class RecipeEnterComplete : MonoBehaviour
{
    public Animator btnTortangTalongAnimator;
    public Animator btnBananacueAnimator;
    public Animator btnEscabechengIsdaAnimator;

    // Called at the end of RecipesEnter animation
    public void PlayButtonAnimations()
    {
        btnTortangTalongAnimator.SetTrigger("Enter");
        btnBananacueAnimator.SetTrigger("Enter");
        btnEscabechengIsdaAnimator.SetTrigger("Enter");
    }
}
