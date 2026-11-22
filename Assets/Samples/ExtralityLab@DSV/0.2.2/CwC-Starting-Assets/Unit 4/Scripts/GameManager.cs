
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public GameObject gameOverPanel;

    public float fallDistance = 50f;

    private float startingHeight;
    private bool gameOver = false;

    void Start()
    {
        startingHeight = player.position.y;

        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!gameOver && player.position.y < startingHeight - fallDistance)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Replay()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
