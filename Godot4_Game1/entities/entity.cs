using Godot;
using System;

public abstract partial class entity : CharacterBody2D
{
	public float Speed {get; set;}
	// Called when the node enters the scene tree for the first time.
	public float HP  {get; set;}
	public override abstract void _PhysicsProcess(double delta);
	public Vector2 direction;
	public Vector2 velocity;
}
