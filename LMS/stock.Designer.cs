namespace LMS
{
    partial class stock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(stock));
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.viewsupplier_btn = new System.Windows.Forms.Button();
            this.updateqty_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addqty_btn = new System.Windows.Forms.Button();
            this.subqty_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(150, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 32);
            this.label7.TabIndex = 38;
            this.label7.Text = "View Books Stock";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(14, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(552, 199);
            this.dataGridView1.TabIndex = 39;
            // 
            // viewsupplier_btn
            // 
            this.viewsupplier_btn.BackColor = System.Drawing.Color.Black;
            this.viewsupplier_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewsupplier_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewsupplier_btn.ForeColor = System.Drawing.Color.White;
            this.viewsupplier_btn.Location = new System.Drawing.Point(111, 293);
            this.viewsupplier_btn.Name = "viewsupplier_btn";
            this.viewsupplier_btn.Size = new System.Drawing.Size(107, 43);
            this.viewsupplier_btn.TabIndex = 40;
            this.viewsupplier_btn.Text = "View Supplier Info";
            this.viewsupplier_btn.UseVisualStyleBackColor = false;
            this.viewsupplier_btn.Click += new System.EventHandler(this.viewsupplier_btn_Click);
            // 
            // updateqty_btn
            // 
            this.updateqty_btn.BackColor = System.Drawing.Color.Black;
            this.updateqty_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateqty_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateqty_btn.ForeColor = System.Drawing.Color.White;
            this.updateqty_btn.Location = new System.Drawing.Point(224, 293);
            this.updateqty_btn.Name = "updateqty_btn";
            this.updateqty_btn.Size = new System.Drawing.Size(112, 43);
            this.updateqty_btn.TabIndex = 41;
            this.updateqty_btn.Text = "Update\r\nQuantity";
            this.updateqty_btn.UseVisualStyleBackColor = false;
            this.updateqty_btn.Click += new System.EventHandler(this.updateqty_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(392, 303);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(27, 22);
            this.textBox1.TabIndex = 42;
            this.textBox1.Text = "0";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // addqty_btn
            // 
            this.addqty_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addqty_btn.BackgroundImage")));
            this.addqty_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addqty_btn.Enabled = false;
            this.addqty_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addqty_btn.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addqty_btn.Location = new System.Drawing.Point(346, 296);
            this.addqty_btn.Name = "addqty_btn";
            this.addqty_btn.Size = new System.Drawing.Size(37, 31);
            this.addqty_btn.TabIndex = 43;
            this.addqty_btn.UseVisualStyleBackColor = true;
            this.addqty_btn.Click += new System.EventHandler(this.addqty_btn_Click);
            // 
            // subqty_btn
            // 
            this.subqty_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("subqty_btn.BackgroundImage")));
            this.subqty_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subqty_btn.Enabled = false;
            this.subqty_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subqty_btn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subqty_btn.Location = new System.Drawing.Point(425, 296);
            this.subqty_btn.Name = "subqty_btn";
            this.subqty_btn.Size = new System.Drawing.Size(33, 31);
            this.subqty_btn.TabIndex = 44;
            this.subqty_btn.UseVisualStyleBackColor = true;
            this.subqty_btn.Click += new System.EventHandler(this.subqty_btn_Click);
            // 
            // stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(578, 355);
            this.Controls.Add(this.subqty_btn);
            this.Controls.Add(this.addqty_btn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.updateqty_btn);
            this.Controls.Add(this.viewsupplier_btn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label7);
            this.Name = "stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "stock";
            this.Load += new System.EventHandler(this.stock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button viewsupplier_btn;
        private System.Windows.Forms.Button updateqty_btn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addqty_btn;
        private System.Windows.Forms.Button subqty_btn;
    }
}