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
	
	protected virtual void Use(entity Obj){}
	
	protected void change_state(){
		if (CanUse){CanUse = false; return;}
		CanUse = true;
		return;
	}
	void _on_ready()
	{
		GD.Print("Entered");
		useTimer = GetNode<Timer>("useTimer");
		CDTimer = GetNode<Timer>("CDTimer");
		useTimer.WaitTime = use_time;
		CDTimer.WaitTime = CD;
	}
	
	
	public void UseAbility(entity Obj)
	{
		GD.Print("CanUse = ", CanUse);
		if (CanUse == true){
			useTimer.Start();
			change_state();
			GD.Print("dashed ", CanUse);
			Use(Obj);
		}
		GD.Print("ended use");
	}

	protected Ability(Ability Obj){
		GD.Print("copy");
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
			CanUse = true;
		}
	}
	protected Ability(float cd, float uset, float ct){
		GD.Print("right constr");
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
		change_state();
		GD.Print("cd_t timeout", CanUse);
	}
	public Ability(){
		GD.Print("wrong constr");
		CD=1.0f;
		use_time=0.5f;
		cost = 0;
		CanUse=true;
	}
}
