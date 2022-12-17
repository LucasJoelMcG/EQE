using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject characterNameBox;
    [SerializeField] private TMP_Text characterNameLabel;
    [SerializeField] private GameObject characterImage;
    [SerializeField] private DialogueObject testDialogue;

    private TypeWriterEffect typeWriterEffect;

    private void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        Time.timeScale = 0f;
        dialogueBox.SetActive(true);
        characterNameBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            characterNameLabel.text = dialogueObject.Name[System.Array.IndexOf(dialogueObject.Dialogue, dialogue)];
            characterImage.GetComponent<Image>().overrideSprite = dialogueObject.Image[System.Array.IndexOf(dialogueObject.Dialogue, dialogue)];
            yield return RunTypingEffect(dialogue);
            textLabel.text = dialogue;
            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        CloseDialogueBox();
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typeWriterEffect.Run(dialogue, textLabel);
        while (typeWriterEffect.IsRunning)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                typeWriterEffect.Stop();
            }
        }
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        characterNameBox.SetActive(false);
        characterNameLabel.text = string.Empty;
        Time.timeScale = 1f;
    }
}
