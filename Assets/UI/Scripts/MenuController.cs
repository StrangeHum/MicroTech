using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

public class MenuController : EditorWindow
{
    VisualElement container;
    [MenuItem("SHTool/UI/Test Window")]
    public static void ShowWindow()
    {
        MenuController window = GetWindow<MenuController>();
        window.titleContent = new GUIContent("Test");
    }

    public void CreateGUI()
    {
        container = rootVisualElement;

        VisualTreeAsset visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UI/StarMenu.uxml");
        container.Add(visualTreeAsset.Instantiate());

        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UI/menu.uss");
        container.styleSheets.Add(styleSheet);
    }
}
