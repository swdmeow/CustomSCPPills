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
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;
using System;

namespace CustomSCPPills.CustomItems
{
    [CustomItem(ItemType.SCP500)]
    public class SCP500T : CustomItem
    {
        public override uint Id { get; set; } = 1113;
        public override string Name { get; set; } = "SCP-500-T";
        public override string Description { get; set; } = "You can teleport to a different zone with this pill.";
        public override ItemType Type { get; set; } = ItemType.SCP500;
        public override float Weight { get; set; }

        private List<Room> RandRoomsList = new List<Room>();
        public override SpawnProperties SpawnProperties { get; set; } = null;
        public void OnUsingItem(UsingItemEventArgs ev)
        {
            if (!CustomItem.Get(1113).Check(ev.Item)) return;

            var rand = new System.Random();

            foreach(Room room in Room.List)
            {
                if(room.Type != RoomType.HczTestRoom && room.Type != RoomType.HczTesla)
                {
                    if (room.Zone != ev.Player.Zone)
                    {
                        RandRoomsList.Add(room);
                    }
                }
            }
            Vector3 pos = RandRoomsList.ElementAt(rand.Next(0, RandRoomsList.Count())).Position;

            pos.y += 2;

            ev.Player.Position = pos;

            RandRoomsList.Clear();

            ev.IsAllowed = false;
            ev.Item.Destroy();
        }
    }
}