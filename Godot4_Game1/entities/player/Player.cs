using Godot;
using System;

public partial class Player : entity
{
	public const float dash_speed = 400.0f;
	public const float dash_duration = 3.0f;
	private Dash dash(this);
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction == Vector2.Zero)
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}
		else
		{
			if (Input.IsActionJustPressed("ui_dash"))
			{
				GD.Print("dashed");
				velocity.X = direction.X * dash_speed;
				velocity.Y = direction.Y * dash_speed;
				dash.start_dash(dash_duration);
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
}
