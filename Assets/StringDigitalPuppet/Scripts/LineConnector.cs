﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public GameObject[] _obj;

    private LineRenderer line;
        


    void Start()
    {

    }

     void Update()
    {
        line = this.gameObject.GetComponent<LineRenderer>();
        if (_obj.Length > 0)
            line.positionCount = _obj.Length;
        for (int i = 0; i < _obj.Length; i++)
        {
            line.SetPosition(i, _obj[i].transform.position);
        }  
    }
}
