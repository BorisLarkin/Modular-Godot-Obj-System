using Godot;
using System;
using System.Runtime.CompilerServices;  

public partial class Dash : Ability
{
    public float dash_speed {get; set;}
    public bool ghost_on {get; set;}
    public override void Use(entity Obj){
        GD.Print("dashed");
        Obj.velocity.X = Obj.direction.X * dash_speed;
		Obj.velocity.Y = Obj.direction.Y * dash_speed;
        useTimer.WaitTime = use_time;
        useTimer.Start();
    }
    public Dash(float spd, bool ghost){
        dash_speed = spd;
        ghost_on = ghost;
        CD = 50.0f;
        use_time = 10.0f;
        cost = 0;
    }
    public Dash(Dash Obj)
    {
        dash_speed = Obj.dash_speed;
        ghost_on = Obj.ghost_on;
    }
    public Dash(){
        CD = 50.0f;
        use_time = 10.0f;
        cost = 0;
    }
    public override object Clone()
    {
       return new Dash(this);
    }
}