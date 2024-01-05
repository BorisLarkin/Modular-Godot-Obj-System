using Godot;
using System;

public abstract partial class entity : CharacterBody2D, ICloneable
{
	public float max_speed;
	public float acceleration;
	public float friction;
	public float HP;
	public override void _PhysicsProcess(double delta){}
	public Vector2 direction;
	public Vector2 velocity;
	protected entity(entity Obj){
		if (this != Obj){
			max_speed = Obj.max_speed;
			acceleration = Obj.acceleration;
			friction = Obj.friction;
			this.HP = Obj.HP;
		}
	}
	protected entity(){
		max_speed = 300;
		acceleration = 150;
		friction = 100.0f;
		HP = 100.0f;
	}
	protected entity(float max_spd, float hp, float a, float fr){
		max_speed = max_spd;
		acceleration = a;
		friction = fr;
		HP = hp;
	}
	
	public abstract object Clone();
}
