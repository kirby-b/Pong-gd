using Godot;
using System;

public partial class LeftOutZone : Area2D
{	
	// Connects the UI script so it can be sent the points when they increase
	GDScript UI = GD.Load<GDScript>("res://Scripts/ui.gd");

	// This one just gives the right player a point if it hits the left zone
	public void OnBodyEntered(Node2D body){
		if (body is ball Ball){
			Ball.Respawn();
			UI.Call("right_up");
		}
	}
}
