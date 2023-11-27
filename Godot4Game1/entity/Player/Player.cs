using Godot;
using System;

public partial class Player : entity
{
	private Dash dash;

	public override object Clone()
	{
		return new Player(this);
	}
	protected Player(Player Obj)
	{
		dash = new Dash(2.0f, 1.0f, 0, 600.0f, true);
		GD.Print("init copy player");
		dash = new Dash(Obj.dash);
		Speed = Obj.Speed;
		HP = Obj.HP;
	}
	protected Player()
	{
		dash = new Dash(100.0f, 40.0f, 0, 600.0f, true);
		GD.Print("init player");
		Speed = 100.0f;
		HP = 100.0f;
	}	
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
				dash.UseAbility(this);
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
