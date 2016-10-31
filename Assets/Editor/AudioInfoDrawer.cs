using UnityEditor;
using UnityEngine;

public class AudioInfoDrawer
{
    public static void Draw(ref AudioInfo info)
    {
        info.text = EditorGUILayout.TextField("Text", info.text);
        info.audio = (AudioClip)EditorGUILayout.ObjectField("Audio", info.audio, typeof(AudioClip), false);
    }

    public static void Draw(ref SerializedProperty info, Rect rect)
    {
        Rect textLabelRect = new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight);
        Rect textRect = new Rect(rect.x + 60, rect.y, rect.width-60, EditorGUIUtility.singleLineHeight);

        Rect audioLabelRect = new Rect(rect.x, rect.y+ EditorGUIUtility.singleLineHeight, 60, EditorGUIUtility.singleLineHeight);
        Rect audioRect = new Rect(rect.x, rect.y+ EditorGUIUtility.singleLineHeight, rect.width - 60, EditorGUIUtility.singleLineHeight);
        GUI.Label(textLabelRect, "Text");
        EditorGUI.PropertyField(textRect,info.FindPropertyRelative("text"), GUIContent.none);
        //info.text = GUI.TextField(textRect, info.text);
        GUI.Label(audioLabelRect, "Audio");
        EditorGUI.PropertyField(audioRect, info.FindPropertyRelative("audio"), GUIContent.none);
        //info.audio = (AudioClip)GUI.ObjectField(audioRect, info.audio, typeof(AudioClip), false);
    }
}

