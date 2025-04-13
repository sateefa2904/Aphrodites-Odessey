using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;

namespace TempDemo.Platformer
{
    [InitializeOnLoad]
    public class ImportPackage
    {
        static bool completed = false;

        static ImportPackage()
        {
            EditorApplication.hierarchyWindowChanged += AfterLoad;
        }

        static void AfterLoad()
        {
            if (!completed)
            {
                //Nothing to load yet

                completed = true;
            }
        }
        
    }

}