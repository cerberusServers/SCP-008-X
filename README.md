# Infection
A plugin for SCP:SL that enables server hosts to toggle classes infecting their targets on kill. This plugin requires EXILED 2.x to operate.
# Config Options

| Name | Type | Description | Default |
| --- | --- | --- | --- |
| is_enabled | bool | Toggles the plugin | true |
| infection_chance | int | Percentage chance of infection | 25% |
| infected_health | int | Amount of health infected targets spawn with | 1500 |
| cassie_announcement | bool | Toggles the announcement when the round starts | true |
| zombie_damage | int | Set how much damage SCP-049-2 deals on hit | 65 |
| zombies_infect | bool | Toggles SCP-049-2 infecting targets | true |
| zombie_suicides | bool | Toggles whether SCP-049-2 can suicide | false |
| suicide_broadcast | string | Text that is displayed to all instances of SCP-049-2 | SCP-049-2 is not allowed to suicide on this server! |
| peanut_infects | bool | Toggles SCP-173 infecting targets | false |
| dog_infects | bool | Toggles SCP-939 infecting targets | false |
| dog_damage | int | Set how much damage SCP-939 deals on hit | 65 |

## zombie_damage and dog_damage
Something important to note of these config values is that they are INDEPENDENT from the `zombies_infect` and `dog_infects` values. This means you can have them both not be infectious and their damage values will still be in effect.

## infected_health
Please note that SCP-049-2 are currently unaffected by this value since they are already extremely weak. As it stands, those infected by SCP-049-2 will spawn with **225** HP. All other infectious SCPs will spawn with the amount of HP you configure with this option. This will allow you to make the main-line infected instances of SCP-173 and SCP-939 either weaker or even stronger than the original.

## SCP-049-2 Suicide Prevention
Server owners can decide whether or not to allow SCP-049-2 to kill itself with this feature. A configurable broadcast will also be displayed on their screen to notify them that suiciding is against server rules.

This plugin is still under development and planned to include an infection-over-time mechanic for SCP-049-2 targets, treatment system for aforementioned mechanic, and customizable cassie announcements to name a few. I also plan to add whatever is in high demand from the plugin's users, so feel free to submit your ideas!
If something is not working as intended or outright broken, please submit an issue ticket and I'll look into it as soon as possible!
