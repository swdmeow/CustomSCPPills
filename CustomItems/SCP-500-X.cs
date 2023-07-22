using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Loader;
using InventorySystem.Items.Usables.Scp330;
using MEC;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

namespace CustomSCPPills.CustomItems
{
    [CustomItem(ItemType.SCP500)]
    public class SCP500X : CustomItem
    {
        public override uint Id { get; set; } = 1112;
        public override string Name { get; set; } = "SCP-500-X";
        public override string Description { get; set; } = "You will explode without taking any damages. ";
        public override ItemType Type { get; set; } = ItemType.SCP500;
        public override float Weight { get; set; }
        public override SpawnProperties SpawnProperties { get; set; } = null;

        ExplosiveGrenade Grenade;
        public void OnUsingItem(UsingItemEventArgs ev)
        {
            if (!CustomItem.Get(1112).Check(ev.Item)) return;

            ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE, ev.Player);
            grenade.FuseTime = 0.1f;
            grenade.SpawnActive(ev.Player.Position + Vector3.up);

            ev.IsAllowed = false;
            ev.Item.Destroy();

            Grenade = grenade;
        }
        public void OnHurting(HurtingEventArgs ev)
        {
            if(Grenade != null && ev.Player == Grenade.Owner)
            {
                ev.IsAllowed = false;

                Grenade = null;
            }
        }
    }
}