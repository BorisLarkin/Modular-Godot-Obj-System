using Godot;
using System;

public abstract partial class Ability
{
	public float CD {get; set;}
	public float use_time{get; set;}
	public float cost {get; set;}
	public Timer useTimer;
	public Timer CDTimer;
	protected bool CanUse;
	protected Ability(){
		CD = 0.5f;
		use_time = 0.2f;
		cost = 0.0f;
		useTimer = new Timer();
		CDTimer = new Timer();
		CanUse = true;
	}
	public abstract void Use(entity Obj);
	
	protected Ability(Ability Obj){
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
			this.useTimer = new Timer();
			this.CDTimer = new Timer();
			useTimer.WaitTime = use_time;
			CDTimer.WaitTime = CD;
			CanUse = true;
		}
	}
	
	public abstract object Clone();

	protected void _on_use_timer_timeout()
    {
        CanUse = false;
        CDTimer.Start();
    }

    protected void _on_cd_timer_timeout()
    {
        CanUse = true;
    }
}