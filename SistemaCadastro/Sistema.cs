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

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }


        void listaDGBandas()
        {
            ConectaBanco con = new ConectaBanco();
            dgBandas.DataSource = con.listaBandas();
            lblMensagem.Text = con.mensagem;
        }


        private void Sistema_Load(object sender, EventArgs e)
        {
            listaDGBandas();
        }

        void limpaCampos()
        {
            txtnome.Clear();
            txtgenero.Clear();
            txtintegrantes.Clear();
            txtranking.Clear();
        }// fim limpa campos



        private void BtnConfirmaCadastro_Click_1(object sender, EventArgs e)
        {
            Banda b = new Banda();
            b.Nome = txtnome.Text;
            b.Genero = txtgenero.Text;
            b.Integrantes = Convert.ToInt32(txtintegrantes.Text);
            b.Ranking = Convert.ToInt32(txtranking.Text);
            ConectaBanco con = new ConectaBanco();
            bool r = con.insereBanda(b);
            if (r == true)
            {
                MessageBox.Show("Dados inseridos com sucesso:)!");
                listaDGBandas();
                limpaCampos();
                txtnome.Focus(); // cursor vai para o txtnome
            }
            else
                MessageBox.Show(con.mensagem);
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            (dgBandas.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("nome like '{0}%'", txtBusca.Text);
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
            int linha = dgBandas.CurrentRow.Index;
            int id =Convert.ToInt32(
                    dgBandas.Rows[linha].Cells["idbandas"].Value.ToString() );
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?",
                "Remove Banda", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deletaBanda(id);
                if (retorno == true)
                {
                    MessageBox.Show("Banda excluida com sucesso!");
                    listaDGBandas();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int linha = dgBandas.CurrentRow.Index;
            idAlterar = Convert.ToInt32(
                    dgBandas.Rows[linha].Cells["idbandas"].Value.ToString());
            txtAlteraNome.Text = dgBandas.Rows[linha].Cells["nome"].Value.ToString();
            txtAlteraGenero.Text = dgBandas.Rows[linha].Cells["genero"].Value.ToString();
            txtAlteraIntegrantes.Text = dgBandas.Rows[linha].Cells["integrantes"].Value.ToString();
            txtAlteraRanking.Text = dgBandas.Rows[linha].Cells["ranking"].Value.ToString();
            tabControl1.SelectedTab = tabAlterar;
        }

         private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            Banda b = new Banda();
            b.Nome = txtAlteraNome.Text;
            b.Genero = txtAlteraGenero.Text;
            b.Integrantes = Convert.ToInt32(txtAlteraIntegrantes.Text);
            b.Ranking = Convert.ToInt32(txtAlteraRanking.Text);
            ConectaBanco con = new ConectaBanco();
            bool ret = con.alteraBanda(b, idAlterar);
            if (ret == true) { 
                MessageBox.Show("Banda alterada com sucesso!");
                listaDGBandas();
                tabControl1.SelectedTab = tabBuscar;
            }// fim if true
            else
                MessageBox.Show(con.mensagem);


        }
    }
}
