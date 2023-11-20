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
	
	public override void _Ready()
	{
    	useTimer = GetNode<Timer>("useTimer");
		CDTimer = GetNode<Timer>("CDTimer");
	}
	public void UseAbility(entity Obj)
	{
		if (CanUse){
			useTimer.Start();
			GD.Print("dashed ", CD);
			Use(Obj);
		}
	}

	protected Ability(Ability Obj){
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
			//this.useTimer = new Timer();
			//this.CDTimer = new Timer();
			useTimer.WaitTime = use_time;
			CDTimer.WaitTime = CD;
			useTimer.Autostart = true;
			CDTimer.Autostart = true;
			CanUse = true;
		}
	}
	protected Ability(float cd, float uset, float ct){
		GD.Print("right constr");
		CD = cd;
		use_time = uset;
		cost = ct;
		//useTimer = new Timer();
		//CDTimer = new Timer();
		//useTimer = GetNode("res://Ability/Ability.tscn").GetNode<Timer>("useTimer");
		//CDTimer = GetNode<Timer>("CDTimer");
		CDTimer.WaitTime = CD;
		useTimer.WaitTime = use_time;
		//useTimer.Autostart = true;
		//CDTimer.Autostart = true;
		CanUse = true;
	}
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
	public Ability(){
		CD = 50.0f;
		use_time = 10.0f;
		cost = 0.0f;
		useTimer = new Timer();
		CDTimer = new Timer();
		CDTimer.WaitTime = CD;
		useTimer.WaitTime = use_time;
		useTimer.Autostart = true;
		CDTimer.Autostart = true;
		CanUse = true;
		}
}
