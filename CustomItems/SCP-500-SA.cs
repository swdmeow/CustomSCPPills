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
    public class SCP500SA : CustomItem
    {
        public override uint Id { get; set; } = 1114;
        public override string Name { get; set; } = "SCP-500-SA";
        public override string Description { get; set; } = "Spawns 200x 9mm, 5.56mm, 7.62mm and 30x 12/70 buckshot.";
        public override ItemType Type { get; set; } = ItemType.SCP500;
        public override float Weight { get; set; }
        public override SpawnProperties SpawnProperties { get; set; } = null;
        public void OnUsingItem(UsingItemEventArgs ev)
        {
            if (!CustomItem.Get(1114).Check(ev.Item)) return;

            ev.Player.AddAmmo(Exiled.API.Enums.AmmoType.Nato9, 200);
            ev.Player.DropAmmo(Exiled.API.Enums.AmmoType.Nato9, 200, false);

            ev.Player.AddAmmo(Exiled.API.Enums.AmmoType.Nato556, 200);
            ev.Player.DropAmmo(Exiled.API.Enums.AmmoType.Nato556, 200, false);

            ev.Player.AddAmmo(Exiled.API.Enums.AmmoType.Nato762, 200);
            ev.Player.DropAmmo(Exiled.API.Enums.AmmoType.Nato762, 200, false);

            ev.Player.AddAmmo(Exiled.API.Enums.AmmoType.Ammo12Gauge, 30);
            ev.Player.DropAmmo(Exiled.API.Enums.AmmoType.Ammo12Gauge, 30, false);

            ev.IsAllowed = false;
            ev.Item.Destroy();
        }
    }
}