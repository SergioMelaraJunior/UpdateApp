using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateApp
{
    public partial class frmUpdate : Form
    {
        public frmUpdate()
        {
            InitializeComponent();
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            
            SqlConnection sql = new SqlConnection("Password=HWXAn6Dv;Persist Security Info=True;User ID=sa;Initial Catalog=db_visual_teste;Data Source=SRV-04\\SQL_VR");
            SqlCommand command = new SqlCommand("select * from rodcon where CODCON=@CODCON and sercon=@SERCON and codfil=@CODFIL", sql);
            command.Parameters.Add("@CODCON", SqlDbType.Int).Value = txbCODCON.Text;
            command.Parameters.Add("@SERCON", SqlDbType.VarChar).Value = txbSERCON.Text;
            command.Parameters.Add("@CODFIL", SqlDbType.SmallInt).Value = txbCODFIL.Text;

            if (txbCODCON.Text != "" & txbSERCON.Text != "" & txbCODFIL.Text != "")
            {

                try
                {
                    sql.Open();
                    SqlDataReader drms = command.ExecuteReader();
                    if (drms.HasRows == false)
                    {
                        throw new Exception("Há algo de errado que nao esta certo!");
                    }

                    drms.Read();
                    txbCODMOT.Text = Convert.ToString(drms["CODMOT"]);
                    txbCODMO2.Text = Convert.ToString(drms["CODMO2"]);
                    txbCODMO3.Text = Convert.ToString(drms["CODMO3"]);
                    txbPERCOM.Text = Convert.ToString(drms["PERCOM"]);
                    txbPERCO2.Text = Convert.ToString(drms["PERCO2"]);
                    txbPERCO3.Text = Convert.ToString(drms["PERCO3"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sql.Close();
                }
            }
            else MessageBox.Show("Digite os Campos Obrigatórios (*) ", "UpdateApp - Procurar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbCODMOT.Text = "";
            txbCODMO2.Text = "";
            txbCODMO3.Text = "";
            txbPERCOM.Text = "";
            txbPERCO2.Text = "";
            txbPERCO3.Text = "";
            txbCODCON.Text = "";
            txbSERCON.Text = "";
            txbCODFIL.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Password=HWXAn6Dv;Persist Security Info=True;User ID=sa;Initial Catalog=db_visual_teste;Data Source=SRV-04\\SQL_VR");
            SqlCommand command = new SqlCommand("update rodcon set CODMOT=@CODMOT, CODMO2=@CODMO2, CODMO3=@CODMO3, PERCOM=@PERCOM, PERCO2=@PERCO2, PERCO3=@PERCO3 where CODCON=@CODCON and sercon=@SERCON and codfil=@CODFIL", sql);
            command.Parameters.Add("@CODCON", SqlDbType.Int).Value = txbCODCON.Text;
            command.Parameters.Add("@SERCON", SqlDbType.VarChar).Value = txbSERCON.Text;
            command.Parameters.Add("@CODFIL", SqlDbType.SmallInt).Value = txbCODFIL.Text;
            if(txbCODMOT.Text == "")
            {
                command.Parameters.Add("@CODMOT", DBNull.Value).Value = DBNull.Value;

               // SqlCommand cmd = new SqlCommand ("update rodcon set CODMOT = NULL WHERE CODCON=@CODCON and sercon=@SERCON and codfil=@CODFIL", sql);
                
            }
            else command.Parameters.Add("@CODMOT", SqlDbType.Int).Value = txbCODMOT.Text;
            command.Parameters.Add("@CODMO2", SqlDbType.Int).Value = txbCODMO2.Text;
            command.Parameters.Add("@CODMO3", SqlDbType.Int).Value = txbCODMO3.Text;
            command.Parameters.Add("@PERCOM", SqlDbType.Decimal).Value = txbPERCOM.Text;
            command.Parameters.Add("@PERCO2", SqlDbType.Decimal).Value = txbPERCO2.Text;
            command.Parameters.Add("@PERCO3", SqlDbType.Decimal).Value = txbPERCO3.Text;

            if (txbCODCON.Text != "" & txbSERCON.Text != "" & txbCODFIL.Text != "")
            {

                try
                {
                    sql.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Update efetuado com Sucesso", "UpdateAPP - Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbCODMOT.Text = "";
                    txbCODMO2.Text = "";
                    txbCODMO3.Text = "";
                    txbPERCOM.Text = "";
                    txbPERCO2.Text = "";
                    txbPERCO3.Text = "";
                    txbCODCON.Text = "";
                    txbSERCON.Text = "";
                    txbCODFIL.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sql.Close();
                }
            }
            else MessageBox.Show("Digite os Campos Obrigatórios (*) ", "UpdateApp - Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
