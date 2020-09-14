using UnityEngine;

[CreateAssetMenu]

public class Vector3Data : ScriptableObject
{
    public Vector3 value;

    public void SetValueFromTransform(Vecotr3 obj)
    {
        value = obj;
    }

}