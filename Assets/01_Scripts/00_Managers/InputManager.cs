using System;
using UnityEngine;

public class InputManager
{
    public Action<Define.MouseEvent> MouseAction = null;

    bool _pressed = false;

    public void OnUpdate()
    {
        if (!Input.anyKey) return;


        if (Input.GetMouseButton(0))
        {
            MouseAction.Invoke(Define.MouseEvent.Press);
            _pressed = true;
        }
        else
        {
            if (_pressed)
            {
                MouseAction.Invoke(Define.MouseEvent.Click);
                _pressed = false;
            }
        }
    }
}
