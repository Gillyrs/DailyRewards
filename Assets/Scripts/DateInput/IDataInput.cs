using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IDataInput
{
    bool GetDataInput(out DateTime? result);
}
