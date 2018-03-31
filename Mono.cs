using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AntiJumpX2
{
    public class Mono : MonoBehaviour
    {
        public DateTime LastAltPush;
        public DateTime LastSpacePush;
        public Vector3 LastPlayerLocation;

        public void Update()
        {
            if (Controllable.localPlayerControllableExists)
            {
                var pl = PlayerClient.GetLocalPlayer().controllable.GetComponent<Character>();

                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {
                    LastPlayerLocation = pl.transform.position;
                    LastAltPush = System.DateTime.Now;

                    //Rust.Notice.Inventory("","LeftALT" + LastAltPush.ToString());//
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Rust.Notice.Inventory("", "Space" + LastSpacePush.ToString());
                    LastSpacePush = System.DateTime.Now;
                    TimeSpan ts = LastSpacePush - LastAltPush;
                    if (ts.Seconds < 2)
                    {
                        //quizas aqui deba de comprobar que el jugador no este mas lejos de 100m entr las 2 posiciones registradas para evitar confundirse con un TP

                        // /////////////////////

                        pl.ccmotor.Teleport(new Vector3(LastPlayerLocation.x, LastPlayerLocation.y, LastPlayerLocation.z));
                        //Rust.Notice.Popup("", "-2 segundos detectados " + ts.Seconds.ToString());
                        Rust.Notice.Popup("", "Super Jump are Blocked");
                    }
                }
            }
        }
    }
}
