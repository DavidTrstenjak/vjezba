using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LINQ_XML_dokumenti
{
    public partial class unos : Form
    {
        List<osoba> osobe = new List<osoba>();
        public unos()
        {
            InitializeComponent();
        }

        private void buttonUNESI_Click(object sender, EventArgs e)
        {
            osoba Osoba = new osoba(textBoxIme.Text, textBoxPrezime.Text, Convert.ToInt32(textBoxGodRod.Text));

            osobe.Add(Osoba);

            DialogResult upit = MessageBox.Show("Želite li upisati još osoba?", "Upit", 
                MessageBoxButtons.YesNo);

            if (upit == DialogResult.Yes)
            {
                textBoxIme.Clear();
                textBoxGodRod.Clear();
                textBoxPrezime.Clear();
            }
            else
            {
                var OsobeXML = new XDocument();

                OsobeXML.Add(new XElement("Osobe"));

                foreach (osoba o in osobe)
                {
                    var osobica = new XElement("Osoba", new XElement ("Ime", Osoba.Ime), 
                    new XElement ("Prezime", Osoba.Prezime), new XElement ("GodRod", Osoba.GodRod));
                    
                    OsobeXML.Root.Add(osobica);
                }

                this.Close();
            }
        }
    }
}
