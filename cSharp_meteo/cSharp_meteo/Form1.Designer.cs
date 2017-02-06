namespace cSharp_meteo
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvl_ChooseCity = new System.Windows.Forms.Label();
            this.lbl_ChooseDays = new System.Windows.Forms.Label();
            this.cbx_ChooseCity = new System.Windows.Forms.ComboBox();
            this.lbl_EnterCityToAdd = new System.Windows.Forms.Label();
            this.tbx_EnterCityToAdd = new System.Windows.Forms.TextBox();
            this.btn_AddCity = new System.Windows.Forms.Button();
            this.cbx_ChooseDays = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBox_Forecast = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // lvl_ChooseCity
            // 
            this.lvl_ChooseCity.AutoSize = true;
            this.lvl_ChooseCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvl_ChooseCity.Location = new System.Drawing.Point(13, 13);
            this.lvl_ChooseCity.Name = "lvl_ChooseCity";
            this.lvl_ChooseCity.Size = new System.Drawing.Size(108, 20);
            this.lvl_ChooseCity.TabIndex = 0;
            this.lvl_ChooseCity.Text = "Ville à afficher";
            // 
            // lbl_ChooseDays
            // 
            this.lbl_ChooseDays.AutoSize = true;
            this.lbl_ChooseDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChooseDays.Location = new System.Drawing.Point(199, 13);
            this.lbl_ChooseDays.Name = "lbl_ChooseDays";
            this.lbl_ChooseDays.Size = new System.Drawing.Size(125, 20);
            this.lbl_ChooseDays.TabIndex = 1;
            this.lbl_ChooseDays.Text = "Nombre de jours";
            // 
            // cbx_ChooseCity
            // 
            this.cbx_ChooseCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ChooseCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_ChooseCity.FormattingEnabled = true;
            this.cbx_ChooseCity.Location = new System.Drawing.Point(17, 46);
            this.cbx_ChooseCity.Name = "cbx_ChooseCity";
            this.cbx_ChooseCity.Size = new System.Drawing.Size(161, 28);
            this.cbx_ChooseCity.TabIndex = 2;
            this.cbx_ChooseCity.SelectedIndexChanged += new System.EventHandler(this.cbx_ChoixVille_SelectedIndexChanged);
            // 
            // lbl_EnterCityToAdd
            // 
            this.lbl_EnterCityToAdd.AutoSize = true;
            this.lbl_EnterCityToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EnterCityToAdd.Location = new System.Drawing.Point(13, 96);
            this.lbl_EnterCityToAdd.Name = "lbl_EnterCityToAdd";
            this.lbl_EnterCityToAdd.Size = new System.Drawing.Size(165, 20);
            this.lbl_EnterCityToAdd.TabIndex = 5;
            this.lbl_EnterCityToAdd.Text = "Ville à ajouter à la liste";
            // 
            // tbx_EnterCityToAdd
            // 
            this.tbx_EnterCityToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_EnterCityToAdd.Location = new System.Drawing.Point(17, 128);
            this.tbx_EnterCityToAdd.Name = "tbx_EnterCityToAdd";
            this.tbx_EnterCityToAdd.Size = new System.Drawing.Size(161, 26);
            this.tbx_EnterCityToAdd.TabIndex = 6;
            // 
            // btn_AddCity
            // 
            this.btn_AddCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddCity.Location = new System.Drawing.Point(203, 128);
            this.btn_AddCity.Name = "btn_AddCity";
            this.btn_AddCity.Size = new System.Drawing.Size(28, 26);
            this.btn_AddCity.TabIndex = 7;
            this.btn_AddCity.Text = "+";
            this.btn_AddCity.UseVisualStyleBackColor = true;
            this.btn_AddCity.Click += new System.EventHandler(this.btn_Ajouter_Click);
            // 
            // cbx_ChooseDays
            // 
            this.cbx_ChooseDays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_ChooseDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_ChooseDays.FormattingEnabled = true;
            this.cbx_ChooseDays.Location = new System.Drawing.Point(203, 46);
            this.cbx_ChooseDays.Name = "cbx_ChooseDays";
            this.cbx_ChooseDays.Size = new System.Drawing.Size(39, 28);
            this.cbx_ChooseDays.TabIndex = 10;
            this.cbx_ChooseDays.SelectedIndexChanged += new System.EventHandler(this.cbx_ChooseDays_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(12, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 2);
            this.label1.TabIndex = 11;
            // 
            // grpBox_Forecast
            // 
            this.grpBox_Forecast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBox_Forecast.Location = new System.Drawing.Point(12, 187);
            this.grpBox_Forecast.Name = "grpBox_Forecast";
            this.grpBox_Forecast.Size = new System.Drawing.Size(302, 354);
            this.grpBox_Forecast.TabIndex = 12;
            this.grpBox_Forecast.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 553);
            this.Controls.Add(this.grpBox_Forecast);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_ChooseDays);
            this.Controls.Add(this.btn_AddCity);
            this.Controls.Add(this.tbx_EnterCityToAdd);
            this.Controls.Add(this.lbl_EnterCityToAdd);
            this.Controls.Add(this.cbx_ChooseCity);
            this.Controls.Add(this.lbl_ChooseDays);
            this.Controls.Add(this.lvl_ChooseCity);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(342, 591);
            this.MinimumSize = new System.Drawing.Size(342, 272);
            this.Name = "Form1";
            this.Text = "Web Service Client Consumer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lvl_ChooseCity;
        private System.Windows.Forms.Label lbl_ChooseDays;
        private System.Windows.Forms.ComboBox cbx_ChooseCity;
        private System.Windows.Forms.Label lbl_EnterCityToAdd;
        private System.Windows.Forms.TextBox tbx_EnterCityToAdd;
        private System.Windows.Forms.Button btn_AddCity;
        private System.Windows.Forms.ComboBox cbx_ChooseDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBox_Forecast;
    }
}

