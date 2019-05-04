using System.Collections.Generic;
using UnityEngine;

public class NewsTicker : MonoBehaviour //Persistent
{
    public NewsItem newsItem_prefab; //The news text prefab
    [Range(0, 10)] public float itemDuration; //How long to scroll the news
    public List<string> fillerItems; //News that will loop if there is no important news to show

    private float width;
    private float pixelsPerSecond; //to calculate the speed in which the whole news scrolls
    private NewsItem currentItem;

    // Start is called before the first frame update
    private void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        pixelsPerSecond = width / itemDuration;
        AddNewsItem(fillerItems[Random.Range(0, fillerItems.Count)]);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!currentItem)
        {
            AddNewsItem(fillerItems[Random.Range(0, fillerItems.Count)]);
        }
    }

    private void AddNewsItem(string message)
    {
        currentItem = Instantiate(newsItem_prefab, transform);
        currentItem.Initialize(width, pixelsPerSecond, message);
        currentItem.transform.SetAsFirstSibling();
    }
}