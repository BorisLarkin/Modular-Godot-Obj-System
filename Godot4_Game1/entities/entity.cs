using Godot;
using System;

public abstract partial class entity : CharacterBody2D
{
	public float Speed = 100.0f;
	// Called when the node enters the scene tree for the first time.
	public float HP = 100.0f;
	public override void _PhysicsProcess(double delta){}
}
