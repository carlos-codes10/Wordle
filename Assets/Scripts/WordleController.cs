using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System.Linq;
public class WordleController : MonoBehaviour
{
    public TMP_InputField input;

    [SerializeField] WordleModel model;
    [SerializeField] WordleView view;

    [SerializeField] GameObject GameWinUI;
    [SerializeField] GameObject GameOverUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        GameSetup();
    }

    public void GameSetup()
    {
        input.text = "";
        model.Setup();
        view.Setup();
    }

    public void SubmitGuess()
    {
        

        string word = input.text.ToLower();
        if (word.Length != 5)
        {
            Debug.Log("NOT ENOUGH LETTERS OR TOO MANY");
            return;
        }

        if (model.isValidGuess(word))
        {
            WinGame();
        }

        if (model.allowedWords.Contains(word) || model.possibleAnswers.Contains(word))
        {
            model.UpdateCells();
            view.UpdateView();
            Debug.Log("Good Input!");
        }
        else
        {
            Debug.Log("Invalid Input!");
        }


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinGame()
    {
        GameWinUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("You Win!");
    }
    public void LoseGame()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("You Lose!");
    }
    // Update is called once per frame
    void Update()
    {
        

        if (model.currentAttempt >= 6)
       {
            LoseGame();
       }
    }
}
