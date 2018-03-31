using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RustBuster2016;
using UnityEngine;

namespace AntiJumpX2
{
    public class AntiJumpX2Class : RustBuster2016.API.RustBusterPlugin
    {
        public override string Name { get { return "AntiJumpX2"; } }
        public override string Author { get { return " by salva/juli"; } }
        public override Version Version { get { return new Version("1.0"); } }

        public Mono MonoClass;
        public GameObject monoClassLoad;
        public static AntiJumpX2Class Instance;

        public override void Initialize()
        {
            Instance = this;
            if (this.IsConnectedToAServer)
            {
                monoClassLoad = new GameObject();
                MonoClass = monoClassLoad.AddComponent<Mono>();
                UnityEngine.Object.DontDestroyOnLoad(monoClassLoad);
                return;
            }
        }
        public override void DeInitialize()
        {
            if (monoClassLoad != null) UnityEngine.Object.DestroyImmediate(monoClassLoad);
        }
    }
}
