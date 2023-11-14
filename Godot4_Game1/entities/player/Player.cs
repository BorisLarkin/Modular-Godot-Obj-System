using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 100.0f;
	public const float dash_speed = 400.0f;
	public const float dash_duration = 0.5f;
	private Dash dash;
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			if (Input.IsActionJustPressed("dash"))
			{
				Console.WriteLine("dashed");
				velocity.X = Mathf.MoveToward(Velocity.X, 0, dash_speed);
				velocity.Y = Mathf.MoveToward(Velocity.Y, 0, dash_speed);
			}
			else
			{
				velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
				velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
