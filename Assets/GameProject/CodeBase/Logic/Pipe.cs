using UnityEngine;

namespace CodeBase.Logic
{
    public class Pipe : MonoBehaviour
    {
        private readonly float _maxYPosition = 3.9f;
        private readonly float _minYPosition = 0f;
        private readonly float _speed = 1.2f;
        private readonly float _percentOffset = 1f;

        private float _percentPosition;
        public float PercentPosition => _percentPosition;

        public void OnUp()
        {
            if (CheckMaxBorder())
                return;

            transform.position = MovePipe(transform.position, GetTargetPoint(_maxYPosition));
            CalculatePercent(out _percentPosition);
        }

        private void CalculatePercent(out float value) => 
            value = (transform.position.y * 100) / _maxYPosition + _percentOffset;

        public void OnDown()
        {
            if (CheckMinBorder())
                return;

            transform.position = MovePipe(transform.position, GetTargetPoint(_minYPosition));
            CalculatePercent(out _percentPosition);
        }

        private Vector3 GetTargetPoint(float offset) => 
            new Vector3(transform.position.x, offset, transform.position.z);

        private Vector3 MovePipe(Vector3 from, Vector3 to) => 
            Vector3.MoveTowards(from, to, _speed * Time.deltaTime);

        private bool CheckMinBorder() => 
            transform.position.y <= _minYPosition;

        private bool CheckMaxBorder() => 
            transform.position.y >= _maxYPosition;
    }
}