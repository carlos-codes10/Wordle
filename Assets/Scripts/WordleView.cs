using TMPro;
using UnityEngine;

public class WordleView : MonoBehaviour
{

    [SerializeField] Transform[] rows;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Setup()
    {
        Debug.Log("View Setup Function Called!");
        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                rows[y].GetChild(x).GetComponentInChildren<TMP_Text>().text = " ";

            }
        }
    }
    public void UpdateView()
    {

        for (int y = 0; y < 6; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                rows[y].GetChild(x).GetComponentInChildren<TMP_Text>().text = 
                    FindAnyObjectByType<WordleModel>().cells[y,x].letter.ToString();
            }
        }
        string answer = FindAnyObjectByType<WordleModel>().correctAnswer;
        string guessedWord = FindAnyObjectByType<WordleController>().input.text.ToLower();

        for (int i = 0; i < 6; i++)
        {
            //if (answer ==)
            {
                
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
