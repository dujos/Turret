using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	// delegates
	public delegate void OnSelectHandler (Unit unit);
	public static event OnSelectHandler OnSelected;

	public delegate void OnDeselectHandler (Unit unit);
	public static event OnDeselectHandler OnDeselected;

	public delegate void GameOverHandler ();
	public static event GameOverHandler OnGameOver;

	public delegate void LifeHandler (int value);
	public static event LifeHandler OnLifeChanged;

	private enum GameState { Start, Run, Over };
	private GameState gameState;							// GameState
	private static GameController instance;					// GameController instance

	private Unit activeUnit;								// active unit over our control

	public bool gameRun = true;

	public void Awake () 
	{
		instance = this;
	}

	// Use this for initialization
	void Start () 
	{
		gameState = GameState.Run;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		// selection 
		SelectUnit ();
		//HoverOverTurret ();
	}

	public void Enable () 
	{
	}

	public void Disable () 
	{
	}

	// end game
	public static void GameOver () 
	{
		instance.gameState = GameState.Over;

		if (OnGameOver != null)
			OnGameOver ();
	}

	// start game
	public static void GameStart ()
	{

	}

	// attemp to select turret 
	public void SelectUnit () 
	{
		// ??? how to combine multiple layers
		// turn on all layers we can do selecction
		int lmask1 = LayerMask.GetMask ("Turret");
		int lmask2 = LayerMask.GetMask ("Base");
		int lmask = lmask1 | lmask2;

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		// no turret selected
		if (!Physics.Raycast (ray, out hit, Mathf.Infinity, lmask))
			return;

		// check for double click
		float timeOffset = 0.25f;

		// we hover and click on turret
		if (Input.GetMouseButton (0)) 
		{
			OnSelectUnit (hit.collider.GetComponent<Unit> ());
        }
    }
    
    // TODO
    public void OnActiveUnit (Unit unit) 
	{
		// clear any selected turret
		ClearUnit (unit);
		
		// select new turret
		activeUnit = unit;
    }

	//	static select turret
	public static void SOnSelectUnit (Unit unit) 
	{ 
		GameController.instance.OnSelectUnit (unit);
	}

	// select turret
	public void OnSelectUnit (Unit unit) 
	{
		// clear any selected turret
		ClearUnit (unit);

		// select new turret
		activeUnit = unit;

		// notify unit it was selected
		if (OnSelected != null)
			OnSelected (unit);
	}

	// clear selected turret
	public void ClearUnit (Unit unit)
	{
		activeUnit = null;

		if () 
		{

		}
		if (OnDeselected != null)
			OnDeselected (unit);
	}

	// on hover turret
	public bool HoverOverUnit () 
	{
		int mask = LayerMask.GetMask ("Turret");
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		
		// are we hovering over unit
		if (Physics.Raycast (ray, out hit, Mathf.Infinity, mask)) 
		{
           return true;
        }
        return false;
	}
}