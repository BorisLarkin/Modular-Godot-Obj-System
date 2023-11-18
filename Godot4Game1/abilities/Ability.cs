using Godot;
using System;
using System.Reflection.Metadata; 
public abstract partial class Ability
{
	public float CD;
	public float use_time;
	public float cost;
	public Timer useTimer;
	public Timer CDTimer;
	
	protected bool CanUse;
	
	protected abstract void Use(entity Obj);
	
	public void UseAbility(entity Obj)
	{
		if (CanUse){
			useTimer.Start();
			Use(Obj);
		}
	}

	protected Ability(Ability Obj){
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
			this.useTimer = new Timer();
			this.CDTimer = new Timer();
			useTimer.WaitTime = use_time;
			CDTimer.WaitTime = CD;
			useTimer.Autostart = true;
			CDTimer.Autostart = true;
			CanUse = true;
		}
	}
	protected Ability(float cd, float uset, float ct){
		CD = cd;
		use_time = uset;
		cost = ct;
		useTimer = new Timer();
		CDTimer = new Timer();
		CDTimer.WaitTime = CD;
		useTimer.WaitTime = use_time;
		useTimer.Autostart = true;
		CDTimer.Autostart = true;
		CanUse = true;
	}
	
	public abstract object Clone();

	protected void _on_use_timer_timeout()
    {
		GD.Print("use_t timeout");
        CanUse = false;
    }

    protected void _on_cd_timer_timeout()
    {
		GD.Print("cd_t timeout");
        CanUse = true;
    }
}