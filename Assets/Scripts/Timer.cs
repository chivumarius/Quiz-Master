using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;    // ◄◄ "30 seconds" ◄◄
    [SerializeField] float timeToShowCorrectAnswer = 10f;   // ◄◄ "10 seconds" ◄◄


    public bool loadNextQuestion;
    public float fillFraction;


    // ▬ "Variables" ▬public float fillFraction;
    // ▼ "Variable" to "Switch" between
    //     → "Time" To "Complete Next Question Question"
    //     → and "Time" To "Show" the "Correct Answer" ▼
    public bool isAnsweringQuestion;
    
    float timerValue;




    // ▬▬▬▬▬▬▬▬▬▬▬ "Update()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void Update()
    {
        // ▼ "Call" the "Method" ▼
        UpdateTimer();
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ "CancelTimer()" Method ▬▬▬▬▬▬▬▬▬▬▬
    public void CancelTimer()
    {
        // ▼ "Set" the "Timer  Value" to "0" ▼
        timerValue = 0;
    }





    // ▬▬▬▬▬▬▬▬▬▬▬ "UpdateTimer()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        // ▼ If - "Answering Question" is "True" ▼   
        if(isAnsweringQuestion)
        {
            // ▼ "Set" the "Timer  Value" to "10 seconds" ▼
            if(timerValue > 0)
            {
                // ▼ "Calculate" the "Fill Fraction" ▼
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                // ▼ "Set" the "Answering Question" to "False" ▼
                isAnsweringQuestion = false;
                
                // ▼ "Set" the "Timer  Value" to "10 seconds" ▼
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            // ▼ "Set" the "Timer  Value" to "30 seconds" ▼
            if(timerValue > 0)
            {
                // ▼ "Calculate" the "Fill Fraction" ▼
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                // ▼ "Set" the "Answering Question" to "True" ▼
                isAnsweringQuestion = true;
                
                // ▼ "Set" the "Timer  Value" to "30 seconds" ▼
                timerValue = timeToCompleteQuestion;
                
                // ▼ "Set" the "Load Next Question" to "True" ▼
                loadNextQuestion = true;
            }
        }
    }
}
