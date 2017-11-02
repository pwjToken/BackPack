﻿using System;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_EventSystems_IBeginDragHandler : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int OnBeginDrag(IntPtr l) {
		try {
			UnityEngine.EventSystems.IBeginDragHandler self=(UnityEngine.EventSystems.IBeginDragHandler)checkSelf(l);
			UnityEngine.EventSystems.PointerEventData a1;
			checkType(l,2,out a1);
			self.OnBeginDrag(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.EventSystems.IBeginDragHandler");
		addMember(l,OnBeginDrag);
		createTypeMetatable(l,null, typeof(UnityEngine.EventSystems.IBeginDragHandler));
	}
}