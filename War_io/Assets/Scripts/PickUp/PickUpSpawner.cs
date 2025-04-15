using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace War_io.PickUp
{
    public class PickUpSpawner : MonoBehaviour
    {
        [SerializeField]
        private PickUpItem[] Prefabs;

        [SerializeField]
        private float _range = 5f;

        [SerializeField]
        private int _maxCount = 3;

        [SerializeField]
        private float _minSpawnIntervalSec = 3f;
        [SerializeField]
        private float _maxSpawnIntervalSec = 10f;

        private float _currentSpawnTimerSec = 0;
        private int _currentCount = 0;
        private float _spawnIntervalSec;


        void Start ()
        {
            _spawnIntervalSec = Random.Range(_minSpawnIntervalSec, _maxSpawnIntervalSec);
        }
        void Update()
        {
            if(_currentCount < _maxCount)
            {
                _currentSpawnTimerSec += Time.deltaTime;
                if (_currentSpawnTimerSec >= _spawnIntervalSec)
                {
                    _currentSpawnTimerSec = 0;
                    _spawnIntervalSec = Random.Range(_minSpawnIntervalSec, _maxSpawnIntervalSec);
                    _currentCount += 1;

                    var randomPointInRange = Random.insideUnitCircle * _range;  
                    var randomPosition = new Vector3(randomPointInRange.x, 0, randomPointInRange.y) + transform.position;
                    var item = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], randomPosition, Quaternion.identity, transform);
                    item.PickedUp += OnItemPickedUp;
                }
            }
        }

        private void OnItemPickedUp(PickUpItem item)
        {
            _currentCount -= 1;
            item.PickedUp -= OnItemPickedUp;
        }

        protected void OnDrawGizmos()
        {
            var cashedColor = Handles.color;
            Handles.color = Color.green;
            Handles.DrawWireDisc(transform.position, Vector3.up, _range);
            Handles.color = cashedColor;
        }
    }
}