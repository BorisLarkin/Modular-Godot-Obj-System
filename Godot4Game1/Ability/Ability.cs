using Godot;
using System;
public partial class Ability : Node2D
{
	public float CD;
	public float use_time;
	public float cost;
	public Timer useTimer;
	public Timer CDTimer;
	
	protected bool CanUse;
	
	protected virtual void Use(entity Obj){	}
	
	void _on_ready()
	{
		useTimer = GetNode<Timer>("useTimer");
		CDTimer = GetNode<Timer>("CDTimer");
		useTimer.WaitTime = use_time;
		CDTimer.WaitTime = CD;
	}
	
	public void UseAbility(entity Obj)
	{
		GD.Print(CanUse);
		if (CanUse == true){
			Use(Obj);
			CanUse = false;
			useTimer.Start();
		}
	}

	protected Ability(Ability Obj){
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
			CanUse = Obj.CanUse;
		}
	}
	protected Ability(float cd, float uset, float ct){
		CD = cd;
		use_time = uset;
		cost = ct;
		CanUse = true;
	}
	protected void _on_use_timer_timeout()
	{
		GD.Print("use_t timeout", CanUse);
		CDTimer.Start();
	}

	protected void _on_cd_timer_timeout()
	{
		CanUse=true;
		GD.Print("cd_t timeout", CanUse);
	}
	public Ability(){
		CD=1.0f;
		use_time=0.5f;
		cost = 0;
		CanUse=true;
	}
}
