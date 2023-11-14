using Godot;
using System;
using System.Runtime.CompilerServices;  

public partial class Dash : Ability
{
    public Dash(entity Obj);
    public void start_dash(float duration){
        useTimer.WaitTime = duration;
        useTimer.Start();
    }
    public void start_dash(){
        useTimer.Start();
    }

    public bool is_dashing(){
        return !useTimer.IsStopped();
    }
}
