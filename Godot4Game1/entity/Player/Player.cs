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
	}	
	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
		// Get the input direction and handle the movement/deceleration.
		direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction == Vector2.Zero)
		{
			//velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			//velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}
		else
		{
			dash.perform(this);
			//velocity.X = direction.X * Speed;
			//velocity.Y = direction.Y * Speed;
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
