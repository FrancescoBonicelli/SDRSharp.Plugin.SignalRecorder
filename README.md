# SDRSharp.Plugin.SignalRecorder
Signal recorder plugin for SDRSharp.

Windows binary available in the Releases page.

## Instructions

![Plugin board](./Files/PluginBoard.png)

1. The signal level (db) above witch the recording starts when enabled.
2. The folder where the recorded data will be saved.
3. 
   - If NOT *Full Signal Record* the recording time. The time starts when the signal exceeds the threshold set in (1).
   - If *Full Signal Record* the time the signal can stay lower than the threshold set in (1) before stopping the recording.
4. If set greather than 0 the maximum recording time per file. This option allows to split the records into multiple files.
5. The data that will be saved.
6. When checked the recorder waits for a signal greater than the threshold and than it starts to record the signal. The recording is automatically stopped when the time set in the previous point is elapsed. It is possible to manually stop a recording unchecking the box.
7. If desired the last recorded data can be plotted directly.

![Plot example](./Files/RecordedDataPlot.png)

In the plot window it is possible to move around the data, zoom, pan and enable/disable drawings.

## Installing instructions
Copy the *SDRSharp.Plugin.SignalRecorder* and the two *ScottPlot* dlls into the SDRSharp Plugin folder. 

Enjoy.

## Compiling instructions
(updated to february 2023)

Go to [Airspy website download page](https://airspy.com/download/) and download the *SDR# SDK for Plugin Developers* (for .NET 7).

Clone the *SDRSharp.Plugin.SignalRecorder* repository inside the sdrplugins solution folder.

Make sure the project folder is next to the SDK *lib* folder.

Open the project with Visual Studio 2022 and compile the project.

The *SDRSharp.Plugin.SignalRecorder* with the *ScottPlot* dlls are found inside the *sdrplugins\Release\net7.0-windows\\* (or *sdrplugins\Debug\net7.0-windows\\*) folder.