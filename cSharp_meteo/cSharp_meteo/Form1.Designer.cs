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
            this.components = new System.ComponentModel.Container();
            this.lvl_ChoixVille = new System.Windows.Forms.Label();
            this.lbl_ChoixJours = new System.Windows.Forms.Label();
            this.cbx_ChoixVille = new System.Windows.Forms.ComboBox();
            this.nUpDown_nbJours = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbl_VilleAjouter = new System.Windows.Forms.Label();
            this.tbx_VilleAjouter = new System.Windows.Forms.TextBox();
            this.btn_Ajouter = new System.Windows.Forms.Button();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.lbl_VilleChoisie = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown_nbJours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lvl_ChoixVille
            // 
            this.lvl_ChoixVille.AutoSize = true;
            this.lvl_ChoixVille.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvl_ChoixVille.Location = new System.Drawing.Point(13, 13);
            this.lvl_ChoixVille.Name = "lvl_ChoixVille";
            this.lvl_ChoixVille.Size = new System.Drawing.Size(108, 20);
            this.lvl_ChoixVille.TabIndex = 0;
            this.lvl_ChoixVille.Text = "Ville à afficher";
            // 
            // lbl_ChoixJours
            // 
            this.lbl_ChoixJours.AutoSize = true;
            this.lbl_ChoixJours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChoixJours.Location = new System.Drawing.Point(199, 13);
            this.lbl_ChoixJours.Name = "lbl_ChoixJours";
            this.lbl_ChoixJours.Size = new System.Drawing.Size(125, 20);
            this.lbl_ChoixJours.TabIndex = 1;
            this.lbl_ChoixJours.Text = "Nombre de jours";
            // 
            // cbx_ChoixVille
            // 
            this.cbx_ChoixVille.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbx_ChoixVille.FormattingEnabled = true;
            this.cbx_ChoixVille.Items.AddRange(new object[] {
            "Neuchâtel",
            "La Chaux-De-Fonds",
            "Bern",
            "Lausanne"});
            this.cbx_ChoixVille.Location = new System.Drawing.Point(17, 46);
            this.cbx_ChoixVille.Name = "cbx_ChoixVille";
            this.cbx_ChoixVille.Size = new System.Drawing.Size(161, 28);
            this.cbx_ChoixVille.TabIndex = 2;
            // 
            // nUpDown_nbJours
            // 
            this.nUpDown_nbJours.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUpDown_nbJours.Location = new System.Drawing.Point(203, 46);
            this.nUpDown_nbJours.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUpDown_nbJours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUpDown_nbJours.Name = "nUpDown_nbJours";
            this.nUpDown_nbJours.Size = new System.Drawing.Size(39, 26);
            this.nUpDown_nbJours.TabIndex = 3;
            this.nUpDown_nbJours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lbl_VilleAjouter
            // 
            this.lbl_VilleAjouter.AutoSize = true;
            this.lbl_VilleAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VilleAjouter.Location = new System.Drawing.Point(13, 96);
            this.lbl_VilleAjouter.Name = "lbl_VilleAjouter";
            this.lbl_VilleAjouter.Size = new System.Drawing.Size(165, 20);
            this.lbl_VilleAjouter.TabIndex = 5;
            this.lbl_VilleAjouter.Text = "Ville à ajouter à la liste";
            // 
            // tbx_VilleAjouter
            // 
            this.tbx_VilleAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_VilleAjouter.Location = new System.Drawing.Point(17, 128);
            this.tbx_VilleAjouter.Name = "tbx_VilleAjouter";
            this.tbx_VilleAjouter.Size = new System.Drawing.Size(161, 26);
            this.tbx_VilleAjouter.TabIndex = 6;
            // 
            // btn_Ajouter
            // 
            this.btn_Ajouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ajouter.Location = new System.Drawing.Point(203, 128);
            this.btn_Ajouter.Name = "btn_Ajouter";
            this.btn_Ajouter.Size = new System.Drawing.Size(28, 26);
            this.btn_Ajouter.TabIndex = 7;
            this.btn_Ajouter.Text = "+";
            this.btn_Ajouter.UseVisualStyleBackColor = true;
            // 
            // lbl_VilleChoisie
            // 
            this.lbl_VilleChoisie.AutoSize = true;
            this.lbl_VilleChoisie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VilleChoisie.Location = new System.Drawing.Point(81, 200);
            this.lbl_VilleChoisie.Name = "lbl_VilleChoisie";
            this.lbl_VilleChoisie.Size = new System.Drawing.Size(161, 20);
            this.lbl_VilleChoisie.TabIndex = 8;
            this.lbl_VilleChoisie.Text = "Sélectionnez une ville";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(13, 256);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(311, 211);
            this.dgv.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 553);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lbl_VilleChoisie);
            this.Controls.Add(this.btn_Ajouter);
            this.Controls.Add(this.tbx_VilleAjouter);
            this.Controls.Add(this.lbl_VilleAjouter);
            this.Controls.Add(this.nUpDown_nbJours);
            this.Controls.Add(this.cbx_ChoixVille);
            this.Controls.Add(this.lbl_ChoixJours);
            this.Controls.Add(this.lvl_ChoixVille);
            this.Name = "Form1";
            this.Text = "Web Service Client Consumer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown_nbJours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lvl_ChoixVille;
        private System.Windows.Forms.Label lbl_ChoixJours;
        private System.Windows.Forms.ComboBox cbx_ChoixVille;
        private System.Windows.Forms.NumericUpDown nUpDown_nbJours;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbl_VilleAjouter;
        private System.Windows.Forms.TextBox tbx_VilleAjouter;
        private System.Windows.Forms.Button btn_Ajouter;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.Label lbl_VilleChoisie;
        private System.Windows.Forms.DataGridView dgv;
    }
}

