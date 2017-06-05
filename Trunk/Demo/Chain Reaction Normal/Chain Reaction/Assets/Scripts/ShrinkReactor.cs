using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkReactor : Reactor
{

    private bool CountDownToDestroy = false;

    private bool Ending = false;

    private float CountDownTimer = 0;

    public float ShrinkTime = 1f;

    private float ShrinkBase = 0;

    public void Start()
    {

    }

    public override void ActivateDestructionIn(float time)
    {
        CountDownToDestroy = true;
        CountDownTimer = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CountDownToDestroy && !Ending) return;

        if (CountDownToDestroy)
        {
            CountDownTimer -= Time.deltaTime;
            if (CountDownTimer < 0)
            {
                CountDownToDestroy = false;
                Ending = true;
                ShrinkBase = 1 / ShrinkTime;
            }
        }

        if (Ending)
        {
            ShrinkTime -= Time.deltaTime;
            transform.localScale *= ShrinkBase * ShrinkTime;
            if (ShrinkTime < 0) Destroy(gameObject);
        }
    }
}
