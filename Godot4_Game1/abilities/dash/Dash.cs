using Godot;
using System;
using System.Runtime.CompilerServices;  

public partial class Dash : Ability
{
    protected float dash_speed;
    protected bool ghost_on = false;
    public override void Use(entity Obj){
        GD.Print("dashed");
        Obj.velocity.X = Obj.direction.X * dash_speed;
		Obj.velocity.Y = Obj.direction.Y * dash_speed;
        useTimer.WaitTime = use_time;
        useTimer.Start();
    }
    public void start_dash(){
        useTimer.Start();
    }
    public bool is_dashing(){
        return !useTimer.IsStopped();
    }
    public Dash(float spd, bool ghost){
        dash_speed = spd;
        ghost_on = ghost;
    }
    public Dash(){
        dash_speed = 200.0f;
        ghost_on = false;
    }
}