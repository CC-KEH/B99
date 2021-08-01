using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public enum ComboState
    {
        NONE,
        Punch1,
        Punch2,
        Punch3,

        Kick1,
        Kick2,
    }

    private bool ActivateTimerToReset;
    private float default_Combo_Timer=0.4f;
    private float current_Combo_Timer;

    private ComboState currentComboState;

    private characterAnimation player_animation;
    void Start()
    {
        current_Combo_Timer=default_Combo_Timer;
        currentComboState=ComboState.NONE;
        currentComboState=(ComboState)1;
    }

    void Awake() {
        player_animation=GetComponentInChildren<characterAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttack();
        resetComboState();
    }

    void ComboAttack(){
        if(Input.GetKeyDown(KeyCode.Z)){

            if(currentComboState==ComboState.Punch3||currentComboState==ComboState.Kick1||currentComboState==ComboState.Kick2){
                return;
            }
            currentComboState++;
            ActivateTimerToReset=true;
            current_Combo_Timer=default_Combo_Timer;

            if(currentComboState==ComboState.Punch1){
                player_animation.Punch1();
            }
            if(currentComboState==ComboState.Punch2){
                player_animation.Punch2();
            }
            if(currentComboState==ComboState.Punch3){
                player_animation.Punch3();
            }
        }
        if(Input.GetKeyDown(KeyCode.X)){
            if(currentComboState==ComboState.Punch3||currentComboState==ComboState.Kick2){
                return;
            }

            if(currentComboState==ComboState.NONE||currentComboState==ComboState.Punch1||currentComboState==ComboState.Punch2){
                currentComboState=ComboState.Kick1;
            }
            else if(currentComboState==ComboState.Kick1){
                currentComboState++;
            }

            ActivateTimerToReset=true;
            current_Combo_Timer=default_Combo_Timer;

            if(currentComboState==ComboState.Kick1){
                player_animation.Kick1();
            }
            if(currentComboState==ComboState.Kick2){
                player_animation.Kick2();
            }
        }
    }

    void resetComboState(){
        if(ActivateTimerToReset){
            current_Combo_Timer-=Time.deltaTime;

            if(current_Combo_Timer<=0f){
                currentComboState=ComboState.NONE;
                ActivateTimerToReset=false;
                current_Combo_Timer=default_Combo_Timer;
            }
        }
    }
}
