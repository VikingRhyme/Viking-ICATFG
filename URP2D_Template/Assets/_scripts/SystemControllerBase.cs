using System.Collections;
using UnityEngine;

namespace icat.sarbajit
{
    public abstract class SystemControllerBase : MonoBehaviour
    {
        [SerializeField]
        protected bool _configured = false, _updating = false;
        [SerializeField]
        protected float _updateInterval;
        [SerializeField]
        protected int _updateCycles;
        private void Awake()
        {
            Setup();
            Configure();
        }

        protected virtual IEnumerator Start()
        {
            for (int i = 0; i < _updateCycles; i++)
            {
                CustomUpdateLoop();
                yield return new WaitForSeconds(_updateInterval);
            }
        }

        protected abstract void Setup();

        protected abstract void Configure();

        protected virtual void CustomUpdateLoop()
        {

        }

        private void OnValidate()
        {
            if (!_configured)
            {
                Setup();
                Configure();
                _configured = true;
            }
        }
    }
}
