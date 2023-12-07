using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomDigit : MonoBehaviour
{
    public Text digitText;                      //  the Text component for displaying the current digit
    public GameObject maskedCircle;             //  the GameObject representing the masked circle

    private int currentDigit;                   // Stores the current random digit
    public static int currentScore = 0;         // Stores the current score
    private float toggleInterval = 1.0f;       // Time interval to toggle the digit visibility
    private float toggleTimer = 0f;           // Timer to keep track of the toggle interval
    private float maskedCircleDelay = 2.0f;  // Delay for showing/hiding the masked circle
    private float maskedCircleTimer = 0f;   // Timer to keep track of the masked circle delay
    private bool isDigitHidden = false;      // Flag to determine if the digit is currently hidden or not

    private void Start()
    {
        // Invoke the GenerateRandomDigit method repeatedly with an initial delay of 0.5 seconds and a repeat interval of 2 seconds
        InvokeRepeating("GenerateRandomDigit", 0.5f,2.0f);
    }

    private void Update()
    {
        toggleTimer += Time.deltaTime;          // Increment the toggle timer based on the elapsed time

        if (toggleTimer >= toggleInterval)
        {
            ToggleDigitVisibility();          // Toggle the visibility of the digit and the masked circle
            toggleTimer = 0f;                 // Reset the toggle timer
        }

        if (isDigitHidden)
        {
            maskedCircleTimer += Time.deltaTime;     // Increment the timer for showing the masked circle

            if (maskedCircleTimer >= maskedCircleDelay)
            {
                ShowMaskedCircle();             // Show the masked circle and hide the digit
                maskedCircleTimer = 0f;         // Reset the masked circle timer
            }
        }
        else
        {
            maskedCircleTimer += Time.deltaTime; // Increment the timer for hiding the digit

            if (maskedCircleTimer >= maskedCircleDelay)
            {
                HideDigit();               // Hide the digit and show the masked circle
                maskedCircleTimer = 0f;    // Reset the masked circle timer
            }
        }

        if (!isDigitHidden && Input.GetKeyDown(KeyCode.Space))
        {
            if (currentDigit == 3)
            {
                SceneManager.LoadScene("endScene");   // Load the "endScene" if the current digit is 3
            }
            else
            {
                currentScore += 1;                   // Increment the score if the current digit is not 3
            }
        }
    }

    private void GenerateRandomDigit()
    {
        currentDigit = Random.Range(1, 10);                               // Generate a random digit between 1 and 9 (inclusive)
        digitText.text = currentDigit.ToString();                          // Display the current digit in the digitText component
        ToggleDigitVisibility();                                           // Toggle the visibility of the digit and the masked circle
    }  

    private void ToggleDigitVisibility()
    {
        digitText.gameObject.SetActive(!digitText.gameObject.activeSelf);         // Toggle the visibility of the digit
        isDigitHidden = !digitText.gameObject.activeSelf;                         // Update the flag to reflect the current digit visibility
        maskedCircle.SetActive(isDigitHidden);                                    // Show/hide the masked circle based on the digit visibility
        maskedCircleTimer = 0f;                                                     // Reset the masked circle timer
    }

    private void HideDigit()
    {
        digitText.gameObject.SetActive(false);                                     // Hide the digit
        isDigitHidden = true;                                                      // Update the flag to indicate that the digit is hidden
        maskedCircle.SetActive(true);                                              // Show the masked circle
        maskedCircleTimer = 0f;                                                    // Reset the masked circle timer
    }

    private void ShowMaskedCircle()
    {
        maskedCircle.SetActive(false);                                            // Hide the masked circle
        isDigitHidden = false;                                                   // Update the flag to indicate that the digit is visible
        digitText.gameObject.SetActive(true);                                   // Show the digit
    }
}