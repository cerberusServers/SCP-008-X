# Infection
A plugin for SCP:SL that enables server hosts to toggle classes infecting their targets on kill. This plugin requires EXILED 2.x to operate.
# Config Options

| Name | Type | Description | Default |
| --- | --- | --- | --- |
| is_enabled | bool | Toggles the plugin | true |
| infection_chance | int | Percentage chance of infection | 25% |
| cassie_announcement | bool | Toggles the announcement when the round starts | true |
| zombie_damage | int | Set how much damage SCP-049-2 deals on hit | 65 |
| zombies_infect | bool | Toggles SCP-049-2 infecting targets | true |
| peanut_infects | bool | Toggles SCP-173 infecting targets | false |
| dog_infects | bool | Toggles SCP-939 infecting targets | false |
| dog_damage | int | Set how much damage SCP-939 deals on hit | 65 |

## zombie_damage and dog_damage
Something important to note of these config values is that they are INDEPENDENT from the `zombies_infect` and `dog_infects` values. This means you can have them both not be infectious and their damage values will still be in effect.

This plugin is still under development and planned to include an infection-over-time mechanic for SCP-049-2 targets, treatment system for aforementioned mechanic, and customizable cassie announcements to name a few. I also plan to add whatever is in high demand from the plugin's users, so feel free to submit your ideas!
If something is not working as intended or outright broken, please submit an issue ticket and I'll look into it as soon as possible!
