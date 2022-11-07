using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HandTextMarking
{

    class WriteFile
    {


        public void MarkedWriteFile(string filePath,string text)
        {
            try
            {
                StreamWriter sw;
                sw = File.AppendText(filePath);
                sw.Write(text.ToString());
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
