namespace CustomSCPPills.Events
{
    using Exiled.API.Features;
    using Exiled.API.Enums;
    using CustomSCPPills;
    using System.Linq;
    using System.Collections.Generic;
    using Exiled.CustomItems.API.Features;
    using static PlayerArms;
    using Exiled.API.Features.Pickups;
    using System;
    using UnityEngine;
    using MEC;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class ServerHandler
    {
        List<RoomType> Rooms = new List<RoomType>
        {
            RoomType.Hcz939,
            RoomType.HczHid,
            RoomType.Lcz173,
            RoomType.Hcz106,
            RoomType.EzGateA,
            RoomType.EzGateB,
            RoomType.Hcz079,
            RoomType.Hcz096,
            RoomType.HczArmory,
            RoomType.LczArmory,
            RoomType.HczEzCheckpointA,
            RoomType.HczEzCheckpointB,
            RoomType.LczPlants,
            RoomType.LczToilets,
        };
        List<int> Items = new List<int>
        {
            1111,
            1112,
            1113,
            1114,
        };
        public async void OnRoundStarted()
        {
            var rand = new System.Random();

            int CountToSpawn = rand.Next(control.Instance.Config.MinNumber, control.Instance.Config.MaxNumber);

            RoomType room;
            UnityEngine.Vector3 pos;

            while (CountToSpawn != 0)
            {
                room = Rooms.ElementAt(rand.Next(0, Items.Count()));
                pos = Room.Get(Rooms.ElementAt(rand.Next(0, Items.Count()))).Transform.TransformPoint(new Vector3(0, 0, 0));

                pos.y += 2;

                CustomItem.TrySpawn(Items.ElementAt(rand.Next(0, Items.Count())), pos, out Pickup _pickup);

                Log.Debug(_pickup.ToString());

                _pickup = null;

                Rooms.Remove(room);
                Log.Debug(room.ToString());
                CountToSpawn--;

                await Task.Delay(50);
            }
        }
    }
}