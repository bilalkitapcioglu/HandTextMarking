using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Collections;
using System.Text.RegularExpressions;

namespace HandTextMarking
{
    public partial class FormAna : Form
    {
        public FormAna()
        {
            InitializeComponent();
        }
        //Form içnde genel olarak ortak olan değişkenler ve nesneler
        //---------------------------------------
        WriteFile wf = new WriteFile();
        FormKayit fk = new FormKayit();
        public string filePath;
        public string fileName;
        string undoText = "";
        public string startMark = "<isim>";
        public string endMark = "</isim>";
        public static int cursorPosition = 0;
        //---------------------------------------
        private void tümünüİsaretleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllMark();
        }

        private void isaretleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mark();
        }

        private void btnDisaAktar_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();

            try
            {
                dr = fk.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    fileName = fk.RegFileName();
                    DisaAktar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /*Textbox daki işaretli metni tüm metin içinde arayıp sağına ve soluna 
        bizim belirlediğimiz işaretleri koymak için yapılan kontrol ve işlemlerin bulunduğu fonksiyon*/
        public void Mark()
        {
            undoText = textBox.Text;
            cursorPosition = textBox.Text.IndexOf(textBox.SelectedText);
            string[] text = textBox.Text.Split(' ');
            string selectedText = Regex.Replace(textBox.SelectedText, @"\s", "").TrimStart();
            int selectedWordLength = selectedText.Length;
            string temp = "";
            string cleanWord = "";
            bool tag = true;
            //Program çalışırken hata olursa uygun hata mesajı ile programın prosesini öldürmemek için
            //yani program akışını fatal error düşmemesi için
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    /*Bu aşağıdaki ilk if bloğu cümle olarak işaretlenmiş isimlerin içindeki isimlerin tekrardan işaretlenmemesi için.
                    ilk önce <isim>Orta Doğu Teknik Üniversitesi</isim> işaretlenmiş ve sonradan başka bi yerdeki Doğu yu işaretlemek
                    istersek <isim>Orta <isim>Doğu</isim> Teknik Üniversitesi</isim> olmasını engellemek için.*/
                    //-------------------------------------------------------
                    if (text[i].StartsWith(startMark) | !tag)
                    {
                        if (text[i].EndsWith(endMark) | IsTagged(text[i]))
                            tag = true;
                        else
                            tag = false;
                    }
                    //--------------------------------------------------------
                    /*İşaretleme yapılacak seçili metnin, işaretlenmiş herhangi bir başka 2 veya daha fazla sözcükten oluşan metnin
                    içinde olup olmadığını yani işaretlenebilirlik durumunu kontrol etmek için yazılan blok*/
                    //-------------------------------------------------------------------------------------------------
                    if (tag)
                    {
                        cleanWord = WordCleaner(text[i]);
                        //-----------------------------------------------------------------------------
                        if (selectedWordLength <= cleanWord.Length)
                        {
                            cleanWord = cleanWord.Substring(0, selectedWordLength);
                            if (cleanWord == selectedText)
                                temp += startMark + text[i].Substring(0, selectedWordLength)
                                        + endMark + text[i].Substring(selectedWordLength) + " ";
                            else
                                temp += text[i] + " ";
                            cleanWord = "";
                        }
                        else
                        {
                            temp += text[i] + " ";
                            cleanWord = "";
                        }
                        //------------------------------------------------------------------------------
                    }
                    else
                    {
                        temp += text[i] + " ";
                        cleanWord = "";
                    }
                    //---------------------------------------------------------------------------------------------------
                }
            }
            catch (Exception)
            {
                MessageBox.Show("İşaretleme işleminde bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            textBox.Text = temp;
        }
        public void AllMark()
        {
            undoText = textBox.Text;
            cursorPosition = textBox.Text.IndexOf(textBox.SelectedText);
            string[] text = textBox.SelectedText.Split(' ');
            string selectedText = "";
            string temp = "";
            //Program çalışırken hata olursa uygun hata mesajı ile programın prosesini öldürmemek için 
            //yani program akışını fatal error düşmemesi için
            try
            {
                for (int i = 0; i <= text.Length - 1; i++)
                {
                    string midText;
                    if (text[i].StartsWith(startMark) & text[i].EndsWith(endMark))
                    {
                        midText = text[i].Substring(startMark.Length, (text[i].Length - (startMark.Length + endMark.Length)));
                        text[i] = midText;
                    }

                    if (i <= text.Length - 2)
                        selectedText += text[i] + " ";
                    else
                        selectedText += text[i];
                }

                string selectedMarkedText = startMark + selectedText + endMark;
                selectedMarkedText.TrimEnd();
                temp = textBox.Text.Replace(textBox.SelectedText, selectedMarkedText);
                textBox.Text = temp;
            }
            catch (Exception)
            {
                MessageBox.Show("İşaretleme işleminde bir hata oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /*------------------------------------------------------------------------------------------------
        Alternatif işaretleme çalışmaları(Önemli değiller)

        public void AllMark()
        {
            string selectedText = textBox.SelectedText;
            string selectedMarkedText = startMark + selectedText + endMark;
            
            temp =textBox.Text.Replace(selectedText, selectedMarkedText);
            string[] text = temp.Split(' ');
            string[] tempText = text;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].StartsWith(startMark) & !text[i].EndsWith(endMark))
                {
                    int count = i;
                    do
                    {
                        tempText[i] += text[count];
                        count++;
                    } while (!text[count].EndsWith(endMark));
                    tempText[i] += text[count];
                    i -= count - i;
                }
                else
                {
                    tempText[i] += text[i];
                }

                if (i > text.Length)
                    break;
                else continue;
            }
            textBox.Text = tempText.ToString();
        }
        
        ------------------------------------------------------------------------------------------------*/
        //İşaretlenecek metni regex kullanarak istediğimiz formattla temizleyip geri döndüren fonksiyon
        private string WordCleaner(string w)
        {
            return Regex.Replace(w, @"[^\w\s]", "");
        }
        //İşaretlenecek metnin başka bir işaretli metin içinde olup olmadığını kontrol eder.
        public bool IsTagged(string s)
        {
            if (s.Contains(endMark))
                return true;
            else return false;
        }
        /*
       public bool IsTagged(string s)
       {
           for (int i = 0; i <= s.Length - endMark.Length; i++)
           {
               string sub;
               sub = s.Substring(i, endMark.Length);
               if (sub == endMark)
                   return true;
           }
           return false;
       }
       */
       //İşaretlenmiş metnimizi istediğimiz isimle masaüstüne .txt uzuntılı bir dosya olarak kaydedilmesi için kullanılan fonsiyon
        public void DisaAktar()
        {
            string endText = "";
            filePath = "C:\\Users\\" + Environment.UserName + "\\Desktop\\" + fileName.ToString() + ".txt";
            endText = textBox.Text.ToString();
            wf.MarkedWriteFile(filePath, endText);
        }
        //Form un düzeninin bozulmaması için
        private void FormAna_Resize(object sender, EventArgs e)
        {
            this.textBox.Size = new System.Drawing.Size(this.Size.Width - 40, Size.Height - 90);
            this.btnDisaAktar.Location = new Point((this.Size.Width / 2 - 50), this.Size.Height - 70);
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            //İşaretlemeden sonra ScrollBar ın en başa değilde işaretleme yaptığımız ismin indexine göre konumlanmasını sağlamak için
            //------------------------------------------
            textBox.SelectionStart = cursorPosition;
            textBox.ScrollToCaret();
            //-----------------------------------------
        }
        //Ctrl+Keys kombinasyonlarını uygulamak için
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                textBox.Copy();
            else if (e.Control && e.KeyCode == Keys.A)
                textBox.SelectAll();
            else if (e.Control && e.KeyCode == Keys.Z)
                textBox.Text = undoText;
            else cursorPosition++;
        }
    }
}
