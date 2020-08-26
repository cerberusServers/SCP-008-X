using UnityEngine;
using MEC;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace SCP008X.Components
{
    public class SCP008BuffComponent : MonoBehaviour
    {
        private Player ply;
        private float curAHP = 0;
        CoroutineHandle coro;
        public void Awake()
        {
            ply = Player.Get(gameObject);
            coro = Timing.RunCoroutine(RetainAHP());
            Exiled.Events.Handlers.Player.Hurting += WhenHurt;
        }
        public void OnDestroy()
        {
            Exiled.Events.Handlers.Player.Hurting -= WhenHurt;
            ply = null;
            Timing.KillCoroutines(coro);
        }

        public void WhenHurt(HurtingEventArgs ev)
        {
            if (ev.Target != ply || ev.Target.Role != RoleType.Scp0492)
                return;

            if (curAHP > 0)
                curAHP -= ev.Amount;
            else
                curAHP = 0;
        }

        public IEnumerator<float> RetainAHP()
        {
            for(; ; )
            {
                if(ply.Role == RoleType.Scp0492)
                {
                    if (ply.AdrenalineHealth <= curAHP)
                        ply.AdrenalineHealth = curAHP;
                    else
                    {
                        if (ply.AdrenalineHealth >= Plugin.Instance.Config.MaxAhp)
                        {
                            ply.AdrenalineHealth = Plugin.Instance.Config.MaxAhp;
                        }
                        curAHP = ply.AdrenalineHealth;
                    }
                }

                yield return Timing.WaitForSeconds(0.05f);
            }
        }
    }
}
