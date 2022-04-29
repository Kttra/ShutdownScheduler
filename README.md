# Shutdown Scheduler
A program that schedules a shutdown for windows devices.

It takes in hour(s) & minute(s) and prepares a scheduled shutdown
    after adding them together. If you wish to start the shutdown, press
    confirm. If you wish to cancel the shutdown, press cancel.

If 0 or no entry is added, an error message will pop up preventing
accidental immediate shutdowns. The textboxes will not accept non-number
values to be typed in; however, non-number values could still be pasted in.
There is preventive messages from allowing the program to crash from this.

<p align="center">
<img src="https://user-images.githubusercontent.com/100814612/165878574-7f9bdb08-f284-4abb-996d-4ec86a237d5b.png"><img>
</p>

Examples of the commands used:
- CMD Shutdown in 1 hour Command: shutdown -s -f -t 3600
- CMD Cancel Scheduled Shutdown Command: shutdown -a
