using Godot;
using System;
public unsafe partial class Dash : Ability
{
	public float dash_speed;
	public bool ghost_on;
	
	protected override void Use(entity Obj)
	{
		Obj.velocity.X = Obj.direction.X * dash_speed;
		Obj.velocity.Y = Obj.direction.Y * dash_speed;
	}
	public Dash(Dash Obj) : base(Obj)
	{
		dash_speed = Obj.dash_speed;
		ghost_on = Obj.ghost_on;
	}

	public Dash () : base() 
	{
		dash_speed = 600f;
		ghost_on = false;
	}

	public void set(float cd, float uset, float ct, float dash_spd, bool ghost)
	{
		GD.Print("dash set");
		CD = cd;
		use_time = uset;
		cost = ct;
		useTimer = GetNode("Ability").GetNode<Timer>("useTimer");
		CDTimer = GetNode("Ability").GetNode<Timer>("CDTimer");
		ParentalAbilityNode = GetNode("Ability");
		CDTimer.WaitTime = cd;
		useTimer.WaitTime = uset;
		dash_speed = dash_spd;
		ghost_on = ghost;
	}
}
