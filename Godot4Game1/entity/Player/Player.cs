using Godot;
using System;

public partial class Player : entity
{
	private Dash dash;

	public override object Clone()
	{
		return new Player(this);
	}

	void _on_dash_ready()
	{
		dash = GetNode<Dash>("Dash");
		dash.set(0.5f, 0.7f, 0, 800.0f, true, "ui_dash");
	}
	protected Player(Player Obj)
	{
		dash = new Dash(Obj.dash);
		//Speed = Obj.Speed;
		HP = Obj.HP;
	}
	protected Player()
	{
		//Speed = 100.0f;
		HP = 100.0f;
		max_speed = 200;
		acceleration=100;
		friction=250;
	}	
	public override void _PhysicsProcess(double delta)
	{
		// Input direction and handling the movement/deceleration.
		direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction == Vector2.Zero)
		{
			if (velocity.Length() > friction * delta){
				velocity -= velocity.Normalized() * (float)(friction * delta);
			}
			else{
				velocity = Vector2.Zero;
			}
		}
		else
		{
			perform(dash);
			if (velocity.Length() > max_speed){
				velocity -= velocity.Normalized() * (float)(friction * delta);
				velocity += direction * acceleration * (float)delta;
			}
			else
			{
				velocity += direction * acceleration * (float)delta;
				velocity = velocity.LimitLength(max_speed);
			}
		}
		MoveAndSlide();
	}
}
