using UnityEngine;

namespace CodeBase.Logic
{
    public class PercentHandler : MonoBehaviour
    {
        private const string TankTag = "Tank";
        
        [SerializeField] private GameObject _percentPanel;

        private Ray _rayCast;
        private RaycastHit _hit;

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            
            _rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(_rayCast, out _hit)) return;
            
            if (_hit.collider.CompareTag(TankTag) && _hit.collider.GetComponent<PercentHandler>() == this)
                PercentController();
        }

        private void PercentController()
        {
            if (_percentPanel.activeInHierarchy)
                PercentValueOff();
            else
                PercentValueOn();
        }

        private void PercentValueOn() =>
            _percentPanel.SetActive(true);

        private void PercentValueOff() =>
            _percentPanel.SetActive(false);
    }
}