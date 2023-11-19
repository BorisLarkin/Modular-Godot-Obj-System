using Godot;
using System;
public partial class Dash : Ability
{
	public float dash_speed;
	public bool ghost_on;
	protected override void Use(entity Obj){
		Obj.velocity.X = Obj.direction.X * dash_speed;
		Obj.velocity.Y = Obj.direction.Y * dash_speed;
	}
	public Dash(Dash Obj) : base(Obj)
	{
		dash_speed = Obj.dash_speed;
		ghost_on = Obj.ghost_on;
	}

	public Dash(float cd, float uset, float ct, float dash_spd, bool ghost) : base(cd, uset, ct)
	{
		dash_speed = dash_spd;
		ghost_on = ghost;
	}
	public Dash () : base()
	{
		dash_speed = 400.0f;
		ghost_on = false;
	}
	public object Clone()
	{
	   return new Dash(this);
	}
}
