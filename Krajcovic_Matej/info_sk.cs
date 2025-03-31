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
    public partial class info_sk: Form
    {
        public info_sk()
        {
            InitializeComponent();
            InitializeRichTextBox();
        }

        private void info_sk_Load(object sender, EventArgs e)
        {

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
\b\fs28 Názov aplikácie: \b0\fs24 Určenie polohy bodu vzhľadom na štvoruholník\par
\b Autor: \b0 Matej Krajcovič\par
\b Email: \b0\cf1\ul matejkr141@gmail.com\ulnone\cf0\par
\b Dátum vydania: \b0 2025\par
\b Popis: \b0 Aplikácia umožňuje vizuálne určiť polohu bodu P vzhľadom na štvoruholník, kontroluje správnosť zadania a zabraňuje nesprávnym konfiguráciám. \par
\b Použité technológie: \b0 C#, WinForms, .NET Framework 4.8\par
\b Verzia: \b0 1.3\par
}";
            richTextBox1.LinkClicked += RichTextBox1_LinkClicked;
        }

        private void RichTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
