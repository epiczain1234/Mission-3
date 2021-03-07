using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    // Start is called before the first frame
    float currentTime;
    float startingTime = 30f;
    [SerializeField] Text countdownText;
    void Start()
    {
       currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
       currentTime -= 1 * Time.deltaTime;
       countdownText.text = currentTime.ToString();
       if (0 >= currentTime){
         SceneManager.LoadScene("WinScene");
       }
    }
}
