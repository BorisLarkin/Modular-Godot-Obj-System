using Godot;
using System;

public abstract partial class Ability : Timer
{
	public float CD {get; set;}
	public float use_time{get; set;}
	public float cost {get; set;}
	public Timer useTimer;
	protected Ability(){
		CD = 0.5f;
		use_time = 0.2f;
		cost = 0.0f;
		useTimer = GetNode<Timer>("useTimer");
	}
	public abstract void Use(entity Obj);
	protected Ability(Ability Obj){
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
			this.useTimer = new Timer();

		}
	}
	
	public abstract object Clone();
}