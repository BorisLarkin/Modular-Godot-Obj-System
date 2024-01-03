using Godot;
using System;
using System.Data.Common;
using System.Runtime.CompilerServices;
public unsafe partial class Ability : Node2D, ICloneable
{
	public float CD;
	public float use_time;
	public float cost;
	protected Timer useTimer;
	protected Timer CDTimer;
	protected Node ParentalAbilityNode;
	protected bool is_using;
	protected entity passive_application;
	protected entity active_application;
	protected string input_key;

	public virtual void perform(entity obj){
		if (get_state()){
			Use(passive_application);
		}
		else{
			if (Input.IsActionJustPressed("ui_dash")){
				this.UseAbility(obj);
				passive_application = obj;
			}
		} 
	}
	public bool get_state(){
		return is_using;
	}
	public void set_state(bool x){
		is_using = x;
		return;
	}
	public void set_canuse_true(){
		ParentalAbilityNode.SetMeta("CanUse",true);
		return;
	}
	public void set_canuse_false(){
		ParentalAbilityNode.SetMeta("CanUse",false);
		return;
	}
	public bool get_canuse_state(){
		return (bool)ParentalAbilityNode.GetMeta("CanUse");
	}
	public object Clone()
	{
		return this.MemberwiseClone();
	}
	protected virtual void Use(entity obj){}
	public void UseAbility(entity obj)
	{
		GD.Print(get_canuse_state());
		if (get_canuse_state() == true){
			Use(obj);
			passive_application = obj;
			is_using = true;
			set_canuse_false();
			useTimer.Start();
		}
	}
	void _on_ready()
	{
		useTimer = GetNode<Timer>("useTimer");
		CDTimer = GetNode<Timer>("CDTimer");
		useTimer.WaitTime = use_time;
		CDTimer.WaitTime = CD;
		ParentalAbilityNode = GetNode(this.GetPath());
		is_using = false;
	}
	
	protected Ability(Ability Obj){
		if (this != Obj){
			this.CD = Obj.CD;
			this.use_time = Obj.use_time;
			this.cost = Obj.cost;
		}
	}
	protected Ability(float cd, float uset, float ct){
		CD = cd;
		use_time = uset;
		cost = ct;
		set_canuse_true();
	}
	protected void _on_use_timer_timeout()
	{
		is_using = false;
		GD.Print("use_t timeout", get_canuse_state());
		CDTimer.Start();
	}

	protected void _on_cd_timer_timeout()
	{
		set_canuse_true();
		GD.Print("cd_t timeout", get_canuse_state());
	}
	public Ability()
	{
		CD=1.0f;
		use_time=0.5f;
		cost = 0;
		is_using = false;
	}
}