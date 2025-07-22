using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI gameOverScoreUI;
    [SerializeField] private TextMeshProUGUI gameOverHighscoreUI;

    private GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;

        // Link GameOver event
        gm.onGameOver.AddListener(ActivateGameOverUI);

        // Start menu visible initially
        startMenuUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    public void PlayButtonHandler()
    {
        Debug.Log("Play button pressed");

        // Hide UI
        startMenuUI.SetActive(false);
        gameOverUI.SetActive(false);

        gm.StartGame();
    }

    public void ActivateGameOverUI()
    {
        Debug.Log("Activating GameOver UI");
        gameOverUI.SetActive(true);

        int finalScore = Mathf.RoundToInt(GameManager.instance.currentScore);
        gameOverScoreUI.text = "Score: " + finalScore;
        gameOverHighscoreUI.text = "Highscore: " + gm.ApproxHighscore();

        //  Open leaderboard page with ?score=<playerScore>
        Application.OpenURL(
            "https://midhanraj.github.io/TheBeastAtTheBack_BlockDAG/Leaderboard_Web/Leaderboard.html?score=" + finalScore
        );
    }

    private void OnGUI()
    {
        if (gm.isPlaying)
        {
            scoreUI.text = gm.ApproxScore();
        }
    }

    public void PopulateLeaderboard(List<string> formattedEntries)
    {
        foreach (var e in formattedEntries)
        {
            Debug.Log("Leaderboard entry: " + e);
        }
    }

    //  Redirect to external leaderboard manually
    public void OpenLeaderboardPage()
    {
        Application.OpenURL("https://midhanraj.github.io/TheBeastAtTheBack_BlockDAG/Leaderboard_Web/Leaderboard.html");
    }

    // Exit button
    public void ExitGame()
    {
        Debug.Log("Exit button pressed");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in Editor
#else
        Application.Quit(); // Quits the game in a build
#endif
    }
}
