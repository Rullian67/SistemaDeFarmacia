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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SistemaCadastro
{
  
    public partial class Sistema : Form
    {
        int idAlterar;

        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sistema_Load(object sender, EventArgs e)
        {

            listacbCategoria();
            lista_gridRemedios();
        }

        void lista_gridRemedios()
        {
            ConectaBanco con = new ConectaBanco();
            dgRemedios.DataSource = con.listaRemedios();
            dgRemedios.Columns["idremedios"].Visible = false;

        }

        public void listacbCategoria()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaCategoria();
            cbCategoria.DataSource = tabelaDados;
            cbCategoria.DisplayMember = "categoria";
            cbCategoria.ValueMember = "idcategoria";

            cbAlteraCategoria.DataSource = tabelaDados;
            cbAlteraCategoria.DisplayMember = "categoria";
            cbAlteraCategoria.ValueMember = "idcategoria";
        }


        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgRemedios.DataSource as DataTable).DefaultView.RowFilter =
              string.Format("nome like '{0}%'", txtBusca.Text);

        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
            int linha = dgRemedios.CurrentRow.Index;
            int id = Convert.ToInt32(
                    dgRemedios.Rows[linha].Cells["idremedios"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?",
                "Remove Remedio", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deletaRemedio(id);
                if (retorno == true)
                {
                    MessageBox.Show("Remedio excluido com sucesso!");
                    lista_gridRemedios();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            int linha = dgRemedios.CurrentRow.Index;// pega a linha selecionada
            idAlterar = Convert.ToInt32(
              dgRemedios.Rows[linha].Cells["idRemedios"].Value.ToString());
            txtAlteraNome.Text =
                 dgRemedios.Rows[linha].Cells["nome"].Value.ToString();
            txtAlteraPreco.Text =
                dgRemedios.Rows[linha].Cells["preco"].Value.ToString();
            txtAlteraQuantidade.Text =
                dgRemedios.Rows[linha].Cells["quantidade"].Value.ToString();
            cbAlteraCategoria.Text =
                dgRemedios.Rows[linha].Cells["categoria"].Value.ToString();
            tabControl1.SelectedTab = tabAlterar;// muda aba
        }
        void limpaCamposCategoria()
        {
            txtAlteraNome.Clear();
            cbAlteraCategoria.Text = "";
            txtAlteraPreco.Clear();
            txtAlteraQuantidade.Clear();
            txtnome.Focus();
        }

        private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            Remedio novoRemedio = new Remedio();
            novoRemedio.Nome = txtAlteraNome.Text;
            novoRemedio.Quantidade = Convert.ToInt32(txtAlteraQuantidade.Text);
            novoRemedio.Preco = Convert.ToSingle(txtAlteraPreco.Text);
            novoRemedio.Categoria = Convert.ToInt32(cbAlteraCategoria.SelectedValue.ToString());
            bool retorno = con.alteraBanda(novoRemedio, idAlterar);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else
                MessageBox.Show("Alteração realizada com sucesso!");

            limpaCamposCategoria();
            lista_gridRemedios();

        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {
          FrmAddCategoria formCategoria = new FrmAddCategoria();
            this.Hide();
            formCategoria.ShowDialog();
            this.Close();
    }

        void limpaCampos()
        {
            txtnome.Clear();
            cbCategoria.Text = "";
            txtpreco.Clear();
            txtquantidade.Clear();
            txtnome.Focus();
        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            Remedio novoRemedio = new Remedio();
            novoRemedio.Nome = txtnome.Text;
            novoRemedio.Preco =Convert.ToSingle( txtpreco.Text);
            novoRemedio.Quantidade = Convert.ToInt32(txtquantidade.Text);
            novoRemedio.Categoria = Convert.ToInt32(cbCategoria.SelectedValue.ToString());
            bool retorno  = con.insereRemedio(novoRemedio);
            if (retorno == false)
           
            MessageBox.Show(con.mensagem);
            MessageBox.Show("Remedio cadastrado com sucesso!");

            limpaCampos();
            lista_gridRemedios();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtnome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAlteraIntegrantes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
