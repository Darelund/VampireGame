using UnityEngine;

public class CrawlingMovement : Moveable
{
    private float crawlTimer = 0.2f;
    private float timeSinceLastCrawl;
    protected override void Move(GameObject gameObject)
    {
        //timeSinceLastCrawl += Time.deltaTime;
        //if(timeSinceLastCrawl > crawlTimer)
        //{
        //    timeSinceLastCrawl = 0;
        //}
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, (speed * 0.6f) * Time.deltaTime);
    }
}
