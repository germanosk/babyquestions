using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnswerButton : MonoBehaviour {
    public Text textAnswer;
    public AudioSource sourceAnswer;
    public Button buttonAnswer;
    
    public void SetAnswer(AudioInfo info, UnityAction action)
    {
        if(sourceAnswer == null)
        {
            sourceAnswer = gameObject.AddComponent<AudioSource>();
        }
        if(buttonAnswer == null)
        {
            buttonAnswer = GetComponent<Button>();
        }
        textAnswer.text = info.text;
        sourceAnswer.clip = info.audio;
        buttonAnswer.onClick.RemoveAllListeners();
        buttonAnswer.onClick.AddListener(delegate { sourceAnswer.Play(); });
        buttonAnswer.onClick.AddListener(action);
    }

    public void MarkAsSuccess(bool wasSuccess)
    {

    }
}
