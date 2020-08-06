# SCP-008-X
An EXILED 2.0.x plugin for SCP:SL that adds SCP-008 into the game. This is fundamentally for server hosts that want to add more a enganging SCP-049-2 experience for their players.
# Config Options

| Name | Type | Description | Default |
| --- | --- | --- | --- |
| is_enabled | bool | Toggles the plugin | true |
| infection_chance | int | Percentage chance of infection | 25% |
| cure_chance | int | Percentage chance of being cured when using a medkit | 50% |
| buff_doctor | bool | Activate buffs for SCP-049 | false |
| zombie_health | int | Amount of health infected zombies spawn with | 300 |
| scp008_buff | int | Amount of AHP zombies spawn with and gain on each hit | 10 |
| cassie_announcement | bool | Toggles the announcement when the round starts | true |
| announcement | string | Sets the CASSIE announcement when the round starts | SCP 0 0 8 containment breach detected . Allremaining |
| zombie_damage | int | Set how much damage SCP-049-2 deals on hit | 24 |
| suicide_broadcast | string | Text that is displayed to all instances of SCP-049-2 | `null` |

## How does it work?
It will give **SCP-049-2** the ability to infect it's targets on hit. The targets will receive the `Poisoned` status effect. In order to cure the infection, you must either use `SCP-500` for a guaranteed success or gamble with a `Medkit`'s 50% chance cure rate (This chance is configurable). Players that die due to being `Poisoned` or by an attack from SCP-049-2 will spawn as SCP-049-2 as well.

This plugin is still under development and I plan to add whatever is in high demand from the plugin's users, so feel free to submit your ideas!
If something is not working as intended or outright broken, please submit an issue ticket and I'll look into it as soon as possible!
