using System;
using Exiled.API.Features;

namespace CustomCoinFlipActions
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "sky3z";

        public override string Name => "CustomCoinFlipActions";

        public override string Prefix => "CustomCoin";

        public override Version Version => base.Version;

        public static Plugin Instance;

        public static EventHandlers EventHandlers;

        public override void OnEnabled()
        {
            base.OnEnabled();
            var EventHandlers = new EventHandlers();
            Instance = this;
            
            Exiled.Events.Handlers.Player.FlippingCoin += EventHandlers.OnCoinFlipped;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Instance = null;
            
            Exiled.Events.Handlers.Player.FlippingCoin -= EventHandlers.OnCoinFlipped;
        }
    }
}
