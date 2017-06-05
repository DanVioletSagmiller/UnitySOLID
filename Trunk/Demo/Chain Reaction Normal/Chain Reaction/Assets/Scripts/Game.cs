using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public GameConfig Configuration;

    public static Game Current { get; set; }

    public Transform[] BallDropLocations;

    [HideInInspector]
    public List<Ball> BallCollection = new List<Ball>();

    /// <summary>
    /// when @0, ball drops, resets to ball drop frequency.
    /// </summary>
    private float DropCounter = 0;

	void Start () {
        Current = this;
	}
	
	// Update is called once per frame
	void Update () {
        DropCounter -= Time.deltaTime;
        if (DropCounter > 0) return;

        DropCounter = Configuration.BallDropFrequency;

        var dropPrefab = Configuration.GetBallPrefab();
        var dropLocation = GetBallDropLocation();

        var ball = GameObject.Instantiate<GameObject>(
            dropPrefab, 
            dropLocation.position,
            Quaternion.identity);

	}

    private Transform GetBallDropLocation()
    {
        var index = Random.Range(
            0,
            BallDropLocations.Length);

        return BallDropLocations[index];
    }
}
