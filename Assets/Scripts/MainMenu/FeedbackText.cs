using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TextType
{
    Normal,
    LvlUp
}
public class FeedbackText : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public TextType TextType;


    
    public void Initialize(string text)
    {
        this.text.text = text;
        StartCoroutine(nameof(TextCoroutine));
    }
    public void Initialize(string text, Color newColor)
    {
        this.text.text = text;
        this.text.color = newColor;
        StartCoroutine(nameof(TextCoroutine));
    }
    private IEnumerator TextCoroutine()
    {
        //yield return SizeUp();
        //yield return SizeDown();

        //yield return TextSizeChange(text.fontSize * 2, (fs1, fs2) => fs1 < fs2, 1.5f);
        //yield return TextSizeChange(text.fontSize / 2, (fs1, fs2) => fs1 > fs2, -10f);

        Vector2 doubleScale = new Vector2(text.transform.localScale.x * 2, text.transform.localScale.y * 2);
        yield return TextScaleChange(doubleScale, (fs1, fs2) => fs1.sqrMagnitude < fs2.sqrMagnitude, 1.5f);

        Vector2 halfScale = new Vector2(text.transform.localScale.x * 0.5f, text.transform.localScale.y * 0.5f);
        yield return TextScaleChange(halfScale, (fs1, fs2) => fs1.sqrMagnitude > fs2.sqrMagnitude, 10f);

        Destroy(gameObject);
    }
    private IEnumerator TextScaleChange(Vector2 trgLocalScale, Func<Vector2, Vector2, bool> comparison, float speed)
    {
        Vector2 targetScale = trgLocalScale;
        while (comparison.Invoke(text.transform.localScale, targetScale))
        {
            text.transform.localScale = Vector2.MoveTowards(text.transform.localScale, targetScale, Time.deltaTime * speed);
            yield return null;
        }
    }
    private IEnumerator TextSizeChange(float trgSize, Func<float, float, bool> comparison, float speed)
    {
        float targetSize = trgSize;
        while (comparison.Invoke(text.fontSize, targetSize))
        {
            text.fontSize += Time.deltaTime * speed;
            yield return null;
        }
    }
    //private IEnumerator SizeUp()
    //{
    //    //float currentSize = text.fontSize;
    //    float targetSize = text.fontSize * 2;

    //    while (text.fontSize < targetSize)
    //    {
    //        text.fontSize += Time.deltaTime * 1.3f;
    //        yield return null;
    //    }
    //}
    //private IEnumerator SizeDown()
    //{
    //    //float currentSize = text.fontSize;
    //    float targetSize = text.fontSize / 2;

    //    while (text.fontSize > targetSize)
    //    {
    //        text.fontSize -= Time.deltaTime * 1.8f;
    //        yield return null;
    //    }
    //}
}
