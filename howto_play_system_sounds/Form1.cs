using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace howto_play_system_sounds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAsterisk_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void btnBeep_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
        }

        private void btnExclamation_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void btnHand_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Hand.Play();
        }

        private void btnQuestion_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Question.Play();
        }

        private void btnConsoleBeep_Click(object sender, EventArgs e)
        {
            Console.Beep();
        }
    }
}
