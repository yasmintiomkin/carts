using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace KartGame.KartSystems {

    public class KeyboardInput : BaseInput
    {
        public string Horizontal = "Horizontal";
        public string Vertical = "Vertical";
        public Joystick joystick;



        public override Vector2 GenerateInput() {
            return new Vector2 {
                x = joystick.Horizontal,
                y = joystick.Vertical
            };
        }
    }
}
