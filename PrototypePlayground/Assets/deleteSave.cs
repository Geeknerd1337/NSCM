using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class deleteSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void delete()
    {
        System.IO.Directory.Delete("Save");
    }
}
