/*  A simple program made for windows to schedule a shutdown.
    
    It takes in hour(s) & minute(s) and prepares a scheduled shutdown
    after adding them together. If you wish to start the shutdown, press
    confirm. If you wish to cancel the shutdown, press cancel.

    If 0 or no entry is added, an error message will pop up preventing
    accidental immediate shutdowns. The textboxes will not accept non-number
    values to be typed in; however, non-number values could still be pasted in.
    There is preventive messages from allowing the program to crash from this.

    CMD Shutdown in 1 hour Command: shutdown -s -f -t 3600
    CMD Cancel Scheduled Shutdown Command: shutdown -a
*/

using System.Diagnostics;

namespace Shutdown
{
    public partial class Shutdown : Form
    {
        public Shutdown()
        {
            InitializeComponent();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            //startInfo.CreateNoWindow = true;

            int time = CalcTime();

            if(time != 0 && time != -1)
            {
                //Run the shutdown process
                var proc1 = new ProcessStartInfo();
                string aCommand = "shutdown -s -f -t " + time;
                proc1.UseShellExecute = true;
                proc1.WorkingDirectory = @"C:\Windows\System32";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas"; //behave as if the process has been started from Explorer with the "Run as Administrator" menu command
                proc1.Arguments = "/c " + aCommand; //"/c" tells the prompt to run and terminate afterwards
                proc1.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(proc1);

                //Shutdown in 1 hour
                if (textBoxHR.Text == "1" && String.IsNullOrEmpty(textBoxMin.Text))
                {
                    MessageBox.Show($"Shutdown scheduled in {textBoxHR.Text} hour", "Success!");
                }
                //Shutdown in 1 hour and # minutes
                else if (textBoxHR.Text == "1")
                {
                    MessageBox.Show($"Shutdown scheduled in {textBoxHR.Text} hour and {textBoxMin.Text} min(s)", "Success!");
                }
                else if (textBoxHR.Text == "0")
                {
                    MessageBox.Show($"Shutdown scheduled in {textBoxMin.Text} min(s)", "Success!");
                }
                //Shutdown in hours and minutes
                else
                {
                    MessageBox.Show($"Shutdown scheduled in {textBoxHR.Text} hour(s) and {textBoxMin.Text} min(s)", "Success!");
                }
            }
            //Textboxes are empty
            else if (time == 0)
            {
                MessageBox.Show("Invalid! Time cannot be 0.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Time was a random character
            else
            {
                MessageBox.Show("Invalid! Enter a valid number.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Calculate the given time from the user
        private int CalcTime()
        {
            int time = 0;
            //shutdown -s -f -t 3600 = shutdown in 1 hour
            //3600 = 1 hr, 60 = 1 minutes

            //If the hour textbox is not empty, calculate hours
            try
            {
                if (!String.IsNullOrEmpty(textBoxHR.Text))
                {
                    time += int.Parse(textBoxHR.Text) * 3600;
                }
                if (!String.IsNullOrEmpty(textBoxMin.Text))
                {
                    time += int.Parse(textBoxMin.Text) * 60;
                }
            }
            //If an invalid character is pasted in, return -1
            catch
            {
                return -1;
            }
            return time;
        }
        //Cancels a shutdown if one was scheduled
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            var proc1 = new ProcessStartInfo();
            string aCommand = "shutdown -a";
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = @"C:\Windows\System32";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + aCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
            MessageBox.Show($"Shutdown canceled", "Success!");
        }
        //Only allow numbers to be typed
        private void textBoxHR_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //Only allow numbers to be typed
        private void textBoxMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}