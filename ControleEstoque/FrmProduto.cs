using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ControleEstoque1
{
    public partial class FrmProduto : ControleEstoque1.FrmBase
    {
        public FrmProduto()
        {
            InitializeComponent();
            BloqueiaCampos();
            CarregarGrid();
        }
        #region 
        private void LilberaCampos()
        {
            textNome.Enabled = true;
            textQuantidade.Enabled = true;
            textPreco.Enabled = true;
            textMarca.Enabled = true;



        }
        private void BloqueiaCampos()
        {
            textNome.Enabled = false;
            textQuantidade.Enabled = false;
            textPreco.Enabled = false;
            textMarca.Enabled = false;
        }
        #endregion


        private void FrmProduto_Load(object sender, EventArgs e)
        {
          
        }

        private void bntNovo_Click(object sender, EventArgs e)
        {
            textNome.Text = string.Empty;
            textMarca.Text = string.Empty;
            textQuantidade.Text = string.Empty;
            textPreco.Text = string.Empty;
            LilberaCampos();
            textNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model set = new Model();
                DtoProduto u = new DtoProduto();
                u.nome = textNome.Text;
                u.marca = textMarca.Text;
                u.quantidade = Convert.ToInt32(textQuantidade.Text);
                u.preco = Convert.ToDecimal(textPreco.Text);
                if (textId.Text != string.Empty)
                {
                    u.id = int.Parse(textId.Text);
                    set.EditProduto(u);
                }
                else
                {
                    set.SetProduto(u);
                }

                BloqueiaCampos();
                CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            LilberaCampos();
            textNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (textId.Text != string.Empty)
            {
                Model del = new Model();
                del.DeletarUsuario(int.Parse(textId.Text));
                BloqueiaCampos();
                CarregarGrid();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int Id = (Int32)dataGridView1.CurrentRow.Cells[0].Value;

            Model get = new Model();
            DtoProduto d = get.GetProdutoId(Id);
            textId.Text = d.id.ToString();
            textNome.Text = d.nome;
            textMarca.Text = d.marca;
            textQuantidade.Text = d.quantidade.ToString();
            textPreco.Text = d.preco.ToString();
            LilberaCampos();
            textNome.Focus();
        }
        private void CarregarGrid()
        {
            Model get = new Model();
            List<DtoProduto2> lista = get.ListProduto();
            this.dataGridView1.DataSource = lista;
            this.dataGridView1.Refresh();
        }
    }
}
