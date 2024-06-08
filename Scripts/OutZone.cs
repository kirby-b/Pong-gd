using Godot;
using System;

public partial class OutZone : Area2D
{

	public void OnBodyEntered(Node2D body){
		if (body is ball Ball){
			Ball.Respawn();
		}
	}
}
