using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextPad
{
    public partial class FormTextPad : Form
    {
        StreamReader procitajDatoteku;
        string imeDatoteke;

        public FormTextPad()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.dialogOtvoriDatoteku.ShowDialog() == DialogResult.OK)
            {
                if (this.procitajDatoteku != null)
                    this.procitajDatoteku = new StreamReader(this.dialogOtvoriDatoteku.FileName);

                this.textBox.Text = this.procitajDatoteku.ReadToEnd();
                this.imeDatoteke = this.dialogOtvoriDatoteku.FileName;
                this.Text = this.dialogOtvoriDatoteku.SafeFileName + " - TextPad";
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.dialogSpremiDatoteku.ShowDialog() == DialogResult.OK)
            {
                if (this.procitajDatoteku != null)
                    this.procitajDatoteku.Close();
                
                StreamWriter spremiDatoteku = new StreamWriter(this.dialogSpremiDatoteku.FileName);
                spremiDatoteku.Write(this.textBox.Text);
                spremiDatoteku.Flush();
                spremiDatoteku.Close();
                this.procitajDatoteku = new StreamReader(this.dialogSpremiDatoteku.FileName);
                this.imeDatoteke = this.dialogSpremiDatoteku.FileName;
                this.Text = this.dialogSpremiDatoteku.FileName.Substring(this.dialogSpremiDatoteku.FileName.LastIndexOf('\\') + 1) + " - TextPad";
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.imeDatoteke == null)
                this.saveToolStripMenuItem_Click(sender, e);
            StreamWriter spremiDatoteku = new StreamWriter(this.imeDatoteke);
            spremiDatoteku.Write(this.textBox.Text);
            spremiDatoteku.Flush();
            spremiDatoteku.Close();
            this.procitajDatoteku = new StreamReader(this.imeDatoteke);
            this.Text = this.imeDatoteke.Substring(

            this.imeDatoteke.LastIndexOf('\\') + 1) + " - TextPad";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.procitajDatoteku != null)
                this.procitajDatoteku.Close();
            this.imeDatoteke = null;
            this.textBox.Clear();
            this.Text = "TextPad";
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            findForm dialogFind = new findForm();
            dialogFind.Owner = this;
            dialogFind.ShowDialog();
        }

        protected internal bool pronadiTekst(string tekstZaPronaci, bool pretrazivanjePremaDolje, bool pazitiNaCase)
        {
            return true;
        }
    }
}
