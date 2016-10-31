using UnityEditor;
using UnityEngine;

public class MainElement : EditorElement
{
    public MainElement(QuestionEditor parent) : base(parent)
    {

    }
    
    public override void OnGUI()
    {
        if (GUILayout.Button("New Questions"))
        {
            parentWindow.SetElement(new QuestionElement(parentWindow));
        }
        if (GUILayout.Button("Edit Questions"))
        {
            parentWindow.SetElement(new BlankElement());
        }
    }
}

