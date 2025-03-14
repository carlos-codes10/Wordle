using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        row++;
        currentAttempt++;
    }

    public bool isValidGuess(string s)
    {
        return s.Trim() == correctAnswer.Trim();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
