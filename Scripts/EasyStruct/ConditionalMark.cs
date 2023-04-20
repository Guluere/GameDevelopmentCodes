using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ApplyStringValueKey : MonoBehaviour
{
    List<ReturnStringValue> StringValues = new List<ReturnStringValue>();
}

public class ReturnStringValue : MonoBehaviour
{
    public virtual string ReturnString()
    {
        return "0";
    }
}

public class ConditionalMark : ReturnStringValue
{
    private int ConditionCount;
    public int ConditionLimit;
    public UnityEvent EqualsTo;
    public UnityEvent MoreThan;
    public UnityEvent MoreThanEquals;
    public UnityEvent LessThan;
    public UnityEvent LessThanEquals;

    public override string ReturnString()
    {
        return "" + ConditionCount;
    }

    public void ChangeCountBy(int Change) { ConditionCount += Change; }
    public void ChangeCountTo(int Change) { ConditionCount = Change; }

    public void InvokeEqualsTo()
    {
        if (ConditionCount == ConditionLimit) { EqualsTo.Invoke(); }
    }
    public void InvokeMoreThan()
    {
        if(ConditionCount > ConditionLimit) { MoreThan.Invoke(); }
    }
    public void InvokeMoreThanEquals()
    {
        if (ConditionCount >= ConditionLimit) { MoreThanEquals.Invoke(); }
    }
    public void InvokeLessThan()
    {
        if (ConditionCount < ConditionLimit) { LessThan.Invoke(); }
    }
    public void InvokeLessThanEquals()
    {
        if (ConditionCount <= ConditionLimit) { LessThanEquals.Invoke(); }
    }
}
