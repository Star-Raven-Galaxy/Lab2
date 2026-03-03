namespace Lab2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.btnSetPriority = new System.Windows.Forms.Button();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblCurrentPriority = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupAffinity = new System.Windows.Forms.GroupBox();
            this.btnApplyAffinity = new System.Windows.Forms.Button();
            this.lblHexMask = new System.Windows.Forms.Label();
            this.lblBinaryMask = new System.Windows.Forms.Label();
            this.flowCores = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.groupAffinity.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProcesses
            // 
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Location = new System.Drawing.Point(12, 13);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.Size = new System.Drawing.Size(918, 486);
            this.dgvProcesses.TabIndex = 0;
            // 
            // btnSetPriority
            // 
            this.btnSetPriority.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.btnSetPriority.Location = new System.Drawing.Point(149, 506);
            this.btnSetPriority.Name = "btnSetPriority";
            this.btnSetPriority.Size = new System.Drawing.Size(94, 45);
            this.btnSetPriority.TabIndex = 1;
            this.btnSetPriority.Text = "Выбрать приоритет";
            this.btnSetPriority.UseVisualStyleBackColor = true;
            this.btnSetPriority.Click += new System.EventHandler(this.btnSetPriority_Click);
            // 
            // cmbPriority
            // 
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(22, 505);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(121, 22);
            this.cmbPriority.TabIndex = 2;
            // 
            // lblCurrentPriority
            // 
            this.lblCurrentPriority.AutoSize = true;
            this.lblCurrentPriority.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.lblCurrentPriority.Location = new System.Drawing.Point(249, 514);
            this.lblCurrentPriority.Name = "lblCurrentPriority";
            this.lblCurrentPriority.Size = new System.Drawing.Size(35, 14);
            this.lblCurrentPriority.TabIndex = 3;
            this.lblCurrentPriority.Text = "label1";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // groupAffinity
            // 
            this.groupAffinity.Controls.Add(this.btnApplyAffinity);
            this.groupAffinity.Controls.Add(this.lblHexMask);
            this.groupAffinity.Controls.Add(this.lblBinaryMask);
            this.groupAffinity.Controls.Add(this.flowCores);
            this.groupAffinity.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.groupAffinity.Location = new System.Drawing.Point(936, 13);
            this.groupAffinity.Name = "groupAffinity";
            this.groupAffinity.Size = new System.Drawing.Size(252, 486);
            this.groupAffinity.TabIndex = 4;
            this.groupAffinity.TabStop = false;
            this.groupAffinity.Text = "CPU Affinity";
            // 
            // btnApplyAffinity
            // 
            this.btnApplyAffinity.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.btnApplyAffinity.Location = new System.Drawing.Point(32, 452);
            this.btnApplyAffinity.Name = "btnApplyAffinity";
            this.btnApplyAffinity.Size = new System.Drawing.Size(75, 25);
            this.btnApplyAffinity.TabIndex = 3;
            this.btnApplyAffinity.Text = "Изменить";
            this.btnApplyAffinity.UseVisualStyleBackColor = true;
            this.btnApplyAffinity.Click += new System.EventHandler(this.btnApplyAffinity_Click);
            // 
            // lblHexMask
            // 
            this.lblHexMask.AutoSize = true;
            this.lblHexMask.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.lblHexMask.Location = new System.Drawing.Point(29, 435);
            this.lblHexMask.Name = "lblHexMask";
            this.lblHexMask.Size = new System.Drawing.Size(35, 14);
            this.lblHexMask.TabIndex = 2;
            this.lblHexMask.Text = "label1";
            // 
            // lblBinaryMask
            // 
            this.lblBinaryMask.AutoSize = true;
            this.lblBinaryMask.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.lblBinaryMask.Location = new System.Drawing.Point(29, 421);
            this.lblBinaryMask.Name = "lblBinaryMask";
            this.lblBinaryMask.Size = new System.Drawing.Size(35, 14);
            this.lblBinaryMask.TabIndex = 1;
            this.lblBinaryMask.Text = "label1";
            // 
            // flowCores
            // 
            this.flowCores.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.flowCores.Location = new System.Drawing.Point(32, 20);
            this.flowCores.Name = "flowCores";
            this.flowCores.Size = new System.Drawing.Size(200, 381);
            this.flowCores.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 561);
            this.Controls.Add(this.groupAffinity);
            this.Controls.Add(this.lblCurrentPriority);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.btnSetPriority);
            this.Controls.Add(this.dgvProcesses);
            this.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 9F);
            this.Name = "Form1";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.groupAffinity.ResumeLayout(false);
            this.groupAffinity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.Button btnSetPriority;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblCurrentPriority;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupAffinity;
        private System.Windows.Forms.FlowLayoutPanel flowCores;
        private System.Windows.Forms.Button btnApplyAffinity;
        private System.Windows.Forms.Label lblHexMask;
        private System.Windows.Forms.Label lblBinaryMask;
    }
}

