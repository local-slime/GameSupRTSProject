using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class customEditor : EditorWindow
{
    [MenuItem(itemName: "Custom/customEditor", isValidateFunction: false, priority: 10)]
    public static void ShowExample()
    {
        customEditor wnd = GetWindow<customEditor>();
        wnd.titleContent = new GUIContent("customEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

    }
}
