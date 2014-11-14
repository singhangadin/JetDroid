using UnityEngine;
using System.Collections;

public class Switch:MonoBehaviour 
{	public DoorTrigger[] doorTriggers;
	public bool sticky;
	public AudioClip SwitchSound;
	private bool down;
	private Animator animator;
	
	void Start() 
	{	animator=GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D target)
	{	animator.SetInteger("AnimState",1);
		down=true;
		foreach(DoorTrigger trigger in doorTriggers) 
		{	if(trigger!=null)
			{	trigger.Toggle(true);
			}
		}
		if(SwitchSound)
		{	AudioSource.PlayClipAtPoint(SwitchSound,transform.position);
		}
	}

	void OnTriggerExit2D(Collider2D target)
	{	if(sticky&&down)
		{	return;
		}
		animator.SetInteger("AnimState",2);	
		down=false;
		foreach(DoorTrigger trigger in doorTriggers) 
		{	if(trigger!=null)
			{	trigger.Toggle(false);
			}
		}
	}
	
	void OnDrawGizmos()
	{	Gizmos.color=sticky?Color.red:Color.green;
		foreach(DoorTrigger trigger in doorTriggers) 
		{	if(trigger!=null)
			{	Gizmos.DrawLine(transform.position,trigger.door.transform.position);
			}
		}
	}
}
