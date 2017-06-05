using IoC;
using UnityEngine;

namespace UnityBase
{
    public class InjectBehaviour : MonoBehaviour
    {
        /// <summary>
        /// Populates the object
        /// </summary>
        public InjectBehaviour()
        {
            Di.Inject(this);
        }

        public void Start()
        {
            Di.Inject(this, ignoreSetValues: true);
        }
    }
}
