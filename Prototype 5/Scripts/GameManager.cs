using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public List<GameObject> targets;
    public GameObject titleScreen;
    private float spawnRate = 1.0f;
    private bool isGameActive;
    private int score;

    public void StartGame(int difficulty) {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }
    public void UpdateScore(int point) {
        if (isGameActive)
        {
            score += point;
            scoreText.text = "Score: " + score;
        }
       
    }
    IEnumerator SpawnTarget() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
                int randomIndex = Random.Range(0, 4);
                Instantiate(targets[randomIndex]);
        }
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
