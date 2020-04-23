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
using System.Security.Cryptography.X509Certificates;

namespace EmpireLauncher7DTD
{
    public partial class LauncherEmpire : Form
    {
        public string path = "";
        public string ftpResponseList;
        public Stream responseStream;
        public StreamReader responseStreamReader;
        public Stopwatch sw = new Stopwatch();
        public string urlAddress = "http://iazlur.fr/mods.zip";

        public LauncherEmpire()
        {
            InitializeComponent();
        }

        private void LauncherEmpire_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            downloadLabel.Parent = pictureBox1;
            percLabel.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            if (!File.Exists(Directory.GetCurrentDirectory() + "\\7DaysToDie_EAC.exe"))
            {
                Verify();
                ExecuteDownload();
            }
            else
            {
                dossier.SelectedPath = Directory.GetCurrentDirectory();
                ExecuteDownload();
            }
        }

        private void Verify()
        {
            MessageBox.Show("Pour un lancement plus rapide, mettez le launcher dans le dossier d'installation du jeu.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SelectPath();

            if (File.Exists(dossier.SelectedPath + "\\7DaysToDie_EAC.exe"))
            {
                return;
            }
            else
            {
                MessageBox.Show("Vous devez d'abord choisir dans quel dossier votre jeu est installé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Verify();
            }
        }

        private void SelectPath()
        {
            MessageBox.Show("Veuillez sélectionner le dossier d'installation de 7 days to die.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dossier.ShowDialog();
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

                using (var webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                    Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                    sw.Start();

                    try
                    {
                        webClient.DownloadFileAsync(URL, path + "mods.zip");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Le jeu doit se trouver dans le répertoire de 'common' de Steam.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            downloadLabel.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            progressBar1.Value = e.ProgressPercentage;

            // Show the percentage on our label.
            percLabel.Text = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            downloadLabel.Text += " " + string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
        }

        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            ZipFile.ExtractToDirectory(path + "mods.zip", path);

            File.Delete(path + "mods.zip");

            ftpResponseList = File.ReadAllText(path + "mdp.txt");

            MessageBox.Show("Le mot de passe pour se connecter au serveur : " + ftpResponseList, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Process.Start(path + "..\\" + "7DaysToDie_EAC.exe");

            Application.Exit();
        }
    }
}
