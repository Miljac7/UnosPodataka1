using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Text.RegularExpressions;

namespace UNosPodataka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ime = Ime.Text;
            string prezime = Prezime.Text;
            string godinaRodjenja = GodinaRodjenja.Text;
            string email = Email.Text;

       
            if (string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime) || string.IsNullOrWhiteSpace(godinaRodjenja) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Unesite podatke.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Unesite ispravnu e-mail adresu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string filePath = "korisnici.csv";
            string delimiter = ",";
            bool appendHeader = !File.Exists(filePath);

            using (StreamWriter writer = new StreamWriter(filePath, true)) 
            {
                if (appendHeader)
                {
                    writer.WriteLine("Ime,Prezime,Godina roðenja,E-mail");
                }

                writer.WriteLine($"{ime}{delimiter}{prezime}{delimiter}{godinaRodjenja}{delimiter}{email}");
            }

            MessageBox.Show("Podaci su spremljeni.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearFields();
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void ClearFields()
        {
            Ime.Clear();
            Prezime.Clear();
            GodinaRodjenja.Clear();
            Email.Clear();
        }

       }
}
