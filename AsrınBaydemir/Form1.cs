using AsrınBaydemir.Models;

namespace AsrınBaydemir
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                try
                {
                    Film film = new Film()
                    {
                        FilmAd = textBox1.Text,
                        FilmTarih = dateTimePicker1.Value,
                        Saat1 = dateTimePicker2.Value.TimeOfDay,
                        Saat2 = dateTimePicker3.Value.TimeOfDay,
                        Saat3 = dateTimePicker4.Value.TimeOfDay,
                        Saat4 = dateTimePicker5.Value.TimeOfDay,
                        Saat5 = dateTimePicker6.Value.TimeOfDay,
                        Saat6 = dateTimePicker7.Value.TimeOfDay
                    };

                    using (var nesne = new EntityAyar())
                    {
                        nesne.Film.Add(film);
                        nesne.SaveChanges();
                        MessageBox.Show("Veri Kaydedildi!");
                    }

                    using (var nesne = new EntityAyar())
                    {
                        var Film = nesne.Film.ToList();

                        dataGridView1.DataSource = Film;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var nesne = new EntityAyar())
                {
                    var Film = nesne.Film.ToList();

                    dataGridView1.DataSource = Film;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && maskedTextBox1.Text != string.Empty)
            {
                try
                {
                    Salon salon = new Salon()
                    {
                        SalonAd = textBox2.Text,
                        Kapasite = int.Parse(maskedTextBox1.Text)
                    };

                    using (var nesne = new EntityAyar())
                    {
                        nesne.Salon.Add(salon);
                        nesne.SaveChanges();
                        MessageBox.Show("Veri Kaydedildi!");
                    }

                    using (var nesne = new EntityAyar())
                    {
                        var Salon = nesne.Salon.ToList();

                        dataGridView2.DataSource = Salon;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (var nesne = new EntityAyar())
                {
                    var Salon = nesne.Salon.ToList();

                    dataGridView2.DataSource = Salon;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null && comboBox4.SelectedItem != null && textBox3.Text != string.Empty && maskedTextBox2.Text != string.Empty)
            {
                try
                {
                    Seans seans = new Seans()
                    {
                        FilmAd = comboBox1.SelectedItem.ToString(),
                        FilmTarih = DateTime.Parse(comboBox2.SelectedItem.ToString()),
                        FilmSaat = TimeSpan.Parse(comboBox3.SelectedItem.ToString()),
                        FilmSalon = comboBox4.SelectedItem.ToString(),
                        MusteriAd = textBox3.Text,
                        TCKimlikNo = maskedTextBox2.Text
                    };

                    using (var nesne = new EntityAyar())
                    {
                        var Salon = nesne.Salon.FirstOrDefault(s => s.SalonAd == seans.FilmSalon);

                        if (Salon != null && Salon.Kapasite > 0)
                        {
                            nesne.Seans.Add(seans);
                            Salon.Kapasite -= 1;
                            nesne.SaveChanges();
                            MessageBox.Show("Veri Kaydedildi!");
                        }
                        else
                        {
                            MessageBox.Show("Seçilen Salonda Boş Koltuk Kalmamıştır.");
                        }
                    }

                    using (var nesne = new EntityAyar())
                    {
                        var Seans = nesne.Seans.ToList();

                        dataGridView3.DataSource = Seans;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakmayınız!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (var nesne = new EntityAyar())
                {
                    var Seans = nesne.Seans.ToList();

                    dataGridView3.DataSource = Seans;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            using (var nesne = new EntityAyar())
            {
                try
                {
                    var Film = nesne.Film.Select(f => f.FilmAd).ToList();

                    comboBox1.DataSource = Film;
                }
                catch
                {
                    MessageBox.Show("Film Kayıt Ediniz!");
                }
            }
        }

        private void comboBox4_MouseHover(object sender, EventArgs e)
        {
            using (var nesne = new EntityAyar())
            {
                try
                {
                    var Salon = nesne.Salon.Select(f => f.SalonAd).ToList();

                    comboBox4.DataSource = Salon;
                }
                catch
                {
                    MessageBox.Show("Salon Kayıt Ediniz!");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var nesne = new EntityAyar())
            {
                try
                {
                    var Tarih = nesne.Film.Where(f => f.FilmAd == comboBox1.SelectedItem.ToString()).Select(f => f.FilmTarih).ToList();

                    comboBox2.DataSource = Tarih;

                    var Saat = nesne.Film.Where(f => f.FilmAd == comboBox1.SelectedItem.ToString()).Select(f => new { f.Saat1, f.Saat2, f.Saat3, f.Saat4, f.Saat5, f.Saat6 }).FirstOrDefault();

                    if (Saat != null)
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Items.Add(Saat.Saat1.ToString());
                        comboBox3.Items.Add(Saat.Saat2.ToString());
                        comboBox3.Items.Add(Saat.Saat3.ToString());
                        comboBox3.Items.Add(Saat.Saat4.ToString());
                        comboBox3.Items.Add(Saat.Saat5.ToString());
                        comboBox3.Items.Add(Saat.Saat6.ToString());
                    }
                }
                catch { }
            }
        }
    }
}
