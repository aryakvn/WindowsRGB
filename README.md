# WindowsRGB

WindowsRGB is a Windows desktop application written in C# that analyzes the edges of your computer screen and calculates the average RGB color values for each segment. It is designed specifically to drive "edge lighting" effects using Arduino and WS2812 (NeoPixel) LEDs—so the colors displayed on the edges of your monitor can be mirrored onto addressable LEDs mounted around your display.

## Features

- **Edge Color Analysis**: Captures a screenshot of the current screen and divides each edge (top, bottom, left, right) into configurable segments, calculating the average color for each.
- **Configurable Segments**: Set the number of horizontal (`numWidth`) and vertical (`numHeight`) segments for color sampling.
- **Live Updates**: Updates color output periodically using a timer for smooth ambient effects.
- **GUI Controls**: Checkboxes to enable/disable analysis for each edge; numeric controls to set segment counts.
- **Visual Preview**: The application displays the processed edge colors for preview.

## Arduino Integration

This project is intended to be used with an Arduino and WS2812 (NeoPixel) LED strips. The application analyzes your screen and determines what colors the LEDs around your monitor should display for a dynamic "ambilight" experience.

To connect to Arduino:
- You will need to write or adapt Arduino firmware that receives color data from your PC (typically over serial/USB).
- The WindowsRGB application can be extended to transmit the color data to Arduino in the format your firmware expects.

## Getting Started

### Prerequisites

- Windows OS
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) (version depends on project settings)
- Visual Studio or compatible C# IDE
- Arduino board (e.g., Uno, Nano, etc.)
- WS2812 (NeoPixel) LED strips

### Build & Run

1. Clone the repository:
   ```
   git clone https://github.com/aryakvn/WindowsRGB.git
   ```
2. Open the solution in Visual Studio.
3. Build the project.
4. Run the application.

### Usage

- Click "Start" to begin live color updates.
- Adjust the segment width and height using the numeric controls.
- Enable/disable edge analysis using the checkboxes.
- The preview window will show the current edge colors.
- (To send data to Arduino, you’ll need to implement serial communication and update your Arduino code accordingly.)

## Contributing

Contributions, issues, and feature requests are welcome! Open an issue or submit a pull request.

## License

No license information is currently specified.

## Author

- [aryakvn](https://github.com/aryakvn)

---

*This project is for educational and experimental purposes. For hardware integration (controlling RGB LEDs via Arduino), you will need to implement serial communication and compatible Arduino firmware.*
