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
using System.IO.Compression;
using System.Net;
using System.Diagnostics;

namespace EmpireLauncher7DTD
{
    public partial class LauncherEmpire : Form
    {
        public string path = "";
        public FtpWebRequest ftpRequest;
        public FtpWebResponse ftpResponse;
        public string ftpResponseList;
        public Stream responseStream;
        public StreamReader responseStreamReader;

        public LauncherEmpire()
        {
            InitializeComponent();
        }

        private void LauncherEmpire_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            button1.Parent = pictureBox1;
            button2.Parent = pictureBox1;
            button3.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            if(!File.Exists(Directory.GetCurrentDirectory() + "\\7DaysToDie_EAC.exe"))
            {
                MessageBox.Show("Pour un lancement plus rapide, mettez le launcher dans le dossier d'installation du jeu.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dossier.SelectedPath = Directory.GetCurrentDirectory();
                ExecuteDownload();
                Process.Start(Directory.GetCurrentDirectory() + "\\7DaysToDie_EAC.exe");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Veuillez sélectionner le dossier d'installation de 7 days to die.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dossier.ShowDialog();

            ExecuteDownload();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dossier.SelectedPath != "")
            {
                Process.Start(path + "..\\" + "7DaysToDie_EAC.exe");
            }
            else
            {
                MessageBox.Show("Vous devez d'abord choisir dans quel dossier votre jeu est installé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteDownload()
        {
            path = dossier.SelectedPath;

            if (path.Contains("common"))
            {

                if (!Directory.Exists(path + "\\mods"))
                {
                    Directory.CreateDirectory(path + "\\mods");
                }

                path = dossier.SelectedPath + "\\mods\\";

                path = @Path.GetFullPath(path);
                if (Directory.Exists(path + "..\\mods"))
                {
                    Directory.Delete(path + "..\\mods", true);
                }
                Directory.CreateDirectory(path + "..\\mods");

                ftpRequest = (FtpWebRequest)WebRequest.Create("ftp://176.165.0.32/mods.zip");
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.Credentials = new NetworkCredential("mods", "charcuterie");

                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                Stream responseStream = ftpResponse.GetResponseStream();
                StreamReader responseStreamReader = new StreamReader(responseStream);

                using (var outputFile = File.Create(path + "mods.zip"))
                {
                    responseStream.CopyTo(outputFile);
                }

                ZipFile.ExtractToDirectory(path + "mods.zip", path);

                File.Delete(path + "mods.zip");

                responseStream.Close();
                responseStreamReader.Close();

                ftpResponseList = File.ReadAllText(path + "mdp.txt");

                MessageBox.Show("Le mot de passe pour se connecter au serveur : " + ftpResponseList, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Le jeu doit se trouver dans le répertoire de 'common' de Steam.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
