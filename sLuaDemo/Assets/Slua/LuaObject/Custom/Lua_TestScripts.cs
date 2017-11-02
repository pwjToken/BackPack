using System;
using SLua;
using System.Collections.Generic;
public class Lua_TestScripts : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int TestFun_s(IntPtr l) {
		try {
			TestScripts.TestFun();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"TestScripts");
		addMember(l,TestFun_s);
		createTypeMetatable(l,null, typeof(TestScripts),typeof(UnityEngine.MonoBehaviour));
	}
}
