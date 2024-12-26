using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using PlayerRoles;
using UnityEngine;
using Random = System.Random;
using Exiled.API.Features.Items;
using System.Linq;
using Exiled.API.Enums;
using MEC;

namespace CustomCoinFlipActions
{
    public class EventHandlers
    {
        public static void OnCoinFlipped(FlippingCoinEventArgs ev)
        {
            Player ply = ev.Player;
            Random random = new Random();

            var RandomChar = random.Next(0, 100);

            Timing.CallDelayed(2.5f, () =>
            {
                if (RandomChar >= 0 && RandomChar < 10)
                    KillPlayer(ply);

                if (RandomChar >= 10 && RandomChar < 20)
                    ply.Broadcast(3, "Монета исчезла!");

                if (RandomChar >= 20 && RandomChar < 30)
                    ChangeRole(ply);

                if (RandomChar >= 30 && RandomChar < 40)
                    Teleport106(ply);

                if (RandomChar >= 40 && RandomChar < 50)
                    ScpToPlayer(ply);

                if (RandomChar >= 50 && RandomChar < 70)
                    Zombiezation(ply);

                if (RandomChar >= 70 && RandomChar < 90)
                    Grenades(ply);

                if (RandomChar >= 90 && RandomChar <= 100)
                    FlashGrenades(ply);

                ply.RemoveItem(ev.Item);
            });
        }

        private static void KillPlayer(Player p)
        {
            p.Vaporize();
            
            p.Broadcast(3, "Бросок монетки дезинтегрировал вас!");
        }

        private static void ChangeRole(Player p)
        {
            p.Role.Set(Plugin.Instance.Config.RandRoleList.RandomItem(), RoleSpawnFlags.None);
            p.Broadcast(3, $"Бросок монетки превратил вас в {p.Role.Name}!");
        }

        private static void Teleport106(Player p)
        {
            Vector3 RoomPosition = Room.Get(Exiled.API.Enums.RoomType.Hcz106).Position;
           
            p.Position = RoomPosition + new Vector3(0, 2, 0.150f);
            
            p.Broadcast(3, "Бросок монетки переместил вас!");
        }

        private static void Grenades(Player p)
        {
            ExplosiveGrenade grenade = (ExplosiveGrenade)Item.Create(ItemType.GrenadeHE);
            grenade.FuseTime = 1.5f;
            
            p.Broadcast(3, "Из-за броска монетки появились осколочные гранаты!");
            
            for (int i = 0; i < 20; i++)
            {
                grenade.SpawnActive(p.Position, p);
                grenade.FuseTime = grenade.FuseTime + 0.5f;
            }
        }

        private static void FlashGrenades(Player p)
        {
            FlashGrenade grenade = (FlashGrenade)Item.Create(ItemType.GrenadeFlash);
            grenade.FuseTime = 1.0f;

            p.Broadcast(3, "Из-за броска монетки появились свето-шумовые гранаты!");

            for (int i = 0; i < 5; i++)
            {
                grenade.SpawnActive(p.Position, Server.Host);
                grenade.FuseTime = grenade.FuseTime + 0.5f;
            }
        }

        private static void ScpToPlayer(Player p)
        {
            var ScpPlayersList = Player.List.Where(ply => ply.Role.Side == Side.Scp);
            
            if (!ScpPlayersList.IsEmpty())
            {
                ScpPlayersList.ToList().RandomItem().Position = p.Position;
                p.Broadcast(3, "Бросок монетки перенес к вам SCP!");
            }
            else
            {
                p.Broadcast(3, "Монета исчезла!");
            }
        }

        private static void Zombiezation(Player p)
        {
            p.Role.Set(RoleTypeId.Scp0492);
            p.Broadcast(3, "Монета превратила вас в зомби!");
        }
    }
}
