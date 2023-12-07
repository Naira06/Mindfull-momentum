using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManage : MonoBehaviour
{
   
    public Button Restart;      //the restart button

    public Text score;        // the Text component for displaying the score
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the score text to display the current score obtained from the RandomDigit script.
        score.text = "Your Score: " + RandomDigit.currentScore.ToString();
    }
    void OnEnable()
    {
       
        Restart.onClick.AddListener(RestartScene); // Listen to the restart  button click event
    }

    void OnDisable()
    {
        
        Restart.onClick.RemoveListener(RestartScene); // Stop listening to the restart button click event
    }
   
    public void RestartScene()
    {
        RandomDigit.currentScore = 0;       // Reset the score to zero
              
    }
    public void Scene(){
        SceneManager.LoadScene("SampleScene");   // Load the scene named "SampleScene"
    }
}
