using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public BigRedButton[] buttons;
    public bool sequential = false;
    
    public bool Triggered { get; set; }

    void Update()
    {
        bool _triggered = false;

        // TODO: handle sequences

        foreach (var button in buttons)
        {
            _triggered = button.engaged;
            if (!_triggered) break;
        }

        Triggered = _triggered;
    }
}
