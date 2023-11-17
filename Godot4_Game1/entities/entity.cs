using Godot;
using System;

public abstract partial class entity : CharacterBody2D, ICloneable
{
	public float Speed;
	// Called when the node enters the scene tree for the first time.
	public float HP;
	public override void _PhysicsProcess(double delta){}
	public Vector2 direction;
	public Vector2 velocity;
	protected entity(entity Obj){
		if (this != Obj){
			this.Speed = Obj.Speed;
			this.HP = Obj.HP;
		}
	}
	protected entity(){
		this.Speed = 0.0f;
		this.HP = 0.0f;
	}
	protected entity(float spd, float hp){
		this.Speed = spd;
		this.HP = hp;
	}
	
	public abstract object Clone();
}
