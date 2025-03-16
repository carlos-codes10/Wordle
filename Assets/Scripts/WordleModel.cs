using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WordleModel : MonoBehaviour
{
    [SerializeField] TextAsset possibleAnswersAsset;
    [SerializeField] TextAsset allowedWordsAsset;
    public int currentAttempt;
    public string correctAnswer;
    public Cell[,] cells = new Cell[6,5];
    public string[] allowedWords;
    public string[] possibleAnswers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allowedWords = allowedWordsAsset.ToString().Split('\n');
        possibleAnswers = possibleAnswersAsset.ToString().Split('\n');
    }

    public void Setup()
    {
        Debug.Log("WordModel Setup Function Called!");

        List<string> answerList = new List<string>(possibleAnswers);

        int randomIndex = Random.Range(0, answerList.Count());
        correctAnswer = answerList[randomIndex];
        Debug.Log("Correct Answer: " + correctAnswer);

        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                cells[y, x] = new Cell();
            }
        }
    }

    int row = 0;
    public void UpdateCells()
    {
        string guessedWord = FindAnyObjectByType<WordleController>().input.text.ToUpper();

        for (int x = 0; x < 5; x++)
        {
            cells[row, x].letter = guessedWord[x];
        }

        correctAnswer = correctAnswer.ToUpper();

        for (int i = 0; i < correctAnswer.Length; i++)
        {
            if (correctAnswer[i] == guessedWord[i])
            {
                cells[row, i].color = Color.green;
                Debug.Log(guessedWord[i] + " is in the right spot!");
            }
            else if (correctAnswer.Contains(guessedWord[i]))
            {
                cells[row, i].color = Color.yellow;
                Debug.Log(guessedWord[i] + " is somewhere in the word");
            }
            else
            {
                cells[row, i].color = Color.gray;
                Debug.Log(guessedWord[i] + " is not in the word");
            }
        }
            row++;
        currentAttempt++;
    }

    public bool isValidGuess(string s)
    {
        return s.Trim().ToUpper() == correctAnswer.Trim().ToUpper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
