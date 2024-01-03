using Godot;
using System;
using System.Data.Common;
using System.Runtime.CompilerServices;
public unsafe partial class Ability : Node2D, ICloneable
{
	public float CD;
	public float use_time;
	public float cost;
	protected Timer useTimer;
	protected Timer CDTimer;
	protected virtual void set_canuse_true(){
		SetMeta("CanUse",true);
		return;
	}
	protected virtual void set_canuse_false(){
		SetMeta("CanUse",false);
		return;
	}
	protected virtual bool get_use_state(){
		return (bool)GetMeta("CanUse");
	}
	public object Clone()
	{
		return this.MemberwiseClone();
	}
	protected virtual void Use(entity Obj){}
	public virtual void UseAbility(entity Obj){}
	void _on_ready()
	{
		useTimer = GetNode<Timer>("useTimer");
		CDTimer = GetNode<Timer>("CDTimer");
		useTimer.WaitTime = use_time;
		CDTimer.WaitTime = CD;
	}
	
	protected Ability(Ability Obj){
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
		}
	}
	protected Ability(float cd, float uset, float ct){
		CD = cd;
		use_time = uset;
		cost = ct;
		set_canuse_true();
	}
	protected void _on_use_timer_timeout()
	{
		GD.Print("use_t timeout", get_use_state());
		CDTimer.Start();
	}

	protected void _on_cd_timer_timeout()
	{
		set_canuse_true();
		GD.Print("cd_t timeout", get_use_state());
	}
	public Ability()
	{
		CD=1.0f;
		use_time=0.5f;
		cost = 0;
	}
}