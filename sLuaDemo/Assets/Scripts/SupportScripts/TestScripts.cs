using UnityEngine;
using System.Collections;
using SLua;

[CustomLuaClass]
public class TestScripts: MonoBehaviour 
{
    public static void TestFun()
    {
        print("测试");
    }
}
