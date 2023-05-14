using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HandDataInput : DataInput
{
    [SerializeField] private InputField inputField;
    public override bool GetDataInput(out DateTime? input)
    {
        if (inputField.text == null)
        {
            input = null;
            return false;
        }
        if (!DateTime.TryParse(inputField.text, out DateTime result))
        {
            input = null;
            return false;
        }
        input = result;
        return true;
    }
}
