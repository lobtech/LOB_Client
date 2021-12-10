using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSenceManager : MonoBehaviour
{
    public GameObject image;   //Load the interface
    public Slider slider;   //progress bar
    public Text text;      //Loading progress text
    public void LoadNextLeaver()
    {
        image.SetActive(true);
        StartCoroutine(LoadLeaver());
    }
    IEnumerator LoadLeaver()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Demo1"); //Gets the current scene and adds one
                                                                         //operation.allowSceneActivation = false;
        while (!operation.isDone)   //When the scene is not loaded
        {
            slider.value = operation.progress;  //The progress bar corresponds to the scene loading progress
            text.text = (operation.progress * 100).ToString() + "%";
            yield return null;
        }
    }
}
