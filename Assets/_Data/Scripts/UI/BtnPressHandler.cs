using UnityEngine;
using UnityEngine.EventSystems;
using System;

/// <summary> Delay khi an </summary>
public class BtnPressHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action OnButtonDown;
    public event Action OnButtonUp;
    public event Action OnButtonHolding;


    [SerializeField] bool _isHolding = false;
    [SerializeField] float _timeDelayDefault = 0.7f;
    [SerializeField] float _timeDelay;

    private void OnEnable()
    {
        _isHolding = false;
    }
 
    private void FixedUpdate()
    {
        // countDown 
        if (_isHolding) _timeDelay -= Time.fixedDeltaTime;
        else _timeDelay = _timeDelayDefault;

        if (_timeDelay <= 0)
        {
            OnButtonHolding?.Invoke();
        }
    } 

    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonDown?.Invoke();
        _isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnButtonUp?.Invoke();
        _isHolding = false;
        _timeDelay = _timeDelayDefault;
    }
}
