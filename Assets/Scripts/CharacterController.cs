using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        // Get Animator component on this character
        animator = GetComponent<Animator>();

        if (animator == null)
            Debug.LogError("Animator not found on " + gameObject.name);
    }

    // Called by GameManager to play an action
    public void PlayAction(int actionIndex)
    {
        if (animator == null) return;

        animator.SetInteger("ActionIndex", actionIndex);
        animator.SetTrigger("PlayAction");
    }
}
