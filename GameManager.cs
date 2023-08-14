using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject[] targets2;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private float spawnRate = 1.0f;
    public bool isGameActive;
    public GameObject titleScreen;
    public Button restartButton;
    //reference to the sound effect dictionary
    public SoundEffects soundEffects;
    public int consecutiveScore;


    // Start is called before the first frame update
    void Start()
    {




    }


    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int ScoreToAdd)
    {
        if (ScoreToAdd > 0)
        {
            soundEffects.PlaySoundEffect(key: "Good");
        }
        if (ScoreToAdd < 0)
        {
            soundEffects.PlaySoundEffect(key: "Bad");

        }
        else (ScoreToAdd)

        score += ScoreToAdd;
        scoreText.text = "Score: " + score;

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        // play game over sound effect 
        soundEffects.PlaySoundEffect(key: "Gameover");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());

        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;


    }

}


