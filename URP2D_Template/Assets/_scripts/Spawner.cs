using System.Collections.Generic;
using UnityEngine;

namespace icat.sarbajit
{
    [System.Serializable]
    public class SpawnableItem
    {
        public string name;
        public int numberToSpawn;
        public float spawnInterval;
        public GameObject _object;
    }
    public class Spawner : SystemControllerBase
    {
        [SerializeField] private List<SpawnableItem> _objectsToSpawn;
        [SerializeField] private bool _active, _canSpawn;
        [SerializeField] private int _index;
        protected override void Configure()
        {
            if (_objectsToSpawn.Count > 0)
            {
                _canSpawn = true;
            }
        }

        protected override void Setup()
        {
            _updateCycles = 10;
            _updateInterval = 0.5f;
        }

        protected override void CustomUpdateLoop()
        {
            if (_canSpawn)
            {
                _active = true;
                _index++;
                var g = Instantiate(_objectsToSpawn[_index % _objectsToSpawn.Count]._object);
                _active = false;
            }
        }
    }
}
