using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	public Transform groundCheck;			// A position marking where to check if the player is grounded.
	public bool grounded = false;			// Whether or not the player is grounded.
	public Animator anim;					// Reference to the player's animator component.
	[HideInInspector]



	private Level levelInfo;

	public LevelInfoDisplay ui;
	public bool receiveUIInput;

	public List<PlayerState> mStates=new List<PlayerState>();
	//one instance of each state
	public RunState runState;
	public JumpState jumpState;
	public DiveState diveState;
	public SlideState slideState;
	public ChargeState chargeState;


	void Awake()
	{
		runState=new RunState(this);
      	jumpState=new JumpState(this);
      	diveState=new DiveState(this);
     	slideState=new SlideState(this);
		chargeState=new ChargeState(this);
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
		levelInfo=GameObject.FindGameObjectWithTag("LevelInfo").GetComponent<Level>();

		ui.jumpBtn.onClicked=sendUIInputState;
		ui.slideBtn.onClicked=sendUIInputState;

		mStates.Add(runState);
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.collider.gameObject.GetComponent<WorldObject>()!=null){
			col.collider.gameObject.GetComponent<WorldObject>().onPlayerCollided(this);
		}
		else if(col.collider.gameObject.GetComponent<Enemy>()!=null){
			if(mStates.Contains(chargeState)){

			}
			else{
				die();
			}
		}
	}

	public void die(){
		levelInfo.resetLevel();
	}


	void Update()
	{
		for(int i=0;i<mStates.Count;i++){
			if(receiveUIInput)
				mStates[i].handleUIInput();
			else
				mStates[i].handleInput();
		}



		bool newGrounded=Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if(grounded!=newGrounded){
			Debug.Log("Grounded changed to "+newGrounded);
			if(!mStates.Contains(jumpState) && !newGrounded){
				mStates.Add(jumpState);
				//no enter jump, this is a fall
			}

			grounded = newGrounded;
		}
		if(newGrounded && !ui.jumpBtn.isDown){
			//grounded events (remove jump and dive states)
			removeState(jumpState);
			removeState(diveState);
		}

	}


	void FixedUpdate ()
	{
		for(int i=0;i<mStates.Count;i++){
			mStates[i].update();
		}
	}

	public void addState(PlayerState _state){
		if(!mStates.Contains(_state)){
			mStates.Add(_state);
			_state.onEnterState();
		}
	}

	public void removeState(PlayerState _state){
		if(mStates.Contains(_state)){
			_state.onExitState();
			mStates.Remove(_state);
		}
	}

	public void endCharge(){
		removeState(chargeState);
	}

	public void sendUIInputState(string btnName, bool b){
		for(int i=0;i<mStates.Count;i++){
			mStates[i].receiveUIInputState(btnName,b);
		}
	}

	
	public void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
