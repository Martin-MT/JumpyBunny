using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 *  1) Menu
 *  2) InGame
 *  3) GameOver
 *  4) Pause
 */

public enum GameState
{
    Menu,
    InGame,
    GameOver,
    Resume
}
public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.Menu;
    private static GameManager sharedInstance;

    private void Start(){
        currentGameState = GameState.Menu;
    }

    private void Update(){
        if (Input.GetButtonDown("s"))
        //if (Input.GetKeyDown(KeyCode.S))
        {
            StartGame();
        }
    }
    private void Awake()
    {
        sharedInstance = this;
    }

    public static GameManager GetInstance()
    {
        return sharedInstance;
    }
    public void StartGame()
    {
        ChangeGameState(GameState.InGame);        
    }

    // Called when player dies
    public void GameOver()
    {
        ChangeGameState(GameState.GameOver);
    }

    // When the player leaves the game to go to the main menu
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.Menu);
    }

    void ChangeGameState(GameState newGameState)
    {
        switch(newGameState){
            case GameState.InGame:
                // Unity scene should show the real scene
                break;

            case GameState.Menu:
                // Load the menu scene
                break;

            case GameState.GameOver:
                // Load the end of the game scene
                break;
            
            default:
                currentGameState = GameState.Menu;
                break;
        }
        currentGameState = newGameState;
    }
}
