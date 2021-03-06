﻿using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_LTUtility : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int constructor(IntPtr l) {
		try {
			LTUtility o;
			o=new LTUtility();
			pushValue(l,true);
			pushValue(l,o);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int reverse_s(IntPtr l) {
		try {
			UnityEngine.Vector3[] a1;
			checkArray(l,1,out a1);
			var ret=LTUtility.reverse(a1);
			pushValue(l,true);
			pushValue(l,ret);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"LTUtility");
		addMember(l,reverse_s);
		createTypeMetatable(l,constructor, typeof(LTUtility));
	}
}
