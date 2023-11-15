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
        //useTimer.WaitTime = use_time;
        //useTimer.Start();
    }
    public Dash(float spd, bool ghost){
        dash_speed = spd;
        ghost_on = ghost;
        CD = 50.0f;
        use_time = 10.0f;
        cost = 0;
    }
    public Dash(){
        CD = 50.0f;
        use_time = 10.0f;
        cost = 0;
    }
    public Dash(Dash Obj){
        CD = Obj.CD;
        use_time = Obj.use_time;
        cost = Obj.cost;
    }
}