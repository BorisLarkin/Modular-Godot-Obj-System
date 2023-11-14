using Godot;
using System;
using System.Runtime.CompilerServices;  

public partial class Dash : Node2D
{
	private Timer delayTimer;

    private Dash()
    {
        delayTimer = GetNode<Timer>("DurationTimer");
    }

    public void start_dash(float duration){
        delayTimer.WaitTime = duration;
        delayTimer.Start();
    }

    public bool is_dashing(){
        return !delayTimer.IsStopped();
    }
}
