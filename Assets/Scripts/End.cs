using System.Collections;
using UnityEngine;

public class End : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject canvasObject;
    public CanvasGroup textTheEnd;    // Arrastra aquí TheEnd
    public CanvasGroup textQuestion;  // Arrastra aquí Question

    [Header("Timings")]
    public float delayBeforeFade = 5f;
    public float fadeDuration = 1.5f;
    public float delayBetweenTexts = 2f; // Tiempo de espera entre los dos textos

    void Start()
    {
        // Apagamos todo al inicio
        if (canvasObject != null) canvasObject.SetActive(false);
        if (textTheEnd != null) textTheEnd.alpha = 0f;
        if (textQuestion != null) textQuestion.alpha = 0f;
    }

    // ESTE ES EL MÉTODO QUE LLAMAREMOS
    public void OnAnimationFinished()
    {
        if (canvasObject != null) canvasObject.SetActive(true);
        StartCoroutine(WaitAndFadeText());
    }

    private IEnumerator WaitAndFadeText()
    {
        // 1. Esperar 5 segundos
        yield return new WaitForSeconds(delayBeforeFade);

        // 2. Aparece "The End" suavemente
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textTheEnd.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            yield return null;
        }
        textTheEnd.alpha = 1f;

        // 3. Pausa dramática entre textos
        yield return new WaitForSeconds(delayBetweenTexts);

        // 4. Aparece "Question" suavemente
        elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textQuestion.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            yield return null;
        }
        textQuestion.alpha = 1f;
    }
}