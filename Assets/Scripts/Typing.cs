using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class TypingBar : MonoBehaviour
{
    public TextMeshProUGUI letterDisplay; 
    public TextMeshProUGUI roundDisplay;  
    public Image progressBar;
    private List<char> letters = new List<char>(); 
    private int score = 0;  
    private int round = 1;  

    void Start()
    {
        // 隨機生成100個字母並顯示前10個
        GenerateInitialLetters();
        UpdateLetterDisplay();
        UpdateRoundDisplay();  
    }

   
    void Update()
    {
       
        if (Input.anyKeyDown && "QWER".Contains(letters[0].ToString()))
        {
            
            KeyCode expectedKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), letters[0].ToString().ToUpper());

            
            if (Input.GetKeyDown(expectedKey))
            {
                RemoveLetter();
                AddScore(); 
            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R))
            {
               
                StartCoroutine(FlashRed());
            }
        }
    }

    IEnumerator FlashRed()
    {
        // 暫時設置第一個字母顯示為紅色
        letterDisplay.text = $"<color=#FF0000>{letters[0]}</color>";

        yield return new WaitForSeconds(0.2f);

        UpdateLetterDisplay();
    }

    void GenerateInitialLetters()
    {
        letters.Clear(); 
        for (int i = 0; i < 100; i++)
        {
            letters.Add(GetRandomLetter());
        }
    }

    void RemoveLetter()
    {
        letters.RemoveAt(0); 
        letters.Add(GetRandomLetter());  
        UpdateLetterDisplay();
    }

    char GetRandomLetter()
    {
        char[] possibleLetters = { 'Q', 'W', 'E', 'R' };
        return possibleLetters[Random.Range(0, possibleLetters.Length)];
    }

    void UpdateLetterDisplay()
    {
        string displayText = "";

        displayText += $"<color=#FFFFFF>{letters[0]}</color>";

        for (int i = 1; i < 10; i++)
        {
            displayText += $"<color=#80808088>{letters[i]}</color>";
        }

        letterDisplay.text = displayText;
    }

    void AddScore()
    {
        score++;  
        float progress = (float)score / 100f;  
        UpdateProgressBar(progress);

        if (progress >= 1.0f)
        {
            score = 0;  
            round++;  
            UpdateRoundDisplay(); 
            UpdateProgressBar(0);
        }
    }

    void UpdateProgressBar(float progress)
    {
        progressBar.fillAmount = progress;
    }

    void UpdateRoundDisplay()
    {
        roundDisplay.text = "Round: x" + round.ToString(); 
    }
}