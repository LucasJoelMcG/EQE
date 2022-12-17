using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] public float typewriterSpeed = 50f;
    public bool IsRunning { get; private set; }
    private readonly Dictionary<HashSet<char>, float> punctuations = new Dictionary<HashSet<char>, float>()
    {
        {new HashSet<char>(){'.', '!', '?'}, 0.6f},
        {new HashSet<char>(){',', ';', ':'}, 0.3f},
    };

    private Coroutine typingCoroutine;

    public void Run(string textToType, TMP_Text textLabel)
    {
        typingCoroutine = StartCoroutine(TypeText(textToType, textLabel));
    }

    public void Stop()
    {
        StopCoroutine(typingCoroutine);
        IsRunning = false;
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        IsRunning = true;
        textLabel.text = string.Empty;
        float time = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            int lastCharIndex = charIndex;
            time += Time.unscaledDeltaTime * typewriterSpeed;
            charIndex = Mathf.FloorToInt(time);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            for (int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i > textToType.Length - 1;
                textLabel.text = textToType.Substring(0, i + 1);
                if (isPunctuation(textToType[i], out float waitTime) && !isLast && !isPunctuation(textToType[i + 1], out _))
                {
                    yield return new WaitForSecondsRealtime(waitTime);
                }
            }

            yield return null;
        }
        IsRunning = false;
        textLabel.text = textToType;
    }

    private bool isPunctuation(char character, out float waitTime)
    {
        foreach (KeyValuePair<HashSet<char>, float> punctuationCategory in punctuations)
        {
            if (punctuationCategory.Key.Contains(character))
            {
                waitTime = punctuationCategory.Value;
                return true;
            }
        }

        waitTime = default;
        return false;
    }
}
