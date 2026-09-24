using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private float moveSpeed = 2f;

    [Header("Camera")]
    [SerializeField] private Transform cameraPointB;
    [SerializeField] private Transform cameraPointC;
    [SerializeField] private float cameraMoveSpeed = 2f;

    [Header("Fade")]
    [SerializeField] private Image fadeImage;
    private float fadeDuration = 2f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (animator == null)
            Debug.LogError("No se encontró Animator en Player Cinematic.");

        if (spriteRenderer == null)
            Debug.LogError("No se encontró SpriteRenderer en Player Cinematic.");
    }

    private void Start()
    {
        Color color = fadeImage.color;
        color.a = 1f;
        fadeImage.color = color;
        Time.timeScale = 1f;

        StartCoroutine(Cinematic());
    }

    private IEnumerator Cinematic()
    {
        yield return StartCoroutine(
            MoveCameraAndFadeOut(cameraPointB.position)
        );
        yield return StartCoroutine(MoveTo(pointB.position));
        PlayAnimation("Idle");
        yield return new WaitForSeconds(3f);
        PlayAnimation("Attack");
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(
            MovePlayerAndCamera(pointC.position, cameraPointC.position)
        );
        PlayAnimation("Idle");
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(FadeIn());

        GoToCredits();
    }

    private IEnumerator MoveCameraAndFadeOut(Vector3 playerTarget)
    {
        Coroutine playerMove = StartCoroutine(MoveCameraTo(playerTarget));
        Coroutine fadeOut = StartCoroutine(FadeOut());

        yield return playerMove;
        yield return fadeOut;
    }

    private IEnumerator MovePlayerAndCamera(Vector3 playerTarget, Vector3 cameraTarget)
    {
        Coroutine playerMove = StartCoroutine(MoveTo(playerTarget));
        Coroutine cameraMove = StartCoroutine(MoveCameraTo(cameraTarget));

        yield return playerMove;
        yield return cameraMove;
    }

    private IEnumerator MoveTo(Vector3 target)
    {
        SetDirection(target);
        PlayAnimation("Run");

        while (Vector2.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        transform.position = target;

        PlayAnimation("Idle");
    }

    private void PlayAnimation(string animationName)
    {
        if (animator == null)
            return;

        animator.Play(animationName);
    }

    private void SetDirection(Vector3 target)
    {
        if (spriteRenderer == null)
            return;

        if (target.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (target.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }

    private IEnumerator MoveCameraTo(Vector3 target)
    {
        Camera mainCamera = Camera.main;

        while (Vector3.Distance(mainCamera.transform.position, target) > 0.05f)
        {
            mainCamera.transform.position = Vector3.MoveTowards(
                mainCamera.transform.position,
                target,
                cameraMoveSpeed * Time.deltaTime
            );

            yield return null;
        }

        mainCamera.transform.position = target;
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;

        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;

            color.a = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = color;

            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;

        Color color = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;

            color.a = 1f - Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = color;

            yield return null;
        }

        color.a = 0f;
        fadeImage.color = color;
    }

    public void GoToCredits()
    {
        Loader.Load(Loader.Scene.CreditsScene);
    }
}