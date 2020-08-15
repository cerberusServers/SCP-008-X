

namespace SCP008X
{
    public static class Extensions
    {
        public static bool IsSCP(this RoleType Role, bool OnlySCPs)
        {
            if (OnlySCPs)
            {
                switch (Role)
                {
                    case RoleType.Scp049:
                    case RoleType.Scp0492:
                    case RoleType.Scp079:
                    case RoleType.Scp096:
                    case RoleType.Scp106:
                    case RoleType.Scp173:
                    case RoleType.Scp93953:
                    case RoleType.Scp93989:
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                switch (Role)
                {
                    case RoleType.Scp049:
                    case RoleType.Scp0492:
                    case RoleType.Scp079:
                    case RoleType.Scp096:
                    case RoleType.Scp106:
                    case RoleType.Scp173:
                    case RoleType.Scp93953:
                    case RoleType.Scp93989:
                    case RoleType.Spectator:
                    case RoleType.None:
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
}
