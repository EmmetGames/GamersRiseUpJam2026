# GamersRiseUpJam2026
Birthday game jam!

## Game Summary
A puzzle game where you run an adventuring guild and help match compatible adventurers to form parties!

> **Disclaimer**
> I'm writing these notes haphazardly and these are just my initial ideas - let's do whatever we feel like lol

## Style
2D Top-Down pixelart visuals, similar to Zelda Link to the Past, or more recently Moonlighter

## Gameplay
The game is divided into levels.
You see your guild (tavern-looking large room with tables and chairs) and a bunch of adventurers populating it. The camera is fixed and showing the entire room.
The characters have speech bubbles above their heads with an icon telling you their want.
> For example - a character can have a sword above their head, indicating they're looking for a fighter.
Clicking on them opens a menu on the side with more context as to who they are and what they want/don't want.
They're also highlighted when selected.
With the character selected, clicking on a table moves the character to that table. This makes them "party" with the people already seated at the table.
Clicking on a table highlights the table and the side menu has stats on the table - who's part of it and how compatible everyone is.
> I'm imagining this would be shown in a list like:
> + X likes that Y is a warrior
> + Y likes that Z is brave
> - Y dislikes that X is a wizard
At the bottom of the screen there's an "End day" button. Pressing it completes the level.
We then see a summary of how well the parties did (I think based on their compatibility + some RNG) and then the commission we get from them, based on their success.
There's a minimum threshold of rent we need to pay, so if we did too bad we can't afford rent - and lose the game.
If we lost - we replay the level.
If we won - we move to the next level.

## Adventurers
Adventurers are a base character repainted and given props to look different.
Possible configuration options are:
- Their skin color
- The item in their hand
- Their clothing

These are just visual elements. Beyond that, they have "stats". These can be:
- Name
- Race
- Class
- Item
- Personality
- Skill
> Ideally the item matches the visually rendered item. If it doesn't because we have no time, it's best to not show a held item visually at all.

## Puzzle Design
The difficulty of the puzzle comes from how hard it is to find compatible party members.
The difficulty can thus be controlled by:
- How many "optimal" solutions there are
- If we make the player pick "the lesser of two evils" when arranging parties
- The amount of adventurers
- The amount of categories to take into account
- The amount of preferences an adventurer has

While it would be possible to write algorithms to make the puzzles, it'll probably be best for us to just come up with pre-determined puzzle scenarios.
If we want to make an inviting puzzle experience, every level should make you use your knowledge from the previous level to win.

- The first level should force user input but be very hard to lose. It should introduce the idea that you group adventurers together
- The second level should have two parties that initially start incompatible. This level will teach the player that placing adventurers based on their preferences increases the party compatibility.
- The third level should introduce adventurers having DISLIKES - things they want to AVOID. We can probably also increase the amount of parties.
- Fourth level - introduce new parameters? (I'm imagining until now it was class. Now we introduce personality?)
- Escalate from there basically

## Systems & Views
### Main Game Scene
- A 2D guild room with chairs, tables, and other things too so it doesn't look barren (but make sure it doesn't distract from the interactible elements!)
- Clickable adventurers, which are highlighted when clicked (they can be rendered facing front only but it'd be cool if they faced the sides too!)
    - Adventurers have clothes, items, and different skin colors (as described above).
- Clickable tables, which are highlighted when clicked. They have chairs around them that characters snap to.
- Speech bubbles above adventueres to show us their needs at a glance
- A button at the bottom-right of the screen to end the day
- Info UI that shows up when a character or table is clicked to show full info
> We should be careful for this UI to ideally not cover the whole screen, so the player can look at the rest of the tables. It should ideally also not cover any tables. Maybe it should have a dedicated space on the screen, like the UI of RTS games?
- It would be cool if instead of clicking on characters then on tables, you'd instead drag them to the table they should go on. It'd look great if they got dragged around and rotated with physics as you do.

### Day Summary screen
- Could be a simple text summary of the day (would look nicer if lines were added with delays)
- Would look way cooler if there was some image instead, showing the adventurers, the monster they fought, and the treasure pile they found
- In any case - should tell the player how well the different parties did and how much gold they ended up with
- It should then show the rent gold deducted from the player's balance
- And based on that show if they won or lost
- Add some minimal transition to and from the day summary screen?

### Main Menu
- Logo
- Some cool background
- Play button
- Quit button
- Audio toggle?
- Credit button?