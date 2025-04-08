using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace War_io.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovementController : MonoBehaviour
    {
        private static readonly float sqrEpsilon = Mathf.Epsilon * Mathf.Epsilon;

        [SerializeField]
        private float _speed = 10f;
        [SerializeField]
        private float _speedBoostCoefficient = 1.5f;
        [SerializeField]
        private float _maxRadiansDelta = 10f;

        public Vector3 MovemantDirection { get; set; }
        public Vector3 LookDirection { get; set; }


        private CharacterController _characterController;

        protected void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            Translate();

            if (_maxRadiansDelta > 0 && LookDirection != Vector3.zero)
                Rotate();
        }

        private void Translate()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                var delta = MovemantDirection * (_speed * _speedBoostCoefficient) * Time.deltaTime;
                _characterController.Move(delta);
            }
            else
            {
                var delta = MovemantDirection * _speed * Time.deltaTime;
                _characterController.Move(delta);
            }
        }

        private void Rotate()
        {
            var currentLookdirection = transform.rotation * Vector3.forward;
            float sqrMagnitude = (currentLookdirection - LookDirection).sqrMagnitude;

            if (sqrMagnitude > sqrEpsilon)
            {
                var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(LookDirection, Vector3.up), _maxRadiansDelta * Time.deltaTime);

                transform.rotation = newRotation;
            }
        }
    }
}