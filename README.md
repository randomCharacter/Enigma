# Enigma emulator

This project is command line based [Enigma machine](https://en.wikipedia.org/wiki/Enigma_machine) emulator.

## 1. How to use
Simply run program with following parameters:  
`program reflector rotorLeft rotorCenter rotorRight staringPositions [plugboardCipher]`

`reflector` - Value of reflector to be used [`B` or `C`]  
`rotor`(Left, Right, Center) - Value of rotor to be used [`I`-`VIII`]. One rotor can not be connected to multiple places.  
`startingPositions` - Staring positions of reflector, left, center and right rotor respectively. (4 character string with capital letters)  
`plugboardCipher` - Cipher that represents plugboard connections. Contains exactly 26 non-repeatable capital letters. Every possition contains letter that represents connection with letter on coresponding position.  This argument is optional. If it is not passed, every letter will be connected to itself.

## 2. Cipher format
Every position in cipher represents the letter on that position in alphabet. Every value in cipher represents the value of letter connected to letter on given position.

![Enigma sample](http://enigma.louisedade.co.uk/wiringdiagram.png)

The folowing cipher will get the result from picture:
`ZPHNMSWCIYTQEDOBLRFKUVGXJA`

## 3. Building
### 3.1. Windows
Open project in [Visual Studio](https://visualstudio.microsoft.com/) or [Rider](https://www.jetbrains.com/rider/) and start build process.
### 3.2. Linux
Open project in [Rider](https://www.jetbrains.com/rider/) or [MonoDevelop](https://www.monodevelop.com/) and start build process. Alternatively you can use [.NET core](https://www.microsoft.com/net/download/linux).

