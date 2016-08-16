using System;
using LuaInterface;
using SLua;
using System.Collections.Generic;
public class Lua_AeroplaneAiControl : LuaObject {
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int Reset(IntPtr l) {
		try {
			AeroplaneAiControl self=(AeroplaneAiControl)checkSelf(l);
			self.Reset();
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static public int SetTarget(IntPtr l) {
		try {
			AeroplaneAiControl self=(AeroplaneAiControl)checkSelf(l);
			UnityEngine.Transform a1;
			checkType(l,2,out a1);
			self.SetTarget(a1);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
	}
	static public void reg(IntPtr l) {
		getTypeTable(l,"AeroplaneAiControl");
		addMember(l,Reset);
		addMember(l,SetTarget);
		createTypeMetatable(l,null, typeof(AeroplaneAiControl),typeof(UnityEngine.MonoBehaviour));
	}
}
