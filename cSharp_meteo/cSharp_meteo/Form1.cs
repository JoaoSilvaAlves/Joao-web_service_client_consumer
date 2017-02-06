﻿using System;
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
                    cbx_ChooseCity.Items.Add(tbx_EnterCityToAdd.Text);
                    WriteFileCityName(tbx_EnterCityToAdd.Text);
                    tbx_EnterCityToAdd.Text = "";
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
        private void GetCurrencyWeather(string strCityName, string strDays)
        {
            Weather WeatherResponse = new Weather();
            int iNbDays = Convert.ToInt32(strDays);
            

            try
            {
                grpBox_Forecast.Text = strCityName;

                //Requête de la météo au service web météo
                string endPoint = @"http://www.prevision-meteo.ch/services/json/" + strCityName;
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
                    Label labelDayHead = new Label();
                    labelDayHead.Left = 15;
                    labelDayHead.Top = 35;
                    labelDayHead.Width = 40;
                    labelDayHead.Height = 20;
                    labelDayHead.Text = "Jour";
                    labelDayHead.Font = new Font("Microsoft Sans Serif",12);

                    Label labelTMinHead = new Label();
                    labelTMinHead.Left = 80;
                    labelTMinHead.Top = 35;
                    labelTMinHead.Width = 80;
                    labelTMinHead.Height = 20;
                    labelTMinHead.Text = "T. Min";
                    labelTMinHead.Font = new Font("Microsoft Sans Serif", 12);

                    Label labelTMaxHead = new Label();
                    labelTMaxHead.Left = 160;
                    labelTMaxHead.Top = 35;
                    labelTMaxHead.Width = 80;
                    labelTMaxHead.Height = 20;
                    labelTMaxHead.Text = "T. Max";
                    labelTMaxHead.Font = new Font("Microsoft Sans Serif", 12);

                    Label labelIconHead = new Label();
                    labelIconHead.Left = 250;
                    labelIconHead.Top = 35;
                    labelIconHead.Width = 80;
                    labelIconHead.Height = 20;
                    labelIconHead.Text = "Image";
                    labelIconHead.Font = new Font("Microsoft Sans Serif", 12);

                    grpBox_Forecast.Controls.Add(labelDayHead);
                    grpBox_Forecast.Controls.Add(labelTMinHead);
                    grpBox_Forecast.Controls.Add(labelTMaxHead);
                    grpBox_Forecast.Controls.Add(labelIconHead);

                    //Pour chaque jour que l'on souhaite voir, créer une ligne de labels pour un jour précis
                    for (int i = 0; i < iNbDays; i++)
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
                        lbl_Days.Left = labelDayHead.Left;
                        lbl_Days.Top = 80 + (i * 50);
                        lbl_Days.Width = 80;
                        lbl_Days.Height = 20;

                        lbl_TMin.Text = TemperatureMin[i];
                        lbl_TMin.Left = labelTMinHead.Left + 30;
                        lbl_TMin.Top = 80 + (i * 50);
                        lbl_TMin.Width = 60;
                        lbl_TMin.Height = 20;
                        lbl_TMin.ForeColor = Color.Blue;
                        lbl_TMin.TextAlign = ContentAlignment.MiddleLeft;

                        lbl_TMax.Text = TemperatureMax[i];
                        lbl_TMax.Left = labelTMaxHead.Left;
                        lbl_TMax.Top = 80 + (i * 50);
                        lbl_TMax.Width = 60;
                        lbl_TMax.Height = 20;
                        lbl_TMax.ForeColor = Color.Red;
                        lbl_TMax.TextAlign = ContentAlignment.MiddleCenter;

                        pcb_Icon.Load(ImgIcone[i]);
                        pcb_Icon.Left = labelIconHead.Left;
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
                string path = @"C:\Temp\cities.txt";

                if (!File.Exists(path))
                {
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(path, true))
                    {
                        file.WriteLine(CityName);
                    }
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
