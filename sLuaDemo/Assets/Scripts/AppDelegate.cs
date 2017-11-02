using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SLua;
using System.IO;
using System;
using System.Collections.Generic;

public class AppDelegate : MonoBehaviour 
  {

      //private List<int> tempList = new List<int>();
      private Transform canvas;
      //添加LuaState初始化时的回调函数特性函数
      [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
      static int init(IntPtr L)
      {
          //设置初始化LuaObject对象
          LuaObject.init(L);
          return 0;
      }
      private LuaSvr luasvr;
      LuaFunction updateFunc;
      void Awake()
      {
        
          canvas = GameObject.Find("Canvas").transform;
      }
      void Start()
      {
          
          #region
          //LuaState lua = new LuaState();
          ////设置脚本启动代理
          //lua.loaderDelegate = ((string fn) =>//loaderDelegate:返回值为byte[]类型的委托    Lambda 运算符 => 左侧指定输入参数（如果有），然后在另一侧输入表达式或语句块
          //{
          //    //获取Lua文件执行目录
          //    string file_path = Directory.GetCurrentDirectory() + "/Assets/Resources/" + fn;

          //    Debug.Log(file_path);

          //    return File.ReadAllBytes(file_path);//打开一个文件，将文件的内容读入一个字符串，然后关闭该文件
          //});
          //LuaState.pcall(lua.L, init);
          //lua.doFile("hello.lua");
          //LuaFunction mul = lua.getFunction("mul");
          //double result = (double)mul.call(-2,5);
          //Debug.Log(result);
          #endregion
          luasvr = new LuaSvr();
          luasvr.init(null, Complete, LuaSvrFlag.LSF_BASIC | LuaSvrFlag.LSF_EXTLIB);
          updateFunc = LuaSvr.mainState.getFunction("update");

      }
      private void Complete()
      {
          luasvr.start("MytestDemo");
      }

      void Update()
      {
          Vector2 position;
          RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas as RectTransform,Input.mousePosition,null,out position);
          updateFunc.call(position);
      }

  }
