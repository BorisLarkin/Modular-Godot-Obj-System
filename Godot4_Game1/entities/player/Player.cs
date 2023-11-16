using Godot;
using System;

public partial class Player : entity
{
	private Dash dash = new Dash{CD = 50.0f, use_time = 10.0f, cost = 0, dash_speed = 400.0f, ghost_on = true};
	
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
	 public override object Clone()
     {
        return new Player(this);
     }
	protected Player(Player Obj)
	{
		dash = new Dash(Obj.dash);
		Speed = Obj.Speed;
		HP = Obj.HP;
	}
	protected Player(){
		dash = new Dash();
		Speed = 100.0f;
		HP = 100.0f;
	}
}
