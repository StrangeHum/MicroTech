using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;
public class GameUI : MonoBehaviour
{
    VisualElement visualElement;
    [SerializeField] VisualTreeAsset VisualTreeAsset;

    void Start()
    {
        visualElement = GetComponent<UIDocument>().rootVisualElement;
        Button start_button = visualElement.Q<Button>("start-button");
        Button setings_button = visualElement.Q<Button>("setings-button");
        Button exit_button = visualElement.Q<Button>("exit-button");
        //var t = visualElement.Q<VisualElement>("lvl-icons");
        //t.Add(VisualTreeAsset.Instantiate());


        start_button.clicked += StartGame;
    }

    private void StartGame()
    {
        SceneManager.LoadScene("TestStand");
    }
    private void Setings()
    {

    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
