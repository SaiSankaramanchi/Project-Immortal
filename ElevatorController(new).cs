

using UnityEngine;

using System.Collections;
	
	
[System.Serializable]
	
	
	public class ElevatorController : MonoBehaviour 
	{
	
	
			
		public float elevatorSpeed = 0.05f;
	
	
	
		public Transform[] ElevatorFloors;
	
		
	
		
		public int CurrentFloor = 0;
	
	
		private int floorNumber = 0;
	
		private string elevatorDirection;
		
		public bool ElevatorMoving;
	
		private bool ElevatorMax;
	
		private bool ElevatorMin;
		
		private bool isMoved = false;
	
	
		void Start ()
	
		{
		
			transform.position = ElevatorFloors[CurrentFloor].position;
		

	
		}
	
	
		
		public void ElevatorGO (string ElevatorDirection) 
		{
		
			elevatorDirection = ElevatorDirection;
		
			FloorNumber();
			
		}
	
	
		
		void FloorNumber ()
	
		{
		
			floorNumber = Mathf.Clamp(floorNumber, 0, ElevatorFloors.Length - 1);
		
			if(elevatorDirection == "ElevatorUp" && !ElevatorMoving && !ElevatorMax)
		
			{
			
				floorNumber += 1;
		
			}
		
			if(elevatorDirection == "ElevatorDown" && !ElevatorMoving && !ElevatorMin)
		
			{
			
				floorNumber -= 1;
		
			}		
	
		}
	
	
		
		void FixedUpdate() 
		{
		
			Transform ElevatorFloor = ElevatorFloors[floorNumber];
		
			if(elevatorDirection == "ElevatorUp")
		
			{
			
				ElevatorMoving = true;
			
				transform.position = Vector3.MoveTowards(transform.position, ElevatorFloor.position, elevatorSpeed);
		
			}
		
		
			if(elevatorDirection == "ElevatorDown")
		
			{
			
				ElevatorMoving = true;
			
				transform.position = Vector3.MoveTowards(transform.position, ElevatorFloor.position, elevatorSpeed);
		
			}
		
		
			if(this.transform.position == ElevatorFloor.position)
		
			{
			
				ElevatorMoving = false;
		
			}
		
		
			if(this.transform.position == ElevatorFloors[0].position)
		
			{
			
				ElevatorMax = false;
			
				ElevatorMin = true;
		
			}
		
		
			if(this.transform.position.y > ElevatorFloors[0].position.y)
		
			{
			
				ElevatorMin = false;
		
			}
		
		
			int MaxFloors = ElevatorFloors.Length - 1;
		
			if(this.transform.position == ElevatorFloors[MaxFloors].position)
		
			{
			
				ElevatorMax = true;
			
				ElevatorMin = false;
		
			}
		
		
			if(this.transform.position.y < ElevatorFloors[MaxFloors].position.y)
		
			{
			
				ElevatorMax = false;
		
			}
		
		
			if(ElevatorMoving && !isMoved)
		
			{
					
				isMoved = true;
		
			}
		
			if(this.transform.position == ElevatorFloors[floorNumber].position && !ElevatorMoving && isMoved)
		
			{
			
				isMoved = false;
		
			}
	
		}
	
	
		
		void OnDrawGizmos() 
		{
		
			for(int i = 0; i < ElevatorFloors.Length; i++) 
			{
			
				Gizmos.color = Color.red;
			
				float x = ElevatorFloors[i].position.x;
			
				float y = ElevatorFloors[i].position.y;
			
				float z = ElevatorFloors[i].position.z;
			
				Gizmos.DrawWireCube(new Vector3(x, y+1.502f, z), new Vector3(2.4f, 3.0f, 2.2f));
		
			}
	
		}
	
}
