using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovimentoNpc : MonoBehaviour 
{

	[SerializeField]
	Transform[] waypoints;

	[SerializeField]
	float moveSpeed;
	float Speed ;

	int waypointIndex = 0;

	private Animator anim;
	private Vector2 dir;

	void Start() 
	{
		transform.position = waypoints [waypointIndex].transform.position;
		anim = GetComponent<Animator>();
		Speed = moveSpeed;

	}

	void Update() 
	{
		Move();
		Anim();
	}

	void Move()
	{
		transform.position = Vector3.MoveTowards (transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
		
		if (transform.position == waypoints [waypointIndex].transform.position ) 
		{
			anim.SetBool("isRunning", true);
			if (waypointIndex >= waypoints.Length - 1)
			{
				waypointIndex = 1;
			}
            else waypointIndex += 1;
		}		
			
	}

	void Anim()
    {
		// O ULTIMO PONTO DO CAMINHO DEVE SER IGUAL AO PRIMEIRO SENAO ELE NAO FUNCIONA********
		if(waypointIndex < waypoints.Length)
			dir = waypoints[waypointIndex].transform.position - waypoints[waypointIndex -1].transform.position;
	


		if ( Math.Abs(dir.y) > Math.Abs(dir.x))
		{
			//Cima
			anim.SetFloat("Vertical", dir.y);
			anim.SetFloat("Horizontal", 0);
		}
		
		else if ( Math.Abs(dir.x) > Math.Abs(dir.y))
		{
			//Esquerda
			anim.SetFloat("Horizontal" , dir.x);
			anim.SetFloat("Vertical", 0);
		}
	}

	public void ParaMov()
    {
		moveSpeed = moveSpeed - moveSpeed;
		anim.SetBool("isRunning", false);
	}

	public void ContinuaMov()
    {
		moveSpeed = Speed; 
		anim.SetBool("isRunning", true);
	}

}
