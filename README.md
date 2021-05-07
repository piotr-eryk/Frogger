# Frogger
A clone of the arcade game Frogger developed by Konami (Atari 2600 Edition) built using Unity.
## Technologies
* C#
* Unity 2020.3.3f1
## Code example
An example code to show would be a function that ends a level. This code displays a stage completion message, adding points to the player based on the remaining time.

```
    private void OnStandFinishLevel()
    {
        endedGameText.gameObject.SetActive(true);
        endedLevel = true;
        CurrentScore += Math.Round(CurrentGameTime/gameTime * 100);
        endedGameText.text = "You receive: " + Math.Round(CurrentGameTime / gameTime * 100) + " points";
        CurrentGameTime = gameTime;
    }
 ```   
