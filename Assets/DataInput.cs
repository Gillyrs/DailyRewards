using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInput : MonoBehaviour, IDataInput
{
    public virtual bool GetDataInput(out DateTime? result)
    {
        throw new NotImplementedException();
    }
}
