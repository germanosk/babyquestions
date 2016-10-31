using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEditorInternal;

public class QuestionElement : EditorElement
{

    QuestionScriptableObject question;
    SerializedObject serializedQuestion;


    ReorderableList answersReorderableList;

    public QuestionElement(QuestionEditor parent) : base(parent)
    {
        question = ScriptableObject.CreateInstance<QuestionScriptableObject>();
        serializedQuestion = new UnityEditor.SerializedObject(question);
        
        SetupReordableAnswersList();
    }

    public override void OnGUI()
    {
        EditorGUILayout.LabelField("Question", EditorStyles.boldLabel);
        
        AudioInfoDrawer.Draw(ref question.question);
        answersReorderableList.DoLayoutList();
    }

    private void SetupReordableAnswersList()
    {
        
        answersReorderableList = new ReorderableList(serializedQuestion, serializedQuestion.FindProperty("answers"),  true, true, true, true);
        answersReorderableList.elementHeight = EditorGUIUtility.singleLineHeight * 2f;
        answersReorderableList.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Answers");
        };
        answersReorderableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
            var element = answersReorderableList.serializedProperty.GetArrayElementAtIndex(index);
            rect.height = EditorGUIUtility.singleLineHeight *2;
            AudioInfoDrawer.Draw(ref element, rect);
            rect.y += EditorGUIUtility.singleLineHeight * 2;
        };
        answersReorderableList.onAddCallback = (ReorderableList l) => {
            var index = l.serializedProperty.arraySize;
            l.serializedProperty.arraySize++;
            l.index = index;
            var element = l.serializedProperty.GetArrayElementAtIndex(index);
            element.FindPropertyRelative("text").stringValue = "";
            element.FindPropertyRelative("audio").objectReferenceValue = null;
        };


    }
}

