# GDIM33 Vertical Slice
## Milestone 1 Devlog
1. One of the most importaint visual scripting graphs that I made was the Item graph. This graph does mainly two major things. It has an on mouse over, and an on mouse exit that utilizes a set material mesh renderer that gets the variable of the current material of the object. It then changes it to change it to a differnt color when hovered over, and then back to it's origional color when it hovers over it. It also triggers a small descriptin TMP game object to become visable when hovered over, and toggled off when exited. The other thing that this graph does, it to use an on mouse up to trigger adding the item you click into the players inventory list, a scene variable. It does theis by getting the item clicked, adding the object the graph is connected to into the list, triggers a custom event to the player so it can display a notification above their head, calls from the Full Dialouge script to trigger a special dialouge reaction from the NPC, and then sets the clicked object to inactive so you can't see it anymore.
2. <img width="1733" height="1214" alt="My breakdown #3" src="https://github.com/user-attachments/assets/66aeaaa0-4e15-4805-b44a-08fc6539bea7" />

This state machine mainly works to change the player character's animation to fit whatever the player is doing, specifically when it comes to movement. It controls walking forward towasrds the camera, away from the camera, and to the left and right within the cameras confines. Currently, this state machine is only effected (as seen in the picture) by the player scripting graph. Whatever the player input is, which is attached to the player game object as a component is triggered active, then the idle state (a looping animation) is left and enters the walking state. It is only exited when nothing is being pressed anymore. Mainly so far, it only will effect the player, and prosepcted (later on in this project) to only effect the NPC indicidually in an aesthetic sense.  



## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
