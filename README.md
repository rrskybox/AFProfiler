# AFProfiler
Astroimaging tool for collection of focus position/temperature data using TheSkyX.

Auto Focus Profiler Description (AFProfiler V1.94)

Rick McAlister, Dec 2018

This Windows application tool performs three tasks:

1.	Prefocus calculates and moves the focuser to a position based on the current focuser temperature, a temperature compensation trendline generated from a previously acquired focus data file. In addition, the focuser Critical Focus Zone (in steps) is calculated from focal ratio and focuser resolution.
2.	Profile runs the TSX @Focus2 or @Focus3 process over a set of filters for an extended period of time. Repetitions, wait period, exposure and filters are determined by the user.  To accommodate mixed wide and narrowband filter sets, AFProfiler assumes that an @Focus2/3 error is the result of a too faint image and automatically doubles the exposure time for a second try.  Upon completion (or abort) the user is prompted to save the data points in a focus data file.
3.	Analyze computes focuser parameters from a previously acquired focus data file, including temperature compensation trendlines and filter offsets, based on a reference temperature and filter (normally the clear filter).  A projected effectiveness for the calculated temperature compensation and offset of each filter is also judged based on the percentage of focus data points that fall within the CFZ as centered on the temperature compensation trendline for the reference filter.
 
Notes on Operation:  

The user sets the following parameters:  
1)	Focal Length of imaging system
2)	Resolution (microns per step) of focuser
3)	Reference Filter – filter from which all other filter offsets are calculated.
4)	First Filter number, Last Filter number, Clear Filter number – all zero-based.
5)	Exposure time in seconds
6)	Number of Repetitions
7)	Wait Between Repetitions as time delay between sets, giving time for temperature change.
8)	Reference Temperature around which offsets and compensation are to be calculated.
9)	Use CLS determines whether the program will re-center the focus star for each repetition.
10)	 Use @Focus3 tells the program use the @Focus3 method rather than @Focus2

Current Temp is read from the focuser itself and is only used for PreFocus calculations.
Critical Focus Zone is calculated from focal ratio and resolution inputs.

Once set up, the application runs the filter set through the @Focus2 or 3 process, waits for the set interval, then repeats for the set number of repetitions.  Upon completion, the focus data can be stored in a *.foc file.  Note that saving the focus data must be done manually in TSX.  Neither AFProfiler or TSX will store this data automatically.  Note that if you disconnect the focuser before saving your data, all focuser data will be cleared.

Temperature Compensation is computed as a least-mean-square linear fit of the focus data, individually by filter.  Essentially, this means drawing a straight line that is least distant from all the points.  As temperature compensation is computed for each filter, the TC slope may be different for different filters.  If the computed slope is wildly different between filters, then there is probably a problem with the system.

Some imaging system may have a nonlinear response to changes in temperature, i.e. a curve is the best fit.  This might be especially true over large temperature ranges.  If so, TSX temperature compensation won’t help.  You’ll need to refocus to deal with temperature swings.  The accuracy measure (described below) may help determine if you are dealing with a nonlinear temperature response or not.  

Accuracy provides a basis to estimate the effectiveness of applying calculated temperature compensation values and offsets.to the focuser.  The graph below plots the acquired focus data points for a range of temperatures.  The line is the temperature compensation (TC) computed for those points as a least-mean-squares fit.  A critical focus zone (CFZ) is shown as an area around the TC line.  

 

All the focus data points that fall within the CFZ are as good as it can get for the optical set up.  That is, for any given temperature, any position within that zone is considered focused.  So, the percentage of data points within the CFZ can be considered a measure of the accuracy of the computed temperature compensation for the given imager.  If none of the points fall within the zone then the TC line can be considered worthless.  If all of the points fall within the zone then the TC can be considered more or less accurate, assuming a large enough sample size.

Requirements:  

Auto Focus Profiler is a Windows Forms executable, written in Visual Basic.  The application runs as an uncertified, standalone application under Windows 7, 8 and 10.  The application uses the TSX Camera Add On capability.  AFProfiler has been validated on TSX 10.5.0 Build 11355.

Installation:  

AFProfiler executes as a “Click-Once” application.  This means that it is installed and executed from a system cache and does not create folder(s) on your system.  It also means that the application will run immediately after installation – shouldn’t be a problem.  

Run the "Pubish\Setup.exe" application.  Upon completion, an application icon will have been added to the start menu under the category "TSXToolkit" with the application name  “Auto Focus Profiler".  This application can be pinned to the Start if desired.

Support:  

This application was written for the public domain and as such is unsupported. The developer will listen to problems and suggestions for improvement, but really wishes you his best and hopes everything works out.  He further but recommends learning Visual Basic (it's really not hard and the tools are free from Microsoft) if you find a problem or want to add features.  The source is supplied as a Visual Studio project.
