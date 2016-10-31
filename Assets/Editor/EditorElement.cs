using UnityEditor;

public abstract class EditorElement
{
    protected QuestionEditor parentWindow;
    
    public EditorElement(QuestionEditor parent)
    {
        parentWindow = parent;
    }
    public abstract void OnGUI();
}

