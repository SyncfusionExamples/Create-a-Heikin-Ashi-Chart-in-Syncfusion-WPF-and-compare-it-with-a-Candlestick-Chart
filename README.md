# Create-a-Heikin-Ashi-Chart-in-Syncfusion-WPF-and-compare-it-with-a-Candlestick-Chart
## Overview
This project demonstrates how to create a Heikin-Ashi Chart using Syncfusion WPF SfChart and compare it with a traditional Candlestick Chart. The implementation includes Heikin-Ashi formula calculations, custom rendering, and additional features like trackball labels, theme customization, and axis formatting.

Heikin-Ashi charts help traders smooth out market trends by reducing noise, making them useful for identifying potential reversals and trend continuations. This project also includes trackball interaction for better data analysis.

## Features
•	**Custom Heikin-Ashi Series:** Built by extending the CandleSeries, the Heikin-Ashi chart calculates its own data using a separate ItemsSource.<br>

•	**Comparison with Candlestick Chart:** A direct visual comparison between Heikin-Ashi and traditional candlestick charts.</br>

•	**Trackball with Custom Labeling:** Displays Open, High, Low, and Close prices for better data insight.<br>

• **Axis Customization:** Customize DateTimeCategory Axis and Numerical Axis with formatted labels.</br>

## Heikin-Ashi Calculation

The Heikin-Ashi chart calculates new OHLC values using the following formulas.The formula smooths out volatility using the following calculations:

Open = (Previous Open + Previous Close) / 2

Close = (Open + High + Low + Close) / 4

High = Max(High, Open, Close)

Low = Min(Low, Open, Close)

With these implementations, we will get the output that resembles the following gif.

![BlogFinalOutput](https://github.com/user-attachments/assets/538edc87-ed6a-496e-878a-30d96ec8b20c)

## Troubleshooting
#### Path too long exception
If you encounter a Path Too Long Exception while building the project:

  1. Close Visual Studio.
  2. Rename the repository to a shorter name.
  3. Rebuild the project.

## For a step-by-step procedure
Refer to the blog for detailed instructions and code examples.





