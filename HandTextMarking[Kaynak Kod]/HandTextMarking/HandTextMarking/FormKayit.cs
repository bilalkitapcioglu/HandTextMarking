using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandTextMarking
{
    public partial class FormKayit : Form
    {
        public FormKayit()
        {
            InitializeComponent();
        }

        FormAna frmAna;

        public string fileName;

        private void btnTamam_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxRegFileName.Text == null | textBoxRegFileName.Text == " ")
                {
                    MessageBox.Show("Dosya ismini giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public string RegFileName()
        {
            fileName = textBoxRegFileName.Text.ToString();
            return fileName.ToString();
        }
    }
}
