using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Danilo.editorDeTexto.UI.Desktop
{
    public partial class FormPrincipal : Form
    {
        // como o Windows não gerencia o status do Insert,
        // criaremos uma variável para isso
        bool insertStatus = true;

        public FormPrincipal()
        {
            InitializeComponent();
    

        }

        // omitindo o modificador de acesso o default é private
        /* private */
        void verificaTeclaCaps()
        {
            if (Console.CapsLock)
                lblCaps.ForeColor = Color.Blue;
            else
                lblCaps.ForeColor = Color.Gray;
        }
        void verificaTeclaNum()
        {
            if (Console.NumberLock)
                lblNum.ForeColor = Color.Blue;
            else
                lblNum.ForeColor = Color.Gray;
        }
        void verificaTeclaIns()
        {
            // a tecla Ins não é controlada pelo Windows
            // por isso criamos a variável insertStatus
            if (insertStatus)
                lblIns.ForeColor = Color.Blue;
            else
                lblIns.ForeColor = Color.Gray;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Evento TextChanged de tbxEditor é executado toda vez
            // que o texto contido nele for alterado
            lblStatus.Text = "Modificado";
        }


        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            verificaTeclaCaps();
            verificaTeclaIns();
            verificaTeclaNum();
        }

        private void FormPrincipal_KeyDown(object sender, KeyEventArgs e)
        /*
        * Para que o evento KeyDown do formulário seja
        * executado independente de qual controle tem foco,
        * precisamos alterar a propriedade KeyPreview para true
        */
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                verificaTeclaCaps();
            }

            if (e.KeyCode == Keys.NumLock)
            {
                verificaTeclaNum();
            }

            if (e.KeyCode == Keys.Insert)
            {
                // o Windows não controla status do insert,
                // temos que fazer isso via programação
                insertStatus = !insertStatus;
                verificaTeclaIns();
            }
        }

        private void tbxEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Se o insert estiver desligado E
            if (!insertStatus &&
                // a tecla pressionada não for BackSpace E
                e.KeyChar != '\x8' &&
                // não existir nada selecionado
                tbxEditor.SelectionLength ==0)
            {
                // selecionar 1 caractere á direita do cursor
                tbxEditor.SelectionLength = 1;
            }
        }
    }
}
