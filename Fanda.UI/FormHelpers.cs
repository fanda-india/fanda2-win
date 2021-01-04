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
                form = new TForm
                {
                    MdiParent = mdiParent
                };
            }
            form.Show();
            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }

            form.BringToFront();
            return form;
        }

        //internal static TForm ShowForm<TForm>(this TForm form, Form mdiParent, params object[] formParams)
        //    where TForm : Form, new()
        //{
        //    if (form == null || form.IsDisposed)
        //    {
        //        form = new TForm();
        //        form.MdiParent = mdiParent;
        //    }
        //    form.Show();
        //    if (form.WindowState == FormWindowState.Minimized)
        //        form.WindowState = FormWindowState.Normal;
        //    form.BringToFront();
        //    return form;
        //}

        //internal static TForm ShowForm<TForm>(ref TForm form, Form mdiParent, params object[] formParams)
        //    where TForm : Form, IFormFactory<TForm>, new()
        //{
        //    if (form == null || form.IsDisposed)
        //    {
        //        form = new TForm();
        //        form.Create(mdiParent, formParams);
        //    }
        //    form.Show();
        //    if (form.WindowState == FormWindowState.Minimized)
        //        form.WindowState = FormWindowState.Normal;
        //    form.BringToFront();
        //    return form;
        //}
    }

    //public interface IFormFactory<TForm>
    //{
    //    void Create(Form mdiParent, params object[] formParams);
    //}

    //public class FormFactory<TForm> : Form, IFormFactory<TForm>
    //    where TForm : Form, new()
    //{
    //    protected object[] FormParams;

    //    public FormFactory()
    //    {
    //    }

    //    public void Create(Form mdiParent, params object[] formParams)
    //    {
    //        FormParams = formParams;
    //        MdiParent = mdiParent;
    //    }
    //}
}
