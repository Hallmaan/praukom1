using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Praukom1
{
    public partial class Form1 : Form
    {
        MySqlConnection koneksi = new MySqlConnection(@"server=localhost;database=praukom1;uid=root;pwd=;");
        public MySqlCommand cmd;
        public string idterpilih;

        public Form1()
        {
            InitializeComponent();
            tampilkandatapengguna();
            tampilkandatatarif();
            tampilkandatapenggunaan();
            tampilkandatatagihan();
            tampilkandatapembayaran();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("insert into pelanggan(nometer,nama,alamat,kodetarif) values('" + textBox2.Text + "', '" + textBox1.Text + "', '" + textBox4.Text + "', '" + comboBox4.Text + "')", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil menambah Pelanggan!");
                    koneksi.Close();
                    tampilkandatapengguna();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tampilkandatapengguna()
        {
            koneksi.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from pelanggan", koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void tampilkandatapenggunaan()
        {
            koneksi.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from penggunaan", koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tampilkandatatarif()
        {
            koneksi.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from tarif", koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void tampilkandatatagihan()
        {

            koneksi.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from tagihan", koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            koneksi.Close();
        }

        private void tampilkandatapembayaran()
        {

            koneksi.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from pembayaran", koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView5.DataSource = ds.Tables[0];
            koneksi.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            // string abc;
            MySqlDataReader dr = null;
            cmd = new MySqlCommand("select id from tarif order by id desc", koneksi);
            dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                string abc = dr["id"].ToString();
                //int a = Int32.Parse(textBox8.Text);       
                var abcd = textBox8.Text = "TRF000";
                int total = Int32.Parse(abc) + 1;
                textBox8.Text = abcd + total;
                koneksi.Close();
            }
            catch
            {
                int abcz = 1;
                string abcdz = textBox8.Text = "TRF000";
                //int test = Int32.Parse(abcdz) + 1;
                textBox8.Text = abcdz + abcz;
                koneksi.Close();
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox7.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("insert into tarif(kodetarif,daya,tarifperkwh) values('" + textBox8.Text + "', '" + textBox7.Text + "', '" + textBox6.Text + "')", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil menambah tarif!");
                    koneksi.Close();
                    tampilkandatatarif();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlDataReader dr = null;
            cmd = new MySqlCommand("select kodetarif from tarif", koneksi);
            dr = cmd.ExecuteReader();
            comboBox4.Items.Clear();
            while (dr.Read())
            {
                comboBox4.Items.Add(dr["kodetarif"].ToString());
            }
            koneksi.Close();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlDataReader dr = null;
            cmd = new MySqlCommand("select nama from pelanggan", koneksi);
            dr = cmd.ExecuteReader();
            comboBox1.Items.Clear();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["nama"].ToString());
            }
            koneksi.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlDataReader dr = null;
            cmd = new MySqlCommand("select idpelanggan from pelanggan where nama = '" + comboBox1.Text + "'", koneksi);
            dr = cmd.ExecuteReader();
            //comboBox1.Items.Clear();
            dr.Read();
            label22.Text = dr["idpelanggan"].ToString();
            koneksi.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "" || textBox9.Text == "" || comboBox1.Text == "" || textBox10.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("insert into penggunaan(idpelanggan,bulan,tahun,meterawal,meterakhir) values('" + label22.Text + "', '" + comboBox5.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox5.Text + "')", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil menambah Penggunaan Pelanggan!");
                    koneksi.Close();
                    tampilkandatapenggunaan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlDataReader dr = null;
            cmd = new MySqlCommand("select id from penggunaan", koneksi);
            dr = cmd.ExecuteReader();
            comboBox2.Items.Clear();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["id"].ToString());
            }
            koneksi.Close();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlDataReader dr = null;
            cmd = new MySqlCommand("select bulan,tahun,meterawal,meterakhir from penggunaan where id = '" + comboBox2.Text + "'", koneksi);
            dr = cmd.ExecuteReader();
            //comboBox1.Items.Clear();
            dr.Read();
            textBox15.Text = dr["bulan"].ToString();
            textBox13.Text = dr["tahun"].ToString();
            string abc = dr["meterawal"].ToString();
            string a = dr["meterakhir"].ToString();
            int total = Int32.Parse(abc) + Int32.Parse(a);
            textBox14.Text = total.ToString();
            koneksi.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("insert into tagihan(idpenggunaan,bulan,tahun,jumlahmeter,status) values('" + comboBox2.Text + "', '" + textBox15.Text + "', '" + textBox13.Text + "', '" + textBox14.Text + "', '" + textBox12.Text + "')", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil menambah Tagihan!");
                    koneksi.Close();
                    tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            koneksi.Open();
            MySqlDataReader dr = null;
            cmd = new MySqlCommand("select id from tagihan", koneksi);
            dr = cmd.ExecuteReader();
            comboBox3.Items.Clear();
            while (dr.Read())
            {
                comboBox3.Items.Add(dr["id"].ToString());
            }
            koneksi.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "" || comboBox3.Text == "" || comboBox6.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("insert into pembayaran(idtagihan,tanggal,bulanbayar,biayaadmin) values('" + comboBox3.Text + "', '" + dateTimePicker1.Text + "', '" + comboBox6.Text + "', '" + textBox18.Text + "')", koneksi);
                    cmd.ExecuteNonQuery();
                    MySqlCommand cmd2 = new MySqlCommand("update tagihan set status = 'SUDAH DIBAYAR' where id = '"+comboBox3.Text+"'", koneksi);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Berhasil melakukan pembayaran!");
                    koneksi.Close();
                    tampilkandatapembayaran();
                    tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView5.CurrentCell.RowIndex;
            idterpilih = dataGridView5.Rows[row].Cells[0].Value.ToString();
            comboBox3.Text = dataGridView5.Rows[row].Cells[1].Value.ToString();
            comboBox6.Text = dataGridView5.Rows[row].Cells[3].Value.ToString();
            textBox18.Text = dataGridView5.Rows[row].Cells[4].Value.ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "" || comboBox3.Text == "" || comboBox6.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("delete from pembayaran where idbayar = '"+idterpilih+"'", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Menghapus pembayaran!");
                    koneksi.Close();
                    tampilkandatapembayaran();
                    tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            idterpilih = dataGridView1.Rows[row].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("delete from pelanggan where idpelanggan = '" + idterpilih + "'", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Menghapus Pelanggan!");
                    koneksi.Close();
                    tampilkandatapengguna();
             //       tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("update pelanggan set nometer = '"+textBox2.Text+"', nama = '"+textBox1.Text+"', alamat = '"+textBox4.Text+"', kodetarif = '"+comboBox4.Text+"'  where idpelanggan = '" + idterpilih + "'", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Mengubah pelanggan!");
                    koneksi.Close();
                    tampilkandatapengguna();
                    //tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView2.CurrentCell.RowIndex;
            idterpilih = dataGridView2.Rows[row].Cells[0].Value.ToString();
            textBox8.Text = dataGridView2.Rows[row].Cells[1].Value.ToString();
            textBox7.Text = dataGridView2.Rows[row].Cells[2].Value.ToString();
            textBox6.Text = dataGridView2.Rows[row].Cells[3].Value.ToString();
            //comboBox4.Text = dataGridView2.Rows[row].Cells[4].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("delete from tarif where id = '" + idterpilih + "'", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Menghapus tarif!");
                    koneksi.Close();
                    tampilkandatatarif();
                    //       tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("update tarif set daya = '" + textBox7.Text + "', tarifperkwh = '" + textBox6.Text + "'  where id = '" + idterpilih + "'", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Mengubah Tarif!");
                    koneksi.Close();
                    tampilkandatatarif();
                    //tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView3.CurrentCell.RowIndex;
            idterpilih = dataGridView3.Rows[row].Cells[0].Value.ToString();
            comboBox5.Text = dataGridView3.Rows[row].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView3.Rows[row].Cells[1].Value.ToString();
            textBox9.Text = dataGridView3.Rows[row].Cells[3].Value.ToString();
            textBox10.Text = dataGridView3.Rows[row].Cells[4].Value.ToString();
            textBox5.Text = dataGridView3.Rows[row].Cells[5].Value.ToString();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("delete from penggunaan where id = '" + idterpilih + "'", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Menghapus penggunaan!");
                    koneksi.Close();
                    tampilkandatapenggunaan();
                    //       tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("update penggunaan set idpelanggan = '" + label22.Text + "', bulan = '" + comboBox5.Text + "', tahun = '" + textBox9.Text + "', meterawal = '" + textBox10.Text + "', meterakhir = '" + textBox5.Text + "'  where id = '" + idterpilih + "'", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Mengubah Penggunaan!");
                    koneksi.Close();
                    tampilkandatapenggunaan();
                    //tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView4.CurrentCell.RowIndex;
            idterpilih = dataGridView4.Rows[row].Cells[0].Value.ToString();
            textBox15.Text = dataGridView4.Rows[row].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView4.Rows[row].Cells[1].Value.ToString();
            textBox13.Text = dataGridView4.Rows[row].Cells[3].Value.ToString();
            textBox14.Text = dataGridView4.Rows[row].Cells[4].Value.ToString();
            textBox12.Text = dataGridView4.Rows[row].Cells[5].Value.ToString();
            //textBox5.Text = dataGridView3.Rows[row].Cells[5].Value.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("delete from tagihan where id = '" + idterpilih + "'", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Menghapus tagihan!");
                    koneksi.Close();
                    tampilkandatatagihan();
                    //       tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Error Field Missing");
            }
            else
            {
                try
                {
                    koneksi.Open();
                    cmd = new MySqlCommand("update tagihan set idpenggunaan = '" + comboBox2.Text + "', bulan = '" + textBox15.Text + "', tahun = '" + textBox13.Text + "', jumlahmeter = '" + textBox14.Text + "', status = '" + textBox12.Text + "'  where id = '" + idterpilih + "'", koneksi);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Berhasil Mengubah tagihan!");
                    koneksi.Close();
                   // tampilkandatapenggunaan();
                    tampilkandatatagihan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.Close();
                }
            }
        }
    }
}
