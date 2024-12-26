using Exiled.API.Interfaces;
using PlayerRoles;

namespace CustomCoinFlipActions
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        public RoleTypeId[] RandRoleList { get; set; } = 
        { 
            RoleTypeId.ClassD, 
            RoleTypeId.Spectator, 
            RoleTypeId.Scp173, 
            RoleTypeId.Scp106, 
            RoleTypeId.NtfSpecialist, 
            RoleTypeId.Scp049, 
            RoleTypeId.Scientist,
            RoleTypeId.Scp079,
            RoleTypeId.ChaosConscript,
            RoleTypeId.Scp096,
            RoleTypeId.Scp0492,
            RoleTypeId.NtfSergeant,
            RoleTypeId.NtfCaptain,
            RoleTypeId.NtfPrivate,
            RoleTypeId.FacilityGuard,
            RoleTypeId.Flamingo,
            RoleTypeId.AlphaFlamingo,
            RoleTypeId.ChaosMarauder,
            RoleTypeId.ChaosRepressor,
            RoleTypeId.ChaosRifleman,
            RoleTypeId.Scp939
        };
    }
}