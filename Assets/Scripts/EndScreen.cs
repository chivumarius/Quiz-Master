using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndScreen : MonoBehaviour
{
    // ▼ "Fields" that "Need" to be "Accessed" ▼
    [SerializeField] TextMeshProUGUI finalScoreText;        
    ScoreKeeper scoreKeeper;    // ◄◄ to Display "Final Score" ◄◄




    // ▬▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Find" the "Reference" to the "Score Keeper" Class ▼
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }



    // ▬▬▬▬▬▬▬▬▬▬▬ "ShowFinalScore()" Method 
    //      → to "Update" the "Final Score" 
    //      → whend the "End Screen" is "Shown" ▬▬▬▬▬▬▬▬▬▬▬
    public void ShowFinalScore()
    { 
        // ▼ "Updating" the "Text" of "Final Score Text" ▼
        finalScoreText.text = "Congratulations!\nYou got a score of " + 
                                scoreKeeper.CalculateScore() + "%";
    }
}
