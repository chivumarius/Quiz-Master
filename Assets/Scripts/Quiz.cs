using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Quiz : MonoBehaviour
{
    // ====== "Header()" Attribute  for "Questions"
    //      → (to  "Make" the "Component" n the "Inspector"
    //      → "Easier" to "Use" & "Read") ======
    [Header("Questions")]
    
    // ▼ "Unity Graphical User Interface" ("UGUI") 
    //      → as "Reference" to the "Text Elements" on the "Canvas" ▼
    [SerializeField] TextMeshProUGUI questionText;

    // ▼ "Serialize Field" Variable for "List of Questions" ▼
    [SerializeField] List<QuestionScriptObject> questions = new List<QuestionScriptObject>();

    QuestionScriptObject currentQuestion;



    // ====== "Header()" Attribute  for "Answers" ======
    [Header("Answers")] 

    // ▼ "Serialize Field Variable" (from an "Array of Game Objects")
    //      → as "Reference" to the "Answer Buttons" ▼
    [SerializeField] GameObject[] answerButtons;

    // ▼ "Reference" to "Index of Correct Answer" ▼
    int correctAnswerIndex;
    
    // ▼ "Show Answer" when we "Click" the "Button" or "Timer Ends" ▼
    bool hasAnsweredEarly = true;



    // ====== "Header()" Attribute  for "Button Colors" ======
    [Header("Button Colors")] 

    // ▼ "Reference" to "Buttons Sprite" ▼
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;



    // ♦♦ ""Connecting" the "Timer" Class to the "Quiz" Class ♦♦
    // ====== "Header()" Attribute  for "Timer" ======
    [Header("Timer")] 

    [SerializeField] Image timerImage;  
        Timer timer;  


    // ====== "Header()" Attribute  for "Scoring" ======
    [Header("Scoring")] 
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper; 



    // ====== "Header()" Attribute  for "ProgressBar" ======    [Header("ProgressBar")]
    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    // ▼ "Variable" to "Check" if "Quiz" is "Complete" ▼
    public bool isComplete;




    // ▬▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Find" the "Reference" to the "Timer" Class ▼
        timer = FindAnyObjectByType<Timer>();

        // ▼ "Find" the "Reference" to the "Score Keeper" Class ▼
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();


        // ▼ "Set" the "Max Value" of "Progress Bar" 
        //      → to "Get" All "Questions" ▼
        progressBar.maxValue = questions.Count;
        // ▼ "Set" the "Staring Value" of "Progress Bar" ▼
        progressBar.value = 0;
    }



    // ▬▬▬▬▬▬▬▬▬▬▬ "Update()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void Update()
    {
        // ▼ "Set" the "Fill Amount" of "Timer Image"
        //      → to the "Fill Fraction" of the "Timer" Class ▼
        timerImage.fillAmount = timer.fillFraction;
        
        
        // ▼ "Check" the "State" of the "Timer"
        //      → to "Load" the "Next Question" ▼
        if(timer.loadNextQuestion)
        {
            // ▼ "Check" if "Quiz" is "Complete" ▼
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }



            // ▼ "Disable" the "Has Answered Early" State for "Timer" ▼
            hasAnsweredEarly = false;
            
            // ▼ "Call" the "Method" ▼
            GetNextQuestion();
            
            // ▼ "Disable" the "Load Next Question" State for "Timer" ▼
            timer.loadNextQuestion = false;
        }

        // ▼ "Second Check" the "State" of the "Timer" ▼
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            // ▼ "Do Not Display" the "Answer" ▼
            DisplayAnswer(-1);  // ◄◄ "Because" we can't "Pass Numbers" between "0" & "3" ◄◄ 
            
            // ▼ "Disable" the "Button" State ▼ 
            SetButtonState(false);
        }
    }

    
    
    
    // ▬▬▬▬▬▬▬▬▬▬▬ "OnAnswerSelected()" Method 
    //      → to "Select" the "Correct Answer", 
    //      → which will "Connect" with all "4 Buttons" ▬▬▬▬▬▬▬▬▬▬▬
    public void OnAnswerSelected(int index)
    {
        // ▼ "Set" the "Has Answered Early" State ▼
        hasAnsweredEarly = true;

        // ▼ Call" the "Method" ▼
        DisplayAnswer(index);

        // ▼ "Call" the "Method" and "Disable" the "Buttons" ▼
        SetButtonState(false);

        // ▼ "Cancel" the "Timer" ▼
        timer.CancelTimer();

        // ▼ "Set" the "Text" of "Score Text" ▼
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";       
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ "Display Answer()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void DisplayAnswer(int index)
    {
        // ▼ "Variable Declaration" ▼
        Image buttonImage;


        // ▼ "If Statement" ▼
        if(index == currentQuestion.GetCorrectAnswerIndex())
        {    
            // ▼ "Set" the "Text" of the "questionText" Text Element ▼        
            questionText.text = "Correct!";
            
            // ▼ "Get" the "Image Component" 
            //      → from the "answerButtons" Array ▼
            buttonImage = answerButtons[index].GetComponent<Image>();
            
            // ▼ "Set" the "Correct Answer Sprite" 
            //      → to the "Sprite" of the "buttonImage" Image Element ▼  
            buttonImage.sprite = correctAnswerSprite;

            // ▼ "Increment" the "Correct Answers" of "Score" ▼
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            // ▼ "Get" the "Correct Answer" of the "Question" ▼
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            
            // ▼ "Get" the "Answer" of the "Question" ▼
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            
            // ▼ "Set" the "Text" of the "questionText" Text Element ▼
            questionText.text = "Sorry, the correct answer was;\n" + correctAnswer;
            
            // ▼ "Get" the "Image Component"
            //      → from the "answerButtons" Array ▼
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            
            // ▼ "Set" the "Correct Answer Sprite" ▼
            buttonImage.sprite = correctAnswerSprite;
        }
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ "Get Next Question()" Method ▬▬▬▬▬▬▬▬▬▬▬
    public void GetNextQuestion()
    {
        // ▼ "If" the "List" is not "Empty" ▼
        if (questions.Count > 0)
        {

            // ▼ "Call" the "Method" and "Enable" the "Buttons" ▼
            SetButtonState(true);

            // ▼ "Call" the "Method" ▼
            SetDefaultButtonSprites();

            // ▼ "Call" the "Method" ▼
            GetRandomQuestion();
            
            // ▼ "Call" the "Method" ▼
            DisplayQuestion();


            // ▼ "Increment" the "Progress Bar" ▼
            progressBar.value++;


            // ▼ "Call" the "Method" ▼
            scoreKeeper.IncrementQuestionsSeen();
        }
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ "GetRandomQuestion()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void GetRandomQuestion()
    {
        // ▼ Call" the "Range(minNumver, maxNumber)" Nethod ▼
        int index = Random.Range(0, questions.Count);
        
        // ▼ "Set" the "Current Question" to the "Random Question" ▼
        currentQuestion = questions[index];


        // ▼ "check" if the "Random Question" is in the "List" ▼
        if(questions.Contains(currentQuestion))
        {
            // ▼ "Removing" the "Random Question" from the "List" ▼
            questions.Remove(currentQuestion);
        }           
    }


    // ▬▬▬▬▬▬▬▬▬▬▬ "Display Question()" Method ▬▬▬▬▬▬▬▬▬▬▬
    public void DisplayQuestion()
    {
        // ▼ "Set" the "Text" of the "questionText" Text Element 
        //      → to "Get" the "Question" of the "question" Script Object ▼
        questionText.text = currentQuestion.GetQuestion();


        // ▼ "For() Loop▼
        for(int i = 0; i < answerButtons.Length; i++)
        {
            // ▼ "Get" the "Answer" of the "question" Script Object 
            //      → and "Set It" to "answerButtons" Array ▼
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            
            // ▼ "Set" the "Text" of the "Answer Buttons" 
            //      → to  the "Answer" of the "Stored Question" ▼
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ "SetButtonState()" Method ▬▬▬▬▬▬▬▬▬▬▬
    public void SetButtonState(bool state)
    {
        // ▼ "Looping" through all "4 Answer Buttons"
        //      → and "Set" the "Interactable" State ▼
        for(int i = 0; i < answerButtons.Length; i++)
        {
            // ▼ "Get" the "Button Component" 
            //      → from the "answerButtons" Array ▼
            Button button = answerButtons[i].GetComponent<Button>();
            
            // ▼ "Set" the "Interactable" State of the "Button"
            //      → to "state" ▼
            button.interactable = state;
        }
    }



    // ▬▬▬▬▬▬▬▬▬▬▬ "SetDefaultButtonSprites()" Method ▬▬▬▬▬▬▬▬▬▬▬
    public void SetDefaultButtonSprites()
    {
        // ▼ "Looping" through all "4 Answer Buttons"
        //      → and "Set" the "Sprite" of the "Button" ▼
        for(int i = 0; i < answerButtons.Length; i++)
        {
            // ▼ "Get" the "Image Component" 
            //      → from the "answerButtons" Array ▼
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            
            // ▼ "Set" the "Sprite" of the "Button" 
            //      → to "defaultAnswerSprite" ▼
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
