using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour {


    public Material Material { get; set; }

    public void StartReaction()
    {
        var game = Game.Current;
        var config = game.Configuration;
        var all = new List<Ball>(game.BallCollection.Where(x => x.Material == this.Material));
        var consumables = new List<Ball>();
        var consumed = new List<Ball>();
        consumables.Add(this);
        all.Remove(this);

        while(consumables.Count > 0)
        {
            var tester = consumables[0];
            consumables.RemoveAt(0);
            consumed.Add(tester);
            for(int i = all.Count - 1; i > -1; i--)
            {  
                var ball = all[i];
                var distance = Vector3.Distance(tester.transform.position, ball.transform.position);
                if (distance > config.BallTouchRange) continue;

                consumables.Add(ball);
                all.Remove(ball);
            }
        }

        var score = 0f;
        var triggerIn = 0f;
        var reactorChoice = game.Configuration.GetReactor();
        Reactor reactor = null;
        foreach(var ball in consumed)
        {
            if (reactorChoice == ReactorTypes.Fade) reactor = ball.GetComponent<FadeReactor>();
            if (reactorChoice == ReactorTypes.Shrink) reactor = ball.GetComponent<ShrinkReactor>();
            if (reactorChoice == ReactorTypes.Slip) reactor = ball.GetComponent<SlipReactor>();

            reactor.ActivateDestructionIn(triggerIn);
            triggerIn += config.TimeBetweenReactions;

            score += config.ScorePerBall;
            score *= config.CountMultiplier;

            Score.Current.TotalScore += (int)score;
        }
    }

	// Use this for initialization
	void Start ()
    {
        var game = Game.Current;
        game.BallCollection.Add(this);
        Material = game.Configuration.GetMaterial();
        GetComponent<Renderer>().material = Material;
	}

    private void OnDestroy()
    {
        Game.Current.BallCollection.Remove(this);
    }
}
