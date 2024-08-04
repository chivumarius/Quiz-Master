using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreKeeper : MonoBehaviour
{
    // ▼ "Variables" ▼
    int correctAnswers = 0;
    int questionsSeen = 0;



    // ▬▬▬▬▬▬▬▬▬▬▬ (1-1) "Getter Method" → for "Get Correct Answers" ▬▬▬▬▬▬▬▬▬▬▬
    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }



    // ▬▬▬▬▬▬▬▬▬▬▬ (1-2) "Setter Method" → to "Increment Correct Answers" ▬▬▬▬▬▬▬▬▬▬▬
    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ (2-1) "Getter Method" → for "Get Questions Seen" ▬▬▬▬▬▬▬▬▬▬▬
    public int GetQuestionSeen()
    {
        return questionsSeen;
    }



    // ▬▬▬▬▬▬▬▬▬▬▬ (2-2) "Setter Method" → to "Increment Questions Seen" ▬▬▬▬▬▬▬▬▬▬▬
    public void IncrementQuestionsSeen()
    {
        questionsSeen++;
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ "CalculateScore()" Method ▬▬▬▬▬▬▬▬▬▬▬
    public int CalculateScore()
    {
        // ▼ "Calculate" the "Score" and "Round" it to "Int" ▼
        return Mathf.RoundToInt(correctAnswers / (float) questionsSeen * 100);
    }
}
