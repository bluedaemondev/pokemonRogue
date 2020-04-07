using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolaMundo : MonoBehaviour
{
    /// <summary>
    /// Hola mundo
    /// 
    /// coso
    /// </summary>
    void Start()
    {
        HolaMundo holaMundo = new HolaMundo();
        print(holaMundo.ToString());
    }
    public override string ToString()
    {
        return string.Concat("hola", ' ', "mundo");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
