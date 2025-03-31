using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krajcovic_Matej
{
    public partial class Info: Form
    {
        public Info()
        {
            InitializeComponent();
            InitializeRichTextBox();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void InitializeRichTextBox()
        {
            // Nastavenie formátovaného textu
            richTextBox1.Rtf = @"{\rtf1\ansi\deff0
{\fonttbl{\f0 Microsoft Sans Serif;}}
{\colortbl;\red0\green0\blue255;}
\b\fs28 Application Name: \b0\fs24 Point Position Relative to Quadrilateral\par
\b Author: \b0 Matej Krajcovič\par
\b Email: \b0\cf1\ul matejkr141@gmail.com\ulnone\cf0\par
\b Release Date: \b0 2025\par
\b Description: \b0 The application allows visual determination of the position of point P relative to a quadrilateral, checks the correctness of input, and prevents invalid configurations.\par
\b Technologies Used: \b0 C#, WinForms, .NET Framework 4.8\par
\b Version: \b0 1.3\par
}";
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
