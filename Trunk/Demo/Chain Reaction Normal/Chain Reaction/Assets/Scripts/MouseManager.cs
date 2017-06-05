using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            var didHit = Physics.Raycast(ray, out hit);

            if (didHit)
            {
                var ball = hit.collider.gameObject.GetComponent<Ball>();
                if (ball == null)
                {
                    return;
                }

                ball.StartReaction();
            }
        }
    }
}
