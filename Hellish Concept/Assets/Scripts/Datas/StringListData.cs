using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class StringListData : ScriptableObject
{

    public List<string> stringList;
    private string returnValue;

    private int i;

    private void OnEnable()
    {
        i = 0;
    }

    public void GetNextString()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            i = (i + 1) % stringList.Count;
        }
        returnValue = stringList[i];
        
    }

    public void SetTextUIToValue (Text obj)
    {
        obj.text = returnValue;
    }

    public void ExitTextUI (Text obj)
    {
        obj.text = null;
        i = 0;
    }
 
}
