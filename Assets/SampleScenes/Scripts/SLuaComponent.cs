///**
// * LUA组件：Lua游戏逻辑粘合层
// * 
// * 作者：燕良
// * 网址：http://blog.csdn.net/neil3d
// * QQ群：264656505
// * 
// */

//using UnityEngine;
//using System.Collections;
////using LuaInterface;
//using SLua;
//using UnityStandardAssets.Vehicles.Aeroplane;

///// <summary>
///// Lua组件 - 它调用的Lua脚本可以实现类似MonoBehaviour派生类的功能
///// </summary>
//[AddComponentMenu("Lua/SLuaComponent")]
//public class SLuaComponent : MonoBehaviour
//{
//    [Tooltip("绑定的LUA脚本路径")]
//    public TextAsset m_luaScript;

//    LuaSvr svr;
//    LuaTable self;
//    LuaFunction update;
//    LuaFunction start;
//    LuaFunction init;

//    void Awake()
//    {
//        svr = new LuaSvr();
//        svr.init(null, () =>
//        {
//            self = (LuaTable)svr.start(m_luaScript.name);
//            Debug.Log("###LuaTable### " + self.ToString());
//            AeroplaneAiControl aiControl = this.GetComponent<AeroplaneAiControl>();
//            Debug.Log("AeroplaneAiControl " + aiControl.ToString());
//            init = (LuaFunction)self["Init"];
//            if (init != null)
//            {
//                init.call(self, this);
//            }
//            start = (LuaFunction)self["Start"];
//            update = (LuaFunction)self["Update"];
//        });
//    }

//    void Start()
//    {
//        if (start != null) start.call(self, this);
//    }

//    void Update()
//    {
//        if (update != null) update.call(self, this);
//    }
//}
