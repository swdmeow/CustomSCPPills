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
using MEC;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

namespace CustomSCPPills.CustomItems
{
    [CustomItem(ItemType.SCP500)]
    public class SCP500SG : CustomItem
    {
        public override uint Id { get; set; } = 1111;
        public override string Name { get; set; } = "SCP-500-SG";
        public override string Description { get; set; } = "Spawns 1x Crossvec, 1x MTF-E11-SR, 1x Shotgun.";
        public override ItemType Type { get; set; } = ItemType.SCP500;
        public override float Weight { get; set; }
        public override SpawnProperties SpawnProperties { get; set; } = null;
        public void OnUsingItem(UsingItemEventArgs ev)
        {
            if (!CustomItem.Get(1111).Check(ev.Item)) return;

            Pickup.CreateAndSpawn(ItemType.GunCrossvec, ev.Player.Position, new Quaternion(0, 0, 0, 0));
            Pickup.CreateAndSpawn(ItemType.GunE11SR, ev.Player.Position, new Quaternion(0, 0, 0, 0));
            Pickup.CreateAndSpawn(ItemType.GunShotgun, ev.Player.Position, new Quaternion(0, 0, 0, 0));

            ev.IsAllowed = false;
            ev.Item.Destroy();
        }
    }
}