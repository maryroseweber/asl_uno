using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRunner : MonoBehaviour {

	// This class simply creates an interface between Unity's Start() method
    // and runs all the test functions for all classes
    // It is a LOT more flexible to do things this way than using a testing framework
    // because we can run any arbitrary code in our Test() functions.

	void Start () {

        // Because the Saver class is static, we don't need to instantiate it.
        ASLUNO.Saver.Test();
		
	}
	
    // provide some message formatting to make errors easier to see in the log
    public static void LogTestResult(bool result, string message)
    {
        message += string.Format(": {0}", result ? "SUCCESS" : "FAIL");
        if(result)
        {
            Debug.LogFormat(message);
        }
        else
        {
            Debug.LogError(message);
        }
    }
	
}
