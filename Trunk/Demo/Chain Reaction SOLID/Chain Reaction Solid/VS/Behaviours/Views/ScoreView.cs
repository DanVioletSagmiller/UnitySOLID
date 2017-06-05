using IoC;
using Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityBase;
using UnityEngine.UI;

namespace Behaviours.Views
{
    public class Score : InjectBehaviour, IScore
    {

        public Text DisplayCaption;
        
        public int TotalScore { get; set; }

        public Score()
        {
            Di.Bind<IScore>().AsSingleton(this);
        }

        public void Update()
        {
            DisplayCaption.text = "Score: " + TotalScore;
        }
    }
}
