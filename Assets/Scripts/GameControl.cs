using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    public TMP_Text scoreText;
    private int score = 0;
    private AudioSource audioSource;
    public AudioClip dieClip;
    public AudioClip scoreClip;
    

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true); 
        gameOver = true;

        audioSource.PlayOneShot(dieClip);
    }

    public void BirdScored()
    {
        if (gameOver) return;
        score++;
        scoreText.text = "Score: " + score.ToString();

        audioSource.PlayOneShot(scoreClip);
    }
}
