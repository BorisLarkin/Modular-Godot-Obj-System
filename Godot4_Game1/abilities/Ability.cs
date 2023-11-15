using Godot;
using System;

public abstract partial class Ability : Node2D
{
	public float CD {get; set;}
	public float use_time{get; set;}
	public float cost {get; set;}
	public Timer useTimer;
	protected Ability(){
		CD = 0.5f;
		use_time = 0.2f;
		cost = 0.0f;
	}
	public abstract void Use(entity Obj);
}