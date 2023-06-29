
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public StateType currentState;
    public static GameManagerScript instance;
    //cai ma singleton la 1 script?

    //Instance o day la property, k phai field
    // (nen dang sau Instance k co () nhu mot ham binh thuong?)
    public static GameManagerScript Instance
    {
        //get va set mac dinh cua property?
        get
        {
            if (instance == null)
            {
                instance = new GameManagerScript();
            }

            return instance;
        }
        //.Instance k goi den instance ma goi den .getInstance()
    }
    public void ChangeGameState(StateType newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case StateType.INTRO:
                break;
            case StateType.LOADING:
                break;
            case StateType.MENU:
                break;
            case StateType.PLAY:
                break;
            case StateType.GAMEOVER:
                break;
        }
    }

    public enum StateType
    {
        INTRO,
        LOADING,
        MENU,
        PLAY,
        GAMEOVER
    };
}