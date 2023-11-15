using Godot;
using System;

public partial class Player : entity
{
	public const float d_speed = 400.0f;
	public const float d_duration = 3.0f;
	private Dash dash = new Dash{CD = 50.0f, use_time = 10.0f, cost = 0, dash_speed = d_speed, ghost_on = true};
	
	public override void _PhysicsProcess(double delta)
	{
		velocity = Velocity;
		// Get the input direction and handle the movement/deceleration.
		direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction == Vector2.Zero)
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}
		else
		{
			if (Input.IsActionJustPressed("ui_dash"))
			{
				dash.Use(this);
			}
			else
			{
				velocity.X = direction.X * Speed;
				velocity.Y = direction.Y * Speed;
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public Player()
	{
		Speed = 100.0f;
		HP = 100.0f;
	}
}
