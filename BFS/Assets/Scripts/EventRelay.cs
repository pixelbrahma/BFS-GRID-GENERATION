/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EVENTTYPE
{
    ON_MOUSE_OVER,
    ON_MOUSE_EXIT,
    ON_MOUSE_DOWN
}

public class EventRelay{
    public delegate void OnEvent(EVENTTYPE type, System.Object data);
    public static event OnEvent OnEventAction;
    public static void RaiseEvent(EVENTTYPE type, System.Object data = null)
    {
        if(OnEventAction != null)
        {
            OnEventAction(type, data);
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
*/