using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsItem : MonoBehaviour //Persistent
{
    private float itemWidth;
    private float pixelsPerSecond;
    private RectTransform rt;

    public float getXPos() //return anchored x position
    {
        return rt.anchoredPosition.x;
    }

    public float getWidth()
    {
        return rt.rect.width;
    }

    public void Initialize(float itemWidth, float pixelsPerSecond, string message)
    {
        this.itemWidth = itemWidth;
        this.pixelsPerSecond = pixelsPerSecond;
        rt = GetComponent<RectTransform>();
        GetComponent<TextMeshProUGUI>().text = message;
    }

    // Update is called once per frame
    void Update()
    {
        rt.position += Vector3.left * pixelsPerSecond * Time.deltaTime;
        if(getXPos() <= 0 - itemWidth - getWidth())
        {
            Destroy(gameObject);
        }
    }
}
