// Decompiled with JetBrains decompiler
// Type: SCP008X.Components.SCP008BuffComponent
// Assembly: SCP008X, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0CA3AE7C-FEE5-4B5E-93C7-C139AA2BF51C
// Assembly location: C:\Users\franc\AppData\Roaming\EXILED\Plugins\SCP008X.dll

/*using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using MEC;
using SCP008X.Handlers;
using System.Collections.Generic;
using UnityEngine;

namespace SCP008X.Components
{
    public class SCP008BuffComponent : MonoBehaviour
    {
        private Handlers.Player ply;
        private float curAHP;
        private CoroutineHandle coro;

        public void Awake()
        {
            this.ply = SCP008X.Handlers.Player.Equals(((Component)this).gameObject());
            this.coro = Timing.RunCoroutine(this.RetainAHP());
            Player.Hurting += new Exiled.Events.Events.CustomEventHandler<HurtingEventArgs>(this.WhenHurt);
        }

        public void OnDestroy()
        {
            Player.Hurting -= new Exiled.Events.Events.CustomEventHandler<HurtingEventArgs>(this.WhenHurt);
            this.ply = (Player)null;
            Timing.KillCoroutines(this.coro);
        }

        public void WhenHurt(HurtingEventArgs ev)
        {
            if (ev.get_Target() != this.ply || ev.get_Target().get_Role() != 10)
                return;
            if ((double)this.curAHP > 0.0)
                this.curAHP -= ev.Amount;
            else
                this.curAHP = 0.0f;
        }

        public IEnumerator<float> RetainAHP()
        {
            while (true)
            {
                if (this.ply.get_Role() == 10)
                {
                    if ((double)this.ply.get_AdrenalineHealth() <= (double)this.curAHP)
                    {
                        this.ply.set_AdrenalineHealth(this.curAHP);
                    }
                    else
                    {
                        if ((double)this.ply.get_AdrenalineHealth() >= (double)Plugin.Instance.get_Config().MaxAhp)
                            this.ply.set_AdrenalineHealth((float)Plugin.Instance.get_Config().MaxAhp);
                        this.curAHP = this.ply.get_AdrenalineHealth();
                    }
                }
                yield return Timing.WaitForSeconds(0.05f);
            }
        }

        public SCP008BuffComponent() => base.\u002Ector();
    }
}*/