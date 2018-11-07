﻿

using UnityEngine;

using System.Collections;


public class ElevatorButton : MonoBehaviour 
{
	
	
	public GameObject m_ElevatorController;
		
	public bool ElevatorMoving;
	
	
	public void SendCall (string Call) 
	{
		
		ElevatorController Elevator = m_ElevatorController.GetComponent<ElevatorController>();
		
		ElevatorMoving = Elevator.ElevatorMoving;
		
		if(Call == "ElevatorUp" && !ElevatorMoving)
		
		{
			
			Elevator.ElevatorGO("ElevatorUp");
		
		}
		
		
		if(Call == "ElevatorDown" && !ElevatorMoving)
		
		{
			
			Elevator.ElevatorGO("ElevatorDown");
		
		}
	
	}

}
