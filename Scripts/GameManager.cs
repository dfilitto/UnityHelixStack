using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //dados da classe
    public static bool isGameStarted = false; //indica se o game ja iniciou
    public static bool gameOver = false; //indicar que o player perdeu!!!!
    public static bool levelCompleted = false; //passei de nivel!!!!
    public static bool mute = false; //controla o estado do som
    public static int currentLevelIndex; //nivel atual do jogo
    public static int numberOfPassedRings; //quatidade de aneis que o plauer passou
    public static int score = 0; //pontuação atual
    public static int highScore = 0; //maior pontuação feita

    //itens da hud
    public GameObject gamePlayPanel; //painel do progress bar
    public GameObject gameOverPanel; //painel do Game Over
    public GameObject gameMenuPanel;
    public GameObject levelCompletedPanel; //painel do Game Over
    

    public Slider progressBarSlider; //slider
    public TextMeshProUGUI currentLevelText; // texto no nivel atual
    public TextMeshProUGUI nextLevelText; //texto do próximo nivel
    public TextMeshProUGUI scoreText; //texto do score
    public TextMeshProUGUI scoreGameOverText; //texto do score
    public TextMeshProUGUI highScoreGameOverText; //texto do score

    // Start is called before the first frame update
    private void Awake()
    {
        //Descomente a linha para resetar o jogo
        //PlayerPrefs.SetInt("CurrentLevelIndex", 1);
        //pegar dados da memória do dispositivo
        highScore = PlayerPrefs.GetInt("HighScore",0);
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    void Start()
    {
        //Time.timeScale = 1; //desativando o pause no jogo
        if (gameOver)
        {
            gameOver = false;
            score = 0;
            isGameStarted = false;

        }

        if (!isGameStarted)
        {
            gameMenuPanel.SetActive(true);
        }

        levelCompleted = false;
        //isGameStarted = false;
        numberOfPassedRings = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //implementar controle de HUD
        //informar o nivel atual e o score
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex+1).ToString();
        scoreText.text = score.ToString();
        //altera o valor da barra de progresso
        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        progressBarSlider.value = progress;

        //controlar o inicio de jogo

        //controlar o game over
        if (gameOver)
        {
            //Time.timeScale = 0; //pausar o jogo
            if(score > highScore)
            {
                highScore = score;
                PlayerPrefs.SetInt("HighScore",highScore);
            }
            scoreGameOverText.text = "SCORE: " + score.ToString();
            highScoreGameOverText.text = "HIGH SCORE: " + highScore.ToString();
            gamePlayPanel.SetActive(false);
            gameOverPanel.SetActive(true);
            Invoke("RestartLevel", 2f);
            //controlar a cena e exibir o high score
            //implementar mecânica de pontuação

            //desktop
            //if (Input.GetButton("Fire1"))
            //{
            //    GameManager.score = 0;
            //    SceneManager.LoadScene(0);
            //}

            //implementar a versão mobile
        }

        if (levelCompleted)
        {
            //Time.timeScale = 0;
            //controlar a cena e exibir o reinicio
            PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex+1);
            gamePlayPanel.SetActive(false);
            levelCompletedPanel.SetActive(true);
            Invoke("RestartLevel", 2f);
            //desktop
            //if (Input.GetButton("Fire1"))
            //{
            //    SceneManager.LoadScene(0);
            //}

            //implementar a versão mobile
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Funcionou!!!!!");
    }
}
