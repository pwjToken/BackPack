using UnityEngine;
using System.Collections;
using SLua;
using System;

public class Circle : MonoBehaviour {


	LuaSvr svr;
	LuaTable self;
	LuaFunction update;

    [CustomLuaClass]
    public delegate void UpdateDelegate(object self);

    UpdateDelegate ud;

	void Start () {
		svr = new LuaSvr();
		svr.init(null, () =>
		{
			self = (LuaTable)svr.start("circle/circle");
            update = (LuaFunction)self["update"] ;
            ud = update.cast<UpdateDelegate>();
		});
	}
	
	void Update () {

        //这里必须带一个参数，在默认function class:update()函数中，默认是传入自身的，但通过c#调用时，需要先在lua的main入口函数中返回该表，然后在下面的函数中将self表传递到lua中，而这里是可以直接通过update.call(self)来完成的，但为了避免犯错，规定必须要传一个自身信息的参数，所以用委托来约束，ud = update.cast<UpdateDelegate>()是将update函数转换成一个参数的委托类型
        if (ud != null) ud(self);
        update.call(self);//call(self) 与 call() 都不会显式报错，而ud如果不传入参数就会显式报错
	}
}
