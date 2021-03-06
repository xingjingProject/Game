﻿using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_UnityEngine_BillboardRenderer : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int get_billboard(IntPtr l) {
		try {
			UnityEngine.BillboardRenderer self=(UnityEngine.BillboardRenderer)checkSelf(l);
			pushValue(l,true);
			pushValue(l,self.billboard);
			return 2;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int set_billboard(IntPtr l) {
		try {
			UnityEngine.BillboardRenderer self=(UnityEngine.BillboardRenderer)checkSelf(l);
			UnityEngine.BillboardAsset v;
			checkType(l,2,out v);
			self.billboard=v;
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"UnityEngine.BillboardRenderer");
		addMember(l,"billboard",get_billboard,set_billboard,true);
		createTypeMetatable(l,null, typeof(UnityEngine.BillboardRenderer),typeof(UnityEngine.Renderer));
	}
}
