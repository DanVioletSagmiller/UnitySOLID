using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Configuration", order = 0)]
public class GameConfig : ScriptableObject {

    public GameObject[] BallPrefabs;

    public Material[] Materials;

    public ReactorTypes[] Reactors;

    /// <summary>
    /// How long between each chain reaction
    /// </summary>
    public float TimeBetweenReactions = 0.2f;

    /// <summary>
    /// How much score for one ball
    /// </summary>
    public float ScorePerBall = 1;

    /// <summary>
    /// How much multiplier for each additional ball in the chain
    /// </summary>
    public float CountMultiplier = 2;

    /// <summary>
    /// How often does another ball drop.
    /// </summary>
    public float BallDropFrequency = 0.2f;

    /// <summary>
    /// How far from another ball to count as touching.
    /// </summary>
    public float BallTouchRange = 1.5f;

    public GameObject GetBallPrefab()
    {
        var index = Random.Range(
            0,
            BallPrefabs.Length);

        return BallPrefabs[index];
    }

    public Material GetMaterial()
    {
        var index = Random.Range(
            0,
            Materials.Length);

        return Materials[index];
    }

    public ReactorTypes GetReactor()
    {
        var index = Random.Range(
            0,
            Reactors.Length);

        return Reactors[index];
    }
}
