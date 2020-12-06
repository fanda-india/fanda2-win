﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fanda.UI
{
    internal static class FormHelpers
    {
        internal static TForm ShowForm<TForm>(ref TForm form, Form mdiParent)
            where TForm : Form, new()
        {
            if (form == null || form.IsDisposed)
            {
                form = new TForm();
                form.MdiParent = mdiParent;
            }
            form.Show();
            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Normal;
            form.BringToFront();
            return form;
        }
    }
}