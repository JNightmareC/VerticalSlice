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

### Question 1

<img width="768" height="634" alt="Screenshot 2026-05-27 at 2 44 19 AM" src="https://github.com/user-attachments/assets/feb18357-901c-41ff-bc6e-a7e8c1943b31" />

This can be found in the shader folder of my asset files, named "NewOutline"

There are many parts to my shader, so to start, we look at the UV adds to the sample texture, all of these areas just shift the textures around in 4 directions, up, down, left, and right. These are the bases of the outline. From all the textures, the alpha is taken from all of them (the alpha is the opaqueness of the image) to get the in general image isolated from the bacground. Then steps are applied to each individual alpha texture, which changes all the values of the textures to 1 to make sure that the collective added together outline doesnt have any values that are greater than one (this would cause a problem when color is introduced, as it would blow out the colors to be randomly bright in some areas). At one branch, all are added, lerped so that it becomes easy for me to functionally turn it on and off from my script grpahs (if the value is 0, it will only displace the origional sprites alpha, and if it is 1, then it will display alpha outline). For the other branch, all of the outlines are added to each other and we clamp the value to really re-enforce the that the backing should all be the same solid color (when color is applied). You get the Alpha of the regular sprite without the UV shifts, and subtract it from the clamped value to get a visable outline that ONLY oncludes the area around the base sprite. Color is then multiplied to it, but before it can be added to the main image, some more color treatment needs to be done. Even though the background looks as if there is basically transperent, with no other darker values, there can be, so you want to make sure you isolate them from the main sprite to make sure it doesnt effect your outline and make it way lighter or darker than it's supposed to be when you basically overlay them over each other. To fix this, I needed to use a one minus node attached to the apha, which is literally just inverting the alpha select, so we are getting the background instead of the sprite. We then need to subtract the background from the sprite to only get the pure sprite, then clamp the new sprite to make sure there are no outliers that could possibly cause another blowout. Once this is done, then you can finally add the colored outline together with the sprite, and output it to the base color fragment. 

### Question 2

The things I was able to improve on this devlog based on my playtesting feedback, was mainlly the clipping that was happening near the gate leading to the final state of the game. Before, there was a large wall of hill as a natural barrier to stop players from passing on too soon, but it became apperent that it was very, ugly to look at. So I extended the gate so you could look over to the other side, get stopped from moving on, and not have the odd world clipping issue at that point. I lowered some of the planes players walk on also, especially near where the other items to collect are so it will be easier for them to get to the items and check their descriptions.

### Question 3

I have added a lot of new content. First, I added more dialouge, new sprites, and new animations for Sunny. It added to the  gameplay loop as I had already added on NPC before, and I needed the second NPC referenced in my pitch to complete the game. Along with that, I haded to add new conditions with the already added trinkets (other than the new sprites to fully indicate what they were, whcih helps with player identification), now players get a different responce not only from Howie depending on what item you have in your inventory, but now Sunny changes her dialouge too. Another thing added was a game end state that switches after the last conversation with Sunny, it will switch to a new scene, and give a finality to the game. The final thing added was a shader that highlights the interactable item you hover over on, it was in my pitch, and in general just adds to the 4 items that were already planned to be in the gameplay loop. 


## Final Devlog
1. My main gameplay loop is as follows, talk to an NPC, get a quest, explore, find a trinket and try to match the description, bring it back to the NPC. As described in that loop, I was able to acomplish that exact loop as I had described in my full game pitch, in my verticle slice. I had 1 NPC that wouold have you go out and try to find a trinket, with clues based on what dialouge option you chose. After a player exahusted the options, they would explore the space, and inspect the only 4 interactable items in the world to see if the clues matched up. Then with each item brought back would result in a new responce from the NPC. If the NPC was given the right option, the player could then proceed to the end game state. This overall illustrates to players that if this were a full game, there would be way more areas to explore, deffinately more NPC's with different dialouge nodes to check what the player is holding, and more fetching and searchaing quests to futher complicate the player reaching the end state.
2. The rendering effects can be activated through many different places, in this responce, I'll simplify it to two, on both the items (ring, ammonite, and stardust) and both the NPC's (Howie and Sunny). They are both activated with an "on mouse over" event, that flows to a material with the same shader (differnt materials for each item and NPC). I have the material change from active to inactive based on if you change the value of one of its variables from 0 or 1 (1 is on, 0 is off). When hovered over, the value should be 1, turning on the shader. When the mouse exits the item, the material is set to 0 for that specific variable, eeffectively turning the effect off.

<img width="578" height="323" alt="Screenshot 2026-06-08 at 4 53 29 PM" src="https://github.com/user-attachments/assets/6b3b1e70-7585-4e5a-a3c6-7a92159273c8" />

And for the NPC's, It virtually the same, with a small difference considering that the effect will only specificallly render in a specific animation. When player is talking and hovered over the NPC, the material on the sprite is a regular lit one, however if it is false, then the material will be the outline material. If the mouse exits the NPC, the material is set to the regular lit one again. This one does not change any variables, but the logic is the same (with a bit more logic for specific gates).

<img width="1415" height="689" alt="Screenshot 2026-06-08 at 5 05 29 PM" src="https://github.com/user-attachments/assets/3e46f21a-40c2-4529-a83a-f0c8ab37a929" />


3. I usually break things down into both bubbles, and lists, like the one activity we did where we broke down unity system implementation into a task list. First, I break things down into bubbles, starting with all the biggest systems and mechanics that tie to them. Then if those big systems require too many components or intriquacies, then you split it up even more to account for everything. This should fully describe the ammount of work I would need to do in the first place. I like using the bubbles for that reaseon in particular, it gives a visual aid to how much needs to be made. To further see the scope of the project, I like to get one mechanic, and break it down into steps, to again, see how many things I need to interwork, how many parts of the job overlap together, how many steps I need to go through, repeat, and just do in general for only ONE system. I was able ot figure that out during my verticle slice project. i hated making bubbles, but it helped a lot for visualizing during the process, and really helped me develop and connect my vision for what I really needed. But what helped th emost, was making a astep by step proecss. I was able to follow a plan better when I made a list with tasks and steps I needed to follow. I want to repeat that scoping process that I used by mixing visuals, and stepe, because it really shaped a general web of tasks for me to do, while allowig myself to demo exactly all I needed to do.


## Open-source assets
[Handpainted grass and ground textures by Chromisu](https://assetstore.unity.com/publishers/35697) - Floor textures

[Character Template Asset Pack by ErisEsra](https://erisesra.itch.io/character-templates-pack) - PLayer stand in animations and sprite 

[Friendlyscribbles by kmlgames](https://kmlgames.itch.io/friendly-scribbles) - font

[Sprout Lands Asset pack by Cup Nooble](https://cupnooble.itch.io/sprout-lands-ui-pack) - Stand in UI for speech

[Low Poly Environment - Nature Free - LOWPOLY MEDIEVAL FANTASY SERIES by Polytope Studio](https://assetstore.unity.com/packages/3d/environments/low-poly-environment-nature-free-lowpoly-medieval-fantasy-series-187052) - nature enviroment assets and gate assets

[Pandazole - LowPoly Asset Bundle by Pandazole](https://assetstore.unity.com/packages/3d/props/pandazole-lowpoly-asset-bundle-226938) - nature assets and props (like boxes and hay bales)

[In a Dream by johnny_ripper](https://freemusicarchive.org/music/johnny_ripper/soundtrack_for_a_film_that_doesnt_exist/johnny_ripper_-_soundtrack_for_a_film_that_doesnt_exist_-_25_in_a_dream_1835/) [licence](https://creativecommons.org/licenses/by-nc-sa/3.0/) - Background music (no changes were made)

[RPG Essentials Sound Effects - FREE! by leohpaz](https://assetstore.unity.com/packages/audio/sound-fx/rpg-essentials-sound-effects-free-227708) - Footstep and collecing sound effects
