using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Characters")]
    public GameObject[] characters; // Drag Character A, B, C here in Inspector
    private Animator currentAnimator;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (characters.Length == 0)
        {
            Debug.LogError("No characters assigned in GameManager!");
            return;
        }

        ActivateCharacter(0); // Start with Character A by default
    }

    /// <summary>
    /// Activate a character by index and assign its Animator.
    /// Only the selected character is visible.
    /// </summary>
    public void ActivateCharacter(int index)
    {
        if (index < 0 || index >= characters.Length)
        {
            Debug.LogError("Character index out of range!");
            return;
        }

        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(i == index);
            if (i == index)
            {
                currentAnimator = characters[i].GetComponent<Animator>();
                if (currentAnimator == null)
                    Debug.LogError("Animator missing on " + characters[i].name);
            }
        }
    }

    /// <summary>
    /// Play a character action (Action1 or Action2).
    /// Action index should match your Animator parameter values.
    /// </summary>
    public void PlayAction(int actionIndex)
    {
        if (currentAnimator == null)
        {
            Debug.LogError("Current character Animator not assigned!");
            return;
        }

        currentAnimator.SetInteger("Action", actionIndex);
    }

    private void Update()
    {
        // Optional: keyboard input for testing
        if (Input.GetKeyDown(KeyCode.Alpha1)) PlayAction(1); // Action1
        if (Input.GetKeyDown(KeyCode.Alpha2)) PlayAction(2); // Action2

        if (Input.GetKeyDown(KeyCode.Q)) ActivateCharacter(0);
        if (Input.GetKeyDown(KeyCode.W)) ActivateCharacter(1);
        if (Input.GetKeyDown(KeyCode.E)) ActivateCharacter(2);
    }
}
