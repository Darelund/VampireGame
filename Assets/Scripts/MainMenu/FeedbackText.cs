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

        yield return SizeChange(text.fontSize * 2, (fs1, fs2) => fs1 < fs2, Time.deltaTime * 1.5f);
        yield return SizeChange(text.fontSize / 2, (fs1, fs2) => fs1 > fs2, -(Time.deltaTime * 2f));

        Destroy(gameObject);
    }
    private IEnumerator SizeChange(float trgSize, Func<float, float, bool> comparison, float speed)
    {
        float targetSize = trgSize;
        while (comparison.Invoke(text.fontSize, targetSize))
        {
            text.fontSize += speed;
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
