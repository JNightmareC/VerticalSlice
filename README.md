# GDIM33 Vertical Slice
## Milestone 1 Devlog
1. One of the most importaint visual scripting graphs that I made was the Item graph. This graph does mainly two major things. It has an on mouse over, and an on mouse exit that utilizes a set material mesh renderer that gets the variable of the current material of the object. It then changes the material to a differnt color when hovered over, and then back to it's origional color when it exits the on hover over. It also triggers a small descriptin TMP game object to become visable when hovered over, and toggled off when exited. The other thing that this graph does, it to use an on mouse up to trigger adding the item you click on, into the players inventory list (a scene variable). It does this by getting the item clicked (gameobject), adding the object the graph is connected to into the list, triggers a custom event to the player so it can display a notification above their head, calls from the Full Dialouge script to trigger a special dialouge reaction from the NPC, and then sets the clicked object to inactive so you can't see it anymore.
2.
<img width="1960" height="1015" alt="My breakdown #5" src="https://github.com/user-attachments/assets/ed3aee3e-205f-4559-85a9-d89e1c216efb" />

This state machine mainly works to change the player character's animation to fit whatever the player is doing, specifically when it comes to movement. It has two states it can be active in a different times, either the Idle state, which is when the player has no input in what the character is doing, and the walking state, which playes a movement animation when the player is pressing WASD. It controls walking forward towasrds the camera, away from the camera, and to the left and right within the cameras confines. Currently, this state machine is only effected (as seen in the picture) by the player scripting graph. Whatever the player input is, which is attached to the player game object as a component is triggered active, then the idle state (a looping animation) is left and enters the walking state. It is only exited when nothing is being pressed anymore. Mainly so far, it only will effect the player, and prosepcted (later on in this project) to only effect the NPC indicidually in an aesthetic sense.  



## Milestone 2 Devlog
### Question 1
Basic breakdown:

1.  make a state machine on the Item game object that controls/ calls the special nodes of the dialogue controller
2.  Code in the dialogue controller methods that depending on what item is being added to inventory, trigger an set a new node state to set to the NPC’s default conversation to
3.  Add transition gates to transfer into 3 different types of nodes, each item will have their own respective node attached to them, if multiple are grabbed they have a shared generic, and if the correct item is grabbed then it triggers a new area to be opened 

Detailed breakdown:

1. Make a state machine on the Items that will have the advanced branches 
2. Have there be 1 “regular” node that contains a regular dialogue set that repeats and tells the player to “go get” the item asked for
3. Have there be 4 item branches, that connect to regular. Each of those have a transition entering them that checks to see if the specific item is being held, and is ONLY being held
4. Have one “multiple” state that is funneled into when multiple items are in the inventory except the correct one, the conditions is a large or statement 
5. And one final state that checks if an item with the name “correct item” is in the list of game objects to run a congratulatory node and to open the gate to let you through and reach the “end” of the game (the star dust also does this)
6. Go into the full dialogue c# code you do have and add 6 different methods, each should check off these things, 
    1. Waiting for player response is false 
    2. Current node has to be triggered to the node associated with what you want the NPC response to be
    3. And the bool associated with the condition is set to true 
7. Then go into the advance dialogue and in the else condition when player isn’t talking to the NPC, add all the bools as if and else if statements, reinforcing and locking in the node 
8. In the main unity scene, create all new nodes for dialogue, and add them to the “dialogue different node states” variable so their numbers can be called to 
9. In the Items state machine, fill in the nodes to trigger when entered and call the method corresponding to it in script
10. In the transitions, fill them in with an on update check of the list containing all the items to see if the required item is in there to move onto the next state
### Question 2
My breakdown was actually really helpful with what I was doing, as it gave me a really good baseline blueprint of what I was going to make. It was helpful because it let me get my thoughts out and really concept how I would structure and build everything. I had to consider my scale, if I had to research anyting, and if I had all the peices nessissariy to actualy start or continue. I think to improve my breakddown in the future by maybe elaborating on the exact object the component/ script would be on, along with going into a bit more detail with exactly what I would need on other scripts what any specific object object would need in order to get data, or interact with the item the specific script is attached to. I left that vauge and I got quite confused trying to figure that out as I was actually building the concepted peice.  

### Question 3
I was able to bridge both of those by being able to call meathods in a dialouge script called "Full Dialouge", from a state graph called "Items" to control conversations gates based in what the player is holding in their inventory. The purpose this serves is to take strain off of me having to hard code everything in a certain way, and it was much easier to control with very specifc conditions I knew players would put themselves into (it was also just much better to visualize, set up, and debuga than it would have been in hard code). I was able to trigger and make gates for certain conversation states, and in terms of my architecture, I want to make sure to keep options open to trigger new animations states with the NPC through them, or to trigger a sound effect, just making things more versatile in terms of interactivity. 
<img width="1504" height="783" alt="Screenshot 2026-05-11 at 7 33 27 PM" src="https://github.com/user-attachments/assets/67cd9db6-6daa-4d52-b0a6-807c1f833e1d" />
<img width="585" height="330" alt="Screenshot 2026-05-11 at 7 34 02 PM" src="https://github.com/user-attachments/assets/4823f8e3-99c0-4219-81a7-77c08a0c0b52" />


### Question 4
The unity system I used was the scriptabe objects. They can be found attached to the only NPC present so far, in a dedicated folder, and referenced in 3 Dialouge realted scripts (and graphs, these being Dialoge Node, DialougeUI, Full Dialouge, Yippie Creature state graph, and Items state graoh).

## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
[Handpainted grass and ground textures by Chromisu](https://assetstore.unity.com/publishers/35697) - Floor textures

[Character Template Asset Pack by ErisEsra](https://erisesra.itch.io/character-templates-pack) - PLayer stand in animations and sprite 

[Friendlyscribbles by kmlgames](https://kmlgames.itch.io/friendly-scribbles) - font

[Sprout Lands Asset pack by Cup Nooble](https://cupnooble.itch.io/sprout-lands-ui-pack) - UI for speech

[Low Poly Environment - Nature Free - LOWPOLY MEDIEVAL FANTASY SERIES by Polytope Studio](https://assetstore.unity.com/packages/3d/environments/low-poly-environment-nature-free-lowpoly-medieval-fantasy-series-187052) - nature enviroment assets
