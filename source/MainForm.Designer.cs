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
            this.buttonRotate = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBoxXRotate = new System.Windows.Forms.TextBox();
            this.textBoxYRotate = new System.Windows.Forms.TextBox();
            this.textBoxZRotate = new System.Windows.Forms.TextBox();
            this.xRotate = new System.Windows.Forms.Label();
            this.yRotate = new System.Windows.Forms.Label();
            this.zRotate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxZMove = new System.Windows.Forms.TextBox();
            this.textBoxYMove = new System.Windows.Forms.TextBox();
            this.textBoxXMove = new System.Windows.Forms.TextBox();
            this.buttonMove = new System.Windows.Forms.Button();
            this.coordinatesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // mainCanvas
            // 
            this.mainCanvas.BackColor = System.Drawing.Color.Gray;
            this.mainCanvas.Location = new System.Drawing.Point(2, 3);
            this.mainCanvas.Name = "mainCanvas";
            this.mainCanvas.Size = new System.Drawing.Size(800, 600);
            this.mainCanvas.TabIndex = 0;
            this.mainCanvas.TabStop = false;
            this.mainCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainCanvas_MouseDown);
            this.mainCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainCanvas_MouseMove);
            this.mainCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainCanvas_MouseUp);
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
            // buttonRotate
            // 
            this.buttonRotate.Location = new System.Drawing.Point(878, 308);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(47, 30);
            this.buttonRotate.TabIndex = 4;
            this.buttonRotate.Text = "Rotate";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
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
            // textBoxXRotate
            // 
            this.textBoxXRotate.Location = new System.Drawing.Point(831, 288);
            this.textBoxXRotate.Name = "textBoxXRotate";
            this.textBoxXRotate.Size = new System.Drawing.Size(33, 20);
            this.textBoxXRotate.TabIndex = 6;
            this.textBoxXRotate.Text = "0";
            // 
            // textBoxYRotate
            // 
            this.textBoxYRotate.Location = new System.Drawing.Point(831, 314);
            this.textBoxYRotate.Name = "textBoxYRotate";
            this.textBoxYRotate.Size = new System.Drawing.Size(33, 20);
            this.textBoxYRotate.TabIndex = 7;
            this.textBoxYRotate.Text = "0";
            // 
            // textBoxZRotate
            // 
            this.textBoxZRotate.Location = new System.Drawing.Point(831, 340);
            this.textBoxZRotate.Name = "textBoxZRotate";
            this.textBoxZRotate.Size = new System.Drawing.Size(33, 20);
            this.textBoxZRotate.TabIndex = 8;
            this.textBoxZRotate.Text = "0";
            // 
            // xRotate
            // 
            this.xRotate.AutoSize = true;
            this.xRotate.Location = new System.Drawing.Point(809, 292);
            this.xRotate.Name = "xRotate";
            this.xRotate.Size = new System.Drawing.Size(12, 13);
            this.xRotate.TabIndex = 9;
            this.xRotate.Text = "x";
            // 
            // yRotate
            // 
            this.yRotate.AutoSize = true;
            this.yRotate.Location = new System.Drawing.Point(809, 317);
            this.yRotate.Name = "yRotate";
            this.yRotate.Size = new System.Drawing.Size(12, 13);
            this.yRotate.TabIndex = 10;
            this.yRotate.Text = "y";
            // 
            // zRotate
            // 
            this.zRotate.AutoSize = true;
            this.zRotate.Location = new System.Drawing.Point(809, 343);
            this.zRotate.Name = "zRotate";
            this.zRotate.Size = new System.Drawing.Size(12, 13);
            this.zRotate.TabIndex = 11;
            this.zRotate.Text = "z";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(809, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(809, 410);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(809, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "x";
            // 
            // textBoxZMove
            // 
            this.textBoxZMove.Location = new System.Drawing.Point(831, 433);
            this.textBoxZMove.Name = "textBoxZMove";
            this.textBoxZMove.Size = new System.Drawing.Size(33, 20);
            this.textBoxZMove.TabIndex = 15;
            this.textBoxZMove.Text = "0";
            // 
            // textBoxYMove
            // 
            this.textBoxYMove.Location = new System.Drawing.Point(831, 407);
            this.textBoxYMove.Name = "textBoxYMove";
            this.textBoxYMove.Size = new System.Drawing.Size(33, 20);
            this.textBoxYMove.TabIndex = 14;
            this.textBoxYMove.Text = "0";
            // 
            // textBoxXMove
            // 
            this.textBoxXMove.Location = new System.Drawing.Point(831, 381);
            this.textBoxXMove.Name = "textBoxXMove";
            this.textBoxXMove.Size = new System.Drawing.Size(33, 20);
            this.textBoxXMove.TabIndex = 13;
            this.textBoxXMove.Text = "0";
            // 
            // buttonMove
            // 
            this.buttonMove.Location = new System.Drawing.Point(878, 401);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(47, 30);
            this.buttonMove.TabIndex = 12;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // coordinatesLabel
            // 
            this.coordinatesLabel.AutoSize = true;
            this.coordinatesLabel.Location = new System.Drawing.Point(23, 606);
            this.coordinatesLabel.Name = "coordinatesLabel";
            this.coordinatesLabel.Size = new System.Drawing.Size(0, 13);
            this.coordinatesLabel.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(940, 643);
            this.Controls.Add(this.coordinatesLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxZMove);
            this.Controls.Add(this.textBoxYMove);
            this.Controls.Add(this.textBoxXMove);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.zRotate);
            this.Controls.Add(this.yRotate);
            this.Controls.Add(this.xRotate);
            this.Controls.Add(this.textBoxZRotate);
            this.Controls.Add(this.textBoxYRotate);
            this.Controls.Add(this.textBoxXRotate);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonRotate);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.mainCanvas);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainCanvas;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBoxXRotate;
        private System.Windows.Forms.TextBox textBoxYRotate;
        private System.Windows.Forms.TextBox textBoxZRotate;
        private System.Windows.Forms.Label xRotate;
        private System.Windows.Forms.Label yRotate;
        private System.Windows.Forms.Label zRotate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxZMove;
        private System.Windows.Forms.TextBox textBoxYMove;
        private System.Windows.Forms.TextBox textBoxXMove;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Label coordinatesLabel;
    }
}

