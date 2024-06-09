using Godot;
using System;

public partial class RightOutZone : Area2D
{
	GDScript UI = GD.Load<GDScript>("res://Scripts/ui.gd");

	public void OnBodyEntered(Node2D body){
		if (body is ball Ball){
			Ball.Respawn();
			UI.Call("right_up");
		}
	}
}
