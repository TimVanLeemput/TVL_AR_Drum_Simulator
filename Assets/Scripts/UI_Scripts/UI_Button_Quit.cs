using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Button_Quit : UI_Button
{
    protected override void Execute()
    {
        ApplicationHandler.QuitGame();
    }


}
