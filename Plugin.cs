namespace CustomSCPPills
{
    using Exiled.API.Features;
    using System;
    using Exiled.CustomItems.API.Features;
    using Exiled.CustomItems;
    using Exiled.CustomRoles.API.Features;
    using CustomSCPPills.Events;
    using CustomSCPPills.CustomItems;
    using Exiled.Events.Handlers;
    using Handlers = Exiled.Events.Handlers;

    public class control : Plugin<Config>
    {
        private static readonly control Singleton = new();

        public override string Name => "CustomSCPPills";
        public override string Author => "swd";
        public override System.Version Version => new System.Version(1, 0, 0);

        private CustomSCPPills.Events.ServerHandler ServerHandler;

        private CustomSCPPills.CustomItems.SCP500T SCP500T;
        private CustomSCPPills.CustomItems.SCP500SA SCP500SA;
        private CustomSCPPills.CustomItems.SCP500SG SCP500SG;
        private CustomSCPPills.CustomItems.SCP500X SCP500X;

        private control()
        {

        }

        public static control Instance => Singleton;
        public override void OnEnabled()
        {
            SCP500T = new CustomSCPPills.CustomItems.SCP500T();
            SCP500X = new CustomSCPPills.CustomItems.SCP500X();
            SCP500SG = new CustomSCPPills.CustomItems.SCP500SG();
            SCP500SA = new CustomSCPPills.CustomItems.SCP500SA();

            ServerHandler = new CustomSCPPills.Events.ServerHandler();

            CustomItem.RegisterItems();

            RegisterCustomItemsEvents();

            RegisterEvents();
            
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            CustomItem.UnregisterItems();

            UnRegisterCustomItemsEvents();

            UnRegisterEvents();

            ServerHandler = null;
            SCP500SA = null;
            SCP500SG = null;
            SCP500X = null;
            SCP500T = null;

            base.OnDisabled();
        }
        public void RegisterCustomItemsEvents()
        {
            Handlers.Player.UsingItem += SCP500SG.OnUsingItem;
            Handlers.Player.UsingItem += SCP500SA.OnUsingItem;

            Handlers.Player.Hurting += SCP500X.OnHurting;
            Handlers.Player.UsingItem += SCP500X.OnUsingItem;

            Handlers.Player.UsingItem += SCP500T.OnUsingItem;
        }
        public void RegisterEvents()
        {
            Handlers.Server.RoundStarted += ServerHandler.OnRoundStarted;
        }
        public void UnRegisterEvents()
        {
            Handlers.Server.RoundStarted -= ServerHandler.OnRoundStarted;
        }
        public void UnRegisterCustomItemsEvents()
        {
            Handlers.Player.UsingItem -= SCP500SA.OnUsingItem;
            Handlers.Player.UsingItem -= SCP500SA.OnUsingItem;
            Handlers.Player.UsingItem -= SCP500X.OnUsingItem;
            Handlers.Player.UsingItem -= SCP500T.OnUsingItem;
        }
    }
}