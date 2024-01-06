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
		dash.set(0.5f, 0.2f, 0, 400.0f, true, "ui_dash", true);
	}
	protected Player(Player Obj)
	{
		dash = new Dash(Obj.dash);
		HP = Obj.HP;
	}
	protected Player()
	{
		HP = 100.0f;
		max_speed = 200;
		acceleration=400;
		friction=500;
	}	
	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
		// Input direction and handling the movement/deceleration.
		direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (velocity.Length() > max_speed){
				velocity -= velocity.Normalized() * (float)(friction * delta);
		}
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
			
			if (velocity.Length()<=max_speed)
			{
				velocity += direction * acceleration * (float)delta;
				velocity = velocity.LimitLength(max_speed);
			}
		}
		Velocity = velocity;
		MoveAndSlide();
	}
}
