# Infection
A plugin for SCP:SL that enables server hosts to toggle classes infecting their targets on kill. This plugin requires EXILED 2.x to operate.
# Config Options

| Name | Type | Description | Default |
| --- | --- | --- | --- |
| is_enabled | bool | Toggles the plugin | true |
| infection_chance | int | Percentage chance of infection | 25% |
| cure_chance | int | Percentage chance of being cured when using a medkit | 50% |
| buff_doctor | bool | Activate buffs for SCP-049 | false |
| infected_health | int | Amount of health infected targets spawn with | 1500 |
| zombie_health | int | Amount of health infected zombies spawn with | 225 |
| cassie_announcement | bool | Toggles the announcement when the round starts | true |
| zombie_damage | int | Set how much damage SCP-049-2 deals on hit | 65 |
| zombies_infect | bool | Toggles SCP-049-2 infecting targets | true |
| zombie_suicides | bool | Toggles whether SCP-049-2 can suicide | false |
| suicide_broadcast | string | Text that is displayed to all instances of SCP-049-2 | SCP-049-2 is not allowed to suicide on this server! |
| peanut_infects | bool | Toggles SCP-173 infecting targets | false |
| dog_infects | bool | Toggles SCP-939 infecting targets | false |
| dog_damage | int | Set how much damage SCP-939 deals on hit | 65 |

## How does it work?
It will give **SCP-049-2** the ability to infect it's targets on hit. The targets will receive the `Poisoned` status effect. In order to cure the infection, you must either use `SCP-500` for a guaranteed success or gamble with a `Medkit`'s 50% chance cure rate (This chance is configurable). Players that die due to being `Poisoned` or by an attack from SCP-049-2 will spawn as SCP-049-2 as well. The other infectious SCPs you enable will only "infect" their targets before they die, meaning you will have to kill your prey for a chance to infect them.

This plugin is still under development and I plan to add whatever is in high demand from the plugin's users, so feel free to submit your ideas!
If something is not working as intended or outright broken, please submit an issue ticket and I'll look into it as soon as possible!
