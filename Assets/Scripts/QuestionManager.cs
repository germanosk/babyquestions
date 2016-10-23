using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour {
    public AudioInfo question;
    public List<AudioInfo> answers;
    private AudioSource questionSource;
    private AudioSource answerSource;
    private int correctAnswerIndex;

    public List<AnswerButton> buttons;
    public Text questionText;

    public GameObject resultCanvas;
    public Text resultText;
    public AudioInfo resultSuccess;
    public AudioInfo resultFailure;
    public Text againButtonText;
    public AudioInfo again;

    void Start ()
    {
        questionSource = gameObject.AddComponent<AudioSource>();
        answerSource = gameObject.AddComponent<AudioSource>();
        SetQuestion();
	}

    private void SortAnswer()
    {
        ShuffleButtons();
        correctAnswerIndex = Random.Range(0, answers.Count);
        SetupAnswerButton(buttons[0], correctAnswerIndex);
        for(int i =1; i < buttons.Count; i++)
        {
            SetupAnswerButton(buttons[i], OtherAnswer());
        }
    }

    private int OtherAnswer()
    {
        int result = Random.Range(0, answers.Count);
        while(result == correctAnswerIndex)
        {
            result = Random.Range(0, answers.Count);
        }
        return result;
    }

    private void SetQuestion()
    {
        SortAnswer();
        questionText.text = question.text;
        PlayQuestion();
    }

    public void PlayQuestion()
    {
        questionSource.clip = question.audio;
        questionSource.Play();
        answerSource.clip = answers[correctAnswerIndex].audio;
        answerSource.PlayDelayed(question.audio.length);
    }

    private void SetupAnswerButton(AnswerButton button,int index)
    {
        button.SetAnswer(answers[index], delegate { AnswerQuestion(button, index); });
    }

    private void ShuffleButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = Random.Range(0, buttons.Count);
            AnswerButton temp = buttons[i];
            buttons[i] = buttons[index];
            buttons[index] = temp;
        }
    }

    public void AnswerQuestion(AnswerButton button, int indexQuestion)
    {
        button.MarkAsSuccess(indexQuestion == correctAnswerIndex);

        if (indexQuestion == correctAnswerIndex)
        {
            answerSource.clip = resultSuccess.audio;
            resultText.text = resultSuccess.text;
        }
        else
        {
            answerSource.clip = resultFailure.audio;
            resultText.text = resultFailure.text;
        }
        resultCanvas.SetActive(true);
        againButtonText.text = again.text;
        answerSource.Play();
    }

    public void PlayAgain()
    {
        answerSource.clip = again.audio;
        answerSource.Play();
        resultCanvas.SetActive(false);
        SetQuestion();
    }
}
