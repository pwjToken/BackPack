﻿using System;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EventSystems_IPointerExitHandler : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnPointerExit(IntPtr l) {
		try {
			UnityEngine.EventSystems.IPointerExitHandler self=(UnityEngine.EventSystems.IPointerExitHandler)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnPointerExit(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.IPointerExitHandler");
		addMember(l,OnPointerExit);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.IPointerExitHandler));
	}
}