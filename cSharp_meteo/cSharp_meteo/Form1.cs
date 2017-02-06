using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HttpUtils;
using Newtonsoft.Json;
using System.IO;

namespace cSharp_meteo
{
    public partial class Form1 : Form
    {
        Weather weatherResponse = new Weather();

        public Form1()
        {
            InitializeComponent();
            
            //Remplissage des comboBoxs avec les données de base
            cbx_ChooseCity.Items.Add("Neuchâtel");
            cbx_ChooseCity.Items.Add("La-Chaux-De-Fonds");
            cbx_ChooseCity.Items.Add("Bern");
            cbx_ChooseCity.Items.Add("Lausanne");

            cbx_ChooseDays.Items.Add("1");
            cbx_ChooseDays.Items.Add("2");
            cbx_ChooseDays.Items.Add("3");
            cbx_ChooseDays.Items.Add("4");
            cbx_ChooseDays.Items.Add("5");
            cbx_ChooseDays.SelectedIndex = 0;

            //Appel de fonction qui récupère les villes ajoutés précédemment
            GetFileCityNames();
        }

        /// <summary>
        /// Chaque fois que l'on sélectionne une ville, appel de fonction qui va afficher la météo pour cette ville seulement si nombre de jours à afficher est sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_ChoixVille_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_ChooseDays.SelectedItem != null)
                {
                    GetCurrencyWeather(cbx_ChooseCity.SelectedItem.ToString(), cbx_ChooseDays.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Chaque fois que l'on change le nombre de jours à afficher, appel de fonction qui va afficher la météo pour une ville sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_ChooseDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbx_ChooseCity.SelectedItem != null)
                {
                    GetCurrencyWeather(cbx_ChooseCity.SelectedItem.ToString(), cbx_ChooseDays.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>           _
        /// Clic sur le bouton |+|, Ajout de la ville dans le dropDown ChooseCity, appel de fonction qui va écrire la ville ajoutée dans un fichier texte
        /// </summary>          
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbx_EnterCityToAdd.Text != "")
                {
                    DialogResult dialogResult = MessageBox.Show("La ville suivante sera ajoutée à l'application : " + tbx_EnterCityToAdd.Text, "Confirmation", MessageBoxButtons.OKCancel);
                    if (dialogResult == DialogResult.OK)
                    {
                        MessageBox.Show("Ajout effectué !");
                        cbx_ChooseCity.Items.Add(tbx_EnterCityToAdd.Text);
                        WriteFileCityName(tbx_EnterCityToAdd.Text);
                        tbx_EnterCityToAdd.Text = "";
                    }
                    else if(dialogResult == DialogResult.Cancel)
                    {
                        MessageBox.Show("Ajout annulé !");
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez entrer le nom d'une ville à ajouter", "Message d'erreur", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Création de requête Json au service web météo
        /// Clear le groupBox ou s'affiche les prévisions pour une ville
        /// Création de labels pour afficher les prévisions
        /// </summary>
        /// <param name="CityName"></param>
        /// <param name="nbjours"></param>
        private void GetCurrencyWeather(string str_CityName, string str_Days)
        {
            Weather WeatherResponse = new Weather();
            int i_NbDays = Convert.ToInt32(str_Days);
            

            try
            {
                grpBox_Forecast.Text = str_CityName;

                //Requête de la météo au service web météo
                string endPoint = @"http://www.prevision-meteo.ch/services/json/" + str_CityName;
                var client = new RestClient(endPoint);
                var json = client.MakeRequest();
                object objResponse = JsonConvert.DeserializeObject(json, typeof(Weather));

                //Convertion dans le type requis
                WeatherResponse = (Weather)objResponse;

                grpBox_Forecast.Controls.Clear();
                
                //Création des labels header des tableaux
                Label lbl_Days = new Label();
                Label lbl_TMin = new Label();
                Label lbl_TMax = new Label();
                PictureBox pcb_Icon = new PictureBox();

                //Création des tableaux pour afficher la météo jusqu'aux jours demandés
                string[] Days = new string[5];
                string[] TemperatureMax = new string[5];
                string[] TemperatureMin = new string[5];
                string[] ImgIcone = new string[5];
                Days[0] = WeatherResponse.fcst_day_0.day_long.ToString();
                Days[1] = WeatherResponse.fcst_day_1.day_long.ToString();
                Days[2] = WeatherResponse.fcst_day_2.day_long.ToString();
                Days[3] = WeatherResponse.fcst_day_3.day_long.ToString();
                Days[4] = WeatherResponse.fcst_day_4.day_long.ToString();
                TemperatureMax[0] = WeatherResponse.fcst_day_0.tmax.ToString();
                TemperatureMax[1] = WeatherResponse.fcst_day_1.tmax.ToString();
                TemperatureMax[2] = WeatherResponse.fcst_day_2.tmax.ToString();
                TemperatureMax[3] = WeatherResponse.fcst_day_3.tmax.ToString();
                TemperatureMax[4] = WeatherResponse.fcst_day_4.tmax.ToString();
                TemperatureMin[0] = WeatherResponse.fcst_day_0.tmin.ToString();
                TemperatureMin[1] = WeatherResponse.fcst_day_1.tmin.ToString();
                TemperatureMin[2] = WeatherResponse.fcst_day_2.tmin.ToString();
                TemperatureMin[3] = WeatherResponse.fcst_day_3.tmin.ToString();
                TemperatureMin[4] = WeatherResponse.fcst_day_4.tmin.ToString();
                ImgIcone[0] = WeatherResponse.fcst_day_0.icon.ToString();
                ImgIcone[1] = WeatherResponse.fcst_day_1.icon.ToString();
                ImgIcone[2] = WeatherResponse.fcst_day_2.icon.ToString();
                ImgIcone[3] = WeatherResponse.fcst_day_3.icon.ToString();
                ImgIcone[4] = WeatherResponse.fcst_day_4.icon.ToString();
                
                if (WeatherResponse != null)
                {                 
                    Label lbl_DayHead = new Label();
                    lbl_DayHead.Left = 15;
                    lbl_DayHead.Top = 35;
                    lbl_DayHead.Width = 40;
                    lbl_DayHead.Height = 20;
                    lbl_DayHead.Text = "Jour";
                    lbl_DayHead.Font = new Font("Microsoft Sans Serif",12);

                    Label lbl_TMinHead = new Label();
                    lbl_TMinHead.Left = 80;
                    lbl_TMinHead.Top = 35;
                    lbl_TMinHead.Width = 80;
                    lbl_TMinHead.Height = 20;
                    lbl_TMinHead.Text = "T. Min";
                    lbl_TMinHead.Font = new Font("Microsoft Sans Serif", 12);

                    Label lbl_TMaxHead = new Label();
                    lbl_TMaxHead.Left = 160;
                    lbl_TMaxHead.Top = 35;
                    lbl_TMaxHead.Width = 80;
                    lbl_TMaxHead.Height = 20;
                    lbl_TMaxHead.Text = "T. Max";
                    lbl_TMaxHead.Font = new Font("Microsoft Sans Serif", 12);

                    Label lbl_IconHead = new Label();
                    lbl_IconHead.Left = 250;
                    lbl_IconHead.Top = 35;
                    lbl_IconHead.Width = 80;
                    lbl_IconHead.Height = 20;
                    lbl_IconHead.Text = "Image";
                    lbl_IconHead.Font = new Font("Microsoft Sans Serif", 12);

                    grpBox_Forecast.Controls.Add(lbl_DayHead);
                    grpBox_Forecast.Controls.Add(lbl_TMinHead);
                    grpBox_Forecast.Controls.Add(lbl_TMaxHead);
                    grpBox_Forecast.Controls.Add(lbl_IconHead);

                    //Pour chaque jour que l'on souhaite voir, créer une ligne de labels pour un jour précis
                    for (int i = 0; i < i_NbDays; i++)
                    {
                       /* A changer pour que l'actualisation se fasse bien au niveau des informations du temps*/
                        lbl_Days = new Label();
                        lbl_TMin = new Label();
                        lbl_TMax = new Label();
                        pcb_Icon = new PictureBox();

                        grpBox_Forecast.Controls.Add(lbl_Days);
                        grpBox_Forecast.Controls.Add(lbl_TMin);
                        grpBox_Forecast.Controls.Add(lbl_TMax);
                        grpBox_Forecast.Controls.Add(pcb_Icon);

                        lbl_Days.Text = Days[i];
                        lbl_Days.Left = lbl_DayHead.Left;
                        lbl_Days.Top = 80 + (i * 50);
                        lbl_Days.Width = 80;
                        lbl_Days.Height = 20;

                        lbl_TMin.Text = TemperatureMin[i];
                        lbl_TMin.Left = lbl_TMinHead.Left + 30;
                        lbl_TMin.Top = 80 + (i * 50);
                        lbl_TMin.Width = 60;
                        lbl_TMin.Height = 20;
                        lbl_TMin.ForeColor = Color.Blue;
                        lbl_TMin.TextAlign = ContentAlignment.MiddleLeft;

                        lbl_TMax.Text = TemperatureMax[i];
                        lbl_TMax.Left = lbl_TMaxHead.Left;
                        lbl_TMax.Top = 80 + (i * 50);
                        lbl_TMax.Width = 60;
                        lbl_TMax.Height = 20;
                        lbl_TMax.ForeColor = Color.Red;
                        lbl_TMax.TextAlign = ContentAlignment.MiddleCenter;

                        pcb_Icon.Load(ImgIcone[i]);
                        pcb_Icon.Left = lbl_IconHead.Left;
                        pcb_Icon.Top = 70 + (i * 50);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Une erreur s'est produite pendant la demande des prévisons !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops ! La météo de cette ville n'est pas disponible. Réessayez avec une autre.", "Réessayez", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Crée le fichier texte si il n'existe pas déjà et écrit le nom de la ville dans celui-ci
        /// </summary>
        /// <param name="CityName"></param>
        private void WriteFileCityName(string CityName)
        {
            try
            {
                string str_path = @"C:\Temp\cities.txt";
                
                //Ouverture de fichier texte
                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(str_path, true))
                {
                    file.WriteLine(CityName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Lis et ajoute au DropBox ChooseCity, chaque ville précédemment écrite dans le fichier texte  
        /// </summary>
        private void GetFileCityNames()
        {
            try 
            {
                    string[] lines = System.IO.File.ReadAllLines(@"C:\Temp\cities.txt");

                    foreach (string line in lines)
                    {
                        cbx_ChooseCity.Items.Add(line.ToString());
                    }
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
