using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // ▼ "Variables" for "Accessing" the "Scripts" ▼
    Quiz quiz;
    EndScreen endScreen;



    // ▬▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Find" the "Reference Object Types" to the "Quiz" and "End Screen" Class ▼
        quiz = FindAnyObjectByType<Quiz>();
        endScreen = FindAnyObjectByType<EndScreen>();
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ "Start()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void Start()
    {
        // ▼ "Toggle" the "Visibility" of the "Quiz" and "End Screen" GameObjects ▼
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ "Update()" Method ▬▬▬▬▬▬▬▬▬▬▬
    void Update()
    {
        // ▼ "Check" if the "Quiz Game" is "Completed" ▼
        if (quiz.isComplete)
        {
            // ▼ "Toggle" the "Visibility" of the "Quiz" and "End Screen" GameObjects ▼
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            
            // ▼ "Show" the "Final Score" in the "End Screen" ▼
            endScreen.ShowFinalScore();
        }
    }




    // ▬▬▬▬▬▬▬▬▬▬▬ "OnReplayLevel()" Method 
    //      → that is "Attached" to the "Replay Button" ▬▬▬▬▬▬▬▬▬▬▬
    public void OnReplayLevel()
    {
        // ▼ "Reload" the "Active Scene" ▼
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
