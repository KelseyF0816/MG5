# MG5
## Devlog
1. NavMesh is useful when a character needs to find a walkable route to a destination. In a click-to-move game like League of Legends, the player picks a destination and the character finds a route around obstacles. In a physics-based platformer, gravity, jump velocity, and collisions determine how the character moves and whether they land on a platform, so physics-based movement makes more sense.

2. Every frame, the loop checks each bird in _birds, starting at index 0 and ending at _birds.Length - 1. Vector3.Distance measures the straight-line distance between that bird and the player in 3D. Every bird whose distance is less than or equal to _interactDistance (3 Unity units in my scene) calls RunAway(). If multiple birds are in range at the same time, they all run away.

## Open-Source Assets
- [Quirky animal 3D models](https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-free-animals-pack-178235)
- [Mountain fantasy environment models](https://www.fab.com/listings/60487a72-3f20-4bb2-aa78-247ed1582656)