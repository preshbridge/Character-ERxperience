using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    public Button playButton;
    public Button optionsButton;
    public Button exitButton;

    [Header("Character Buttons (GameScene)")]
    public Button characterAButton;
    public Button characterBButton;
    public Button characterCButton;

    [Header("Action Buttons (GameScene)")]
    public Button action0Button;
    public Button action1Button;
    public Button action2Button;

    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;

    private void Awake()
    {
        // Show menu at start
        if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
        if (optionsPanel != null) optionsPanel.SetActive(false);
    }

    private void Start()
    {
        // ---------- MAIN MENU ----------
        if (playButton != null)
            playButton.onClick.AddListener(PlayGame);

        if (optionsButton != null)
            optionsButton.onClick.AddListener(OpenOptions);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);

        // ---------- CHARACTER SELECTION ----------
        if (characterAButton != null)
            characterAButton.onClick.AddListener(() => GameManager.instance.ActivateCharacter(0));

        if (characterBButton != null)
            characterBButton.onClick.AddListener(() => GameManager.instance.ActivateCharacter(1));

        if (characterCButton != null)
            characterCButton.onClick.AddListener(() => GameManager.instance.ActivateCharacter(2));

        // ---------- ACTION BUTTONS ----------
        if (action0Button != null)
            action0Button.onClick.AddListener(() => GameManager.instance.PlayAction(0));

        if (action1Button != null)
            action1Button.onClick.AddListener(() => GameManager.instance.PlayAction(1));

        if (action2Button != null)
            action2Button.onClick.AddListener(() => GameManager.instance.PlayAction(2));
    }

    // ================= MAIN MENU LOGIC =================

    void PlayGame()
    {
        // Hide Main Menu panel
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        // Load your GameScene
        SceneManager.LoadScene("GameScene"); // <-- Make sure this matches your scene name
    }

    void OpenOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(true);

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        if (optionsPanel != null)
            optionsPanel.SetActive(false);
    }

    void ExitGame()
    {
        Debug.Log("Exit Game"); // Shows in editor
        Application.Quit(); // Works in build
    }
}
