using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RecieveElement : MonoBehaviour
{
    public UnityEvent OnEnableStateSet;
    public UnityEvent OnDisableStateSet;
    public virtual void SetEnableState() { OnEnableStateSet.Invoke(); }
    public virtual void SetDisableState() { OnDisableStateSet.Invoke(); }
}
