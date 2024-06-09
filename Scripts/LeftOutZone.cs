using Godot;
using System;

public partial class LeftOutZone : Area2D
{
	GDScript UI = GD.Load<GDScript>("res://Scripts/ui.gd");

	public void OnBodyEntered(Node2D body){
		if (body is ball Ball){
			Ball.Respawn();
			UI.Call("left_up");
		}
	}
}