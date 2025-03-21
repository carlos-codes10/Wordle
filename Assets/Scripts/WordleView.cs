using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

                rows[y].GetChild(x).GetComponent<Image>().color = FindAnyObjectByType<WordleModel>().cells[y,x].color;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
