using UnityEditor;
using System.Collections;

public class QuestionEditor : EditorWindow {

    static EditorElement element ;

    [MenuItem("Baby Questions/Questions Creator")]
    static void Init()
    {
        QuestionEditor window = (QuestionEditor)EditorWindow.GetWindow(typeof(QuestionEditor));
        element = new MainElement(window);
        window.Show();
    }

    void OnGUI()
    {
        element.OnGUI();
    }

    public void ClearIGUI()
    {
        element = new MainElement(this);
    }

    public void SetElement(EditorElement target)
    {
        element = target;
    }
}
