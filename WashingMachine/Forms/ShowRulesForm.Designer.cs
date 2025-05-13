namespace WashingMachine.Forms
{
    partial class ShowRulesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sensitivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pollution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rotation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detergent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_AddNewRule = new System.Windows.Forms.Button();
            this.button_DeleteSelectedRule = new System.Windows.Forms.Button();
            this.button_minimize = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeight = 40;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.Sensitivity,
            this.quantity,
            this.pollution,
            this.duration,
            this.rotation,
            this.detergent});
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 43;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView2.RowTemplate.Height = 35;
            this.dataGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.Size = new System.Drawing.Size(1307, 560);
            this.dataGridView2.TabIndex = 35;
            // 
            // no
            // 
            this.no.HeaderText = "No";
            this.no.Name = "no";
            this.no.Width = 60;
            // 
            // Sensitivity
            // 
            this.Sensitivity.HeaderText = "Sensitivity";
            this.Sensitivity.Name = "Sensitivity";
            this.Sensitivity.Width = 195;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "Quantity";
            this.quantity.Name = "quantity";
            this.quantity.Width = 195;
            // 
            // pollution
            // 
            this.pollution.HeaderText = "Pollution";
            this.pollution.Name = "pollution";
            this.pollution.Width = 195;
            // 
            // duration
            // 
            this.duration.HeaderText = "Duration";
            this.duration.Name = "duration";
            this.duration.Width = 196;
            // 
            // rotation
            // 
            this.rotation.HeaderText = "Rotation";
            this.rotation.Name = "rotation";
            this.rotation.Width = 196;
            // 
            // detergent
            // 
            this.detergent.HeaderText = "Detergent";
            this.detergent.Name = "detergent";
            this.detergent.Width = 205;
            // 
            // button_AddNewRule
            // 
            this.button_AddNewRule.Location = new System.Drawing.Point(12, 570);
            this.button_AddNewRule.Name = "button_AddNewRule";
            this.button_AddNewRule.Size = new System.Drawing.Size(323, 41);
            this.button_AddNewRule.TabIndex = 36;
            this.button_AddNewRule.Text = "Add New Rule";
            this.button_AddNewRule.UseVisualStyleBackColor = true;
            this.button_AddNewRule.Click += new System.EventHandler(this.button_AddNewRule_Click);
            // 
            // button_DeleteSelectedRule
            // 
            this.button_DeleteSelectedRule.Location = new System.Drawing.Point(365, 570);
            this.button_DeleteSelectedRule.Name = "button_DeleteSelectedRule";
            this.button_DeleteSelectedRule.Size = new System.Drawing.Size(323, 41);
            this.button_DeleteSelectedRule.TabIndex = 37;
            this.button_DeleteSelectedRule.Text = "Delete Rule";
            this.button_DeleteSelectedRule.UseVisualStyleBackColor = true;
            this.button_DeleteSelectedRule.Click += new System.EventHandler(this.button_DeleteSelectedRule_Click);
            // 
            // button_minimize
            // 
            this.button_minimize.BackColor = System.Drawing.Color.DimGray;
            this.button_minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_minimize.ForeColor = System.Drawing.Color.White;
            this.button_minimize.Location = new System.Drawing.Point(1195, 571);
            this.button_minimize.Name = "button_minimize";
            this.button_minimize.Size = new System.Drawing.Size(47, 42);
            this.button_minimize.TabIndex = 38;
            this.button_minimize.Text = "-";
            this.button_minimize.UseVisualStyleBackColor = false;
            this.button_minimize.Click += new System.EventHandler(this.button_minimize_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.DimGray;
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exit.ForeColor = System.Drawing.Color.Red;
            this.button_exit.Location = new System.Drawing.Point(1248, 571);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(47, 42);
            this.button_exit.TabIndex = 39;
            this.button_exit.Text = "X";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // ShowRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 619);
            this.ControlBox = false;
            this.Controls.Add(this.button_minimize);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_DeleteSelectedRule);
            this.Controls.Add(this.button_AddNewRule);
            this.Controls.Add(this.dataGridView2);
            this.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.Name = "ShowRulesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Rules";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sensitivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn pollution;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn rotation;
        private System.Windows.Forms.DataGridViewTextBoxColumn detergent;
        private System.Windows.Forms.Button button_AddNewRule;
        private System.Windows.Forms.Button button_DeleteSelectedRule;
        private System.Windows.Forms.Button button_minimize;
        private System.Windows.Forms.Button button_exit;
    }
}