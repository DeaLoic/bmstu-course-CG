namespace PerlinLandscape
{
    partial class MainForm
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
            this.mainCanvas = new System.Windows.Forms.PictureBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // mainCanvas
            // 
            this.mainCanvas.BackColor = System.Drawing.Color.White;
            this.mainCanvas.Location = new System.Drawing.Point(2, 3);
            this.mainCanvas.Name = "mainCanvas";
            this.mainCanvas.Size = new System.Drawing.Size(800, 600);
            this.mainCanvas.TabIndex = 0;
            this.mainCanvas.TabStop = false;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(855, 12);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(78, 36);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(854, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(854, 104);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(855, 145);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(854, 184);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 31);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 643);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.mainCanvas);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainCanvas;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

