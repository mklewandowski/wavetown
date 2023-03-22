using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float maxX;
    public float minX;
    public float offsetX;
    private bool movingLeft = false;
    public float moveSpeedMin = .25f;
    public float moveSpeedMax = 1f;
    public float moveSpeed = .75f;
    public bool moveOn = false;
    public bool flip = false;

    // Use this for initialization
    void Start () {
        if (maxX == 0 && minX == 0)
        {
            maxX = this.transform.localPosition.x + offsetX;
            minX = this.transform.localPosition.x - offsetX;
        }
        if (moveSpeedMin != moveSpeedMax)
        {
            moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
        }
    }

    // Update is called once per frame
    void Update () {
        if (moveOn)
        {
            if (movingLeft)
            {
                Vector3 newpos = this.transform.localPosition;
                newpos.x = Mathf.Max (minX, newpos.x - moveSpeed * Time.deltaTime);
                this.transform.localPosition = newpos;
                if (newpos.x == minX)
                {
                    movingLeft = false;
                    this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
                }
            }
            else
            {
                Vector3 newpos = this.transform.localPosition;
                newpos.x = Mathf.Min (maxX, newpos.x + moveSpeed * Time.deltaTime);
                this.transform.localPosition = newpos;
                if (newpos.x == maxX)
                {
                    movingLeft = true;
                    this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x) * -1f, this.transform.localScale.y, this.transform.localScale.z);
                }
            }
        }
    }

    public void StartEffect()
    {
        moveOn = true;
    }
}
