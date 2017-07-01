# Ambar
Ambar is a macOS Menu Bar app developed with Xamarin and C#. This project aims to show developing a menu bar app for macOS in C#.

<img src="https://qd31ya-sn3301.files.1drv.com/y4mv06yfcD8ljmfYDwNQfAbD0gepsrIIU51habSGhFbIYxFYW5Os7lZhuttsP9rErl6yKPCIAlCUMfwurc8lmw5WE4DxEtjo-QMxcxExjMU4B6VRUBTvVpjZX7hcHG7KmuyKD_nkvEZNWLJfaoHgIo5YplkmGPMjRR330D656Hr7lfOsRs_8BzlzPEwYojnnGbkL7dtyu58O4cc_cUvvPi1NQ?width=778&height=688&cropmode=none" width="425" height="376" />    <img src="https://pz3sya-sn3301.files.1drv.com/y4mT5cC-Z4h5vCKVvQZ81wOHZPtIfK8ptpzeuYLkGUMBZ-sjthSpnm1eleUUvaKOacmsU9oXD9laGswzsRYKcd0msIn6QQIzuZeHj71nUevzDAKg6APY3cWwa_PswMXD7WDAmtPJBYs87yywL60WusIdAvM0p0enEkEiM4aR_aZSah51PFbqFZ_8I2mJ3e3OP-3yCkYcvsUhwF-yt-Jf8Dnig?width=768&height=690&cropmode=none" width="425" height="376" />

## Why
It is for the folks wanting to start developing for macOS/iOS/tvOS/watchOS but do not want to delve into Swift/Obj-C and are already comfortable with C# and .Net technologies. 


## Tools Required
1. Visual Studio for Mac
2. Xcode


## Steps
Here is how you can do it - 
1. In Xcode, delete Window Controller Scene from `Main.storyboard` and provide Storyboard ID to View Controller.
2. Add new entry in info.plist - `Application is agent (UIElement)` with its value set to `Yes` to make the app behave as a ghost.
3. Create a Menu Bar status item using `CreateStatusItem()` method of `NSStatusBar`.
4. Handle status bar icon for dark and light theme using `Template` property of `NSImage`.
5. Handle event handling of status item using `Selector` class of `ObjCRuntime`.
6. Show a popover using `NSPopover` and its `Show()` method.
7. Make popover show on demand and hide when user moves on using `NSEvent` and a custom class.
8. In Xcode, add a button to View Controller and create an action `QuitApplication` by `control + drag`. In VS, call `Terminate` method of `NSApplication`.

Unless stated otherwise, everything is done in Visual Studio for Mac.


## To-do
- [x] Add a Contextual Menu to show options.
- [ ] Add a **Launch at Login** setting.
- [ ] Add a **About** windows.
- [ ] Advanced UI.


## Contribute
If you think this project can be improved to show more of what can be done using Xamarin and C#, you are welcome to contribute. If you build something epic using it, just let me [know](https://twitter.com/AnaghSharma).
