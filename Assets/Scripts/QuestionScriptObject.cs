using UnityEngine;


// ▼ "Class Attribute" 
//      → will "Create" a "Quiz Question" Menu 
//      → direct into "Unity Editor" - "Assets" Menu in "Create" Option 
//      → (or by R"ight-Clicking" in "Assets" Folder 
//      → and trying to "Create" a "New Object")
[CreateAssetMenu(fileName = "New Question", menuName = "Quiz Question")]
public class QuestionScriptObject : ScriptableObject
{    
    // ▼ "Serialize Field" Attribute
    //      → that allow "Access" from the "Inspector" of "Unity Editor"
    //      → but "Don't Allow Access" from "Another Class" ▼
    // ▼ "Text Area(minSize, maxSize)" Attribute 
    //      → allow  to "Adjust" and "Control" 
    //      → the "Size" of the "Text Box" in the "Inspector" ▼
    [TextArea(2, 6)] 
    [SerializeField] string question = "Enter new question text here";


    // ▼ "Serialize Array Variable" of "4 String Elements" ▼
    [SerializeField] string[] answers = new string[4];

    [SerializeField] int correctAnswerIndex;


    // ▬▬▬▬▬▬▬▬▬▬▬ "GetQuestion()" Getter Method ▬▬▬▬▬▬▬▬▬▬▬
    public string GetQuestion()
    {
        // ▼ "Return" the "question" String Variable ▼
        return question;
    }



    // ▬▬▬▬▬▬▬▬▬▬▬ "GetAnswer()" Getter Method ▬▬▬▬▬▬▬▬▬▬▬
    public string GetAnswer(int index)
    {
        // ▼ "Return" the "answers" String Array Variable ▼
        return answers[index];
    }



    
    // ▬▬▬▬▬▬▬▬▬▬▬ "GetCorrectAnswerIndex()" Getter Method ▬▬▬▬▬▬▬▬▬▬▬
    public int GetCorrectAnswerIndex()
    {
        // ▼ "Return" the "correctAnswerIndex" Int Variable ▼
        return correctAnswerIndex;
    }    
}
