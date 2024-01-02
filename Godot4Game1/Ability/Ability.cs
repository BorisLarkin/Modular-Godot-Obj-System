using Godot;
using System;
using System.Data.Common;
using System.Runtime.CompilerServices;
public unsafe partial class Ability : Node2D, ICloneable
{
	public float CD;
	public float use_time;
	public float cost;
	public Timer useTimer;
	public Timer CDTimer;
	
	protected bool CanUse = new bool();
	public bool* CanUseRef;
	public object Clone()
	{
		return this.MemberwiseClone();
	}
	protected virtual void Use(entity Obj){	}
	
	void _on_ready()
	{
		useTimer = GetNode<Timer>("useTimer");
		CDTimer = GetNode<Timer>("CDTimer");
		useTimer.WaitTime = use_time;
		CDTimer.WaitTime = CD;
		fixed (bool* Ref = &CanUse){
			CanUseRef = Ref;
		};
	}
	
	public void UseAbility(entity Obj)
	{
		GD.Print((ulong)CanUseRef);
		if (*CanUseRef == true){
			Use(Obj);
			*CanUseRef = false;
			useTimer.Start();
		}
	}

	protected Ability(Ability Obj){
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
			CanUse = Obj.CanUse;
			CanUseRef = Obj.CanUseRef;
		}
	}
	protected Ability(float cd, float uset, float ct){
		CD = cd;
		use_time = uset;
		cost = ct;
		CanUse = new bool();
		CanUse = true;
		fixed (bool* Ref = &CanUse){
			CanUseRef = Ref;
		};
	}
	protected void _on_use_timer_timeout()
	{
		GD.Print("use_t timeout", (ulong)CanUseRef,*CanUseRef);
		CDTimer.Start();
	}

	protected void _on_cd_timer_timeout()
	{
		*CanUseRef=true;
		GD.Print("cd_t timeout", CanUse);
	}
	public Ability()
	{
		CD=1.0f;
		use_time=0.5f;
		cost = 0;
		CanUse = true;
		fixed (bool* Ref = &CanUse){
			CanUseRef = Ref;
		};
	}
}