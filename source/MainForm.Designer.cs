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
            this.updateButton = new System.Windows.Forms.Button();
            this.buttonRotate = new System.Windows.Forms.Button();
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
            this.label4 = new System.Windows.Forms.Label();
            this.textPolygonStep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textMaxHeight = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lightToCamera = new System.Windows.Forms.Button();
            this.animation = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mapSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textPerlinKnot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.textMapSize = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxPerlinAdditional = new System.Windows.Forms.TextBox();
            this.textBoxAdditionalDeviation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonAdditionalPerlin = new System.Windows.Forms.Button();
            this.buttonColorized = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainCanvas
            // 
            this.mainCanvas.BackColor = System.Drawing.Color.Gray;
            this.mainCanvas.Location = new System.Drawing.Point(0, 27);
            this.mainCanvas.Name = "mainCanvas";
            this.mainCanvas.Size = new System.Drawing.Size(800, 600);
            this.mainCanvas.TabIndex = 0;
            this.mainCanvas.TabStop = false;
            this.mainCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainCanvas_MouseDown);
            this.mainCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainCanvas_MouseMove);
            this.mainCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainCanvas_MouseUp);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(54, 68);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(63, 35);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.update_Click);
            // 
            // buttonRotate
            // 
            this.buttonRotate.Location = new System.Drawing.Point(878, 512);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(47, 30);
            this.buttonRotate.TabIndex = 4;
            this.buttonRotate.Text = "Rotate";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Visible = false;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // textBoxXRotate
            // 
            this.textBoxXRotate.Location = new System.Drawing.Point(831, 492);
            this.textBoxXRotate.Name = "textBoxXRotate";
            this.textBoxXRotate.Size = new System.Drawing.Size(33, 20);
            this.textBoxXRotate.TabIndex = 6;
            this.textBoxXRotate.Text = "0";
            this.textBoxXRotate.Visible = false;
            // 
            // textBoxYRotate
            // 
            this.textBoxYRotate.Location = new System.Drawing.Point(831, 518);
            this.textBoxYRotate.Name = "textBoxYRotate";
            this.textBoxYRotate.Size = new System.Drawing.Size(33, 20);
            this.textBoxYRotate.TabIndex = 7;
            this.textBoxYRotate.Text = "0";
            this.textBoxYRotate.Visible = false;
            // 
            // textBoxZRotate
            // 
            this.textBoxZRotate.Location = new System.Drawing.Point(831, 544);
            this.textBoxZRotate.Name = "textBoxZRotate";
            this.textBoxZRotate.Size = new System.Drawing.Size(33, 20);
            this.textBoxZRotate.TabIndex = 8;
            this.textBoxZRotate.Text = "0";
            this.textBoxZRotate.Visible = false;
            // 
            // xRotate
            // 
            this.xRotate.AutoSize = true;
            this.xRotate.Location = new System.Drawing.Point(809, 496);
            this.xRotate.Name = "xRotate";
            this.xRotate.Size = new System.Drawing.Size(12, 13);
            this.xRotate.TabIndex = 9;
            this.xRotate.Text = "x";
            this.xRotate.Visible = false;
            // 
            // yRotate
            // 
            this.yRotate.AutoSize = true;
            this.yRotate.Location = new System.Drawing.Point(809, 521);
            this.yRotate.Name = "yRotate";
            this.yRotate.Size = new System.Drawing.Size(12, 13);
            this.yRotate.TabIndex = 10;
            this.yRotate.Text = "y";
            this.yRotate.Visible = false;
            // 
            // zRotate
            // 
            this.zRotate.AutoSize = true;
            this.zRotate.Location = new System.Drawing.Point(809, 547);
            this.zRotate.Name = "zRotate";
            this.zRotate.Size = new System.Drawing.Size(12, 13);
            this.zRotate.TabIndex = 11;
            this.zRotate.Text = "z";
            this.zRotate.Visible = false;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Шаг полигона";
            // 
            // textPolygonStep
            // 
            this.textPolygonStep.Location = new System.Drawing.Point(142, 9);
            this.textPolygonStep.Name = "textPolygonStep";
            this.textPolygonStep.Size = new System.Drawing.Size(33, 20);
            this.textPolygonStep.TabIndex = 20;
            this.textPolygonStep.Text = "20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Максимальная высота";
            // 
            // textMaxHeight
            // 
            this.textMaxHeight.Location = new System.Drawing.Point(142, 35);
            this.textMaxHeight.Name = "textMaxHeight";
            this.textMaxHeight.Size = new System.Drawing.Size(33, 20);
            this.textMaxHeight.TabIndex = 22;
            this.textMaxHeight.Text = "100";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textMaxHeight);
            this.groupBox2.Controls.Add(this.textPolygonStep);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.updateButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(807, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 117);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update";
            // 
            // lightToCamera
            // 
            this.lightToCamera.Location = new System.Drawing.Point(807, 286);
            this.lightToCamera.Name = "lightToCamera";
            this.lightToCamera.Size = new System.Drawing.Size(74, 34);
            this.lightToCamera.TabIndex = 30;
            this.lightToCamera.Text = "Fix light at camera";
            this.lightToCamera.UseVisualStyleBackColor = true;
            this.lightToCamera.Click += new System.EventHandler(this.button1_Click);
            // 
            // animation
            // 
            this.animation.Location = new System.Drawing.Point(908, 286);
            this.animation.Name = "animation";
            this.animation.Size = new System.Drawing.Size(74, 34);
            this.animation.TabIndex = 31;
            this.animation.Text = "Launch animation";
            this.animation.UseVisualStyleBackColor = true;
            this.animation.Click += new System.EventHandler(this.animation_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapSaveToolStripMenuItem,
            this.mapLoadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(999, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mapSaveToolStripMenuItem
            // 
            this.mapSaveToolStripMenuItem.Name = "mapSaveToolStripMenuItem";
            this.mapSaveToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.mapSaveToolStripMenuItem.Text = "Map save";
            this.mapSaveToolStripMenuItem.Click += new System.EventHandler(this.mapSaveToolStripMenuItem_Click);
            // 
            // mapLoadToolStripMenuItem
            // 
            this.mapLoadToolStripMenuItem.Name = "mapLoadToolStripMenuItem";
            this.mapLoadToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.mapLoadToolStripMenuItem.Text = "Map load";
            this.mapLoadToolStripMenuItem.Click += new System.EventHandler(this.mapLoadToolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(806, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(192, 136);
            this.tabControl1.TabIndex = 33;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gray;
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.textPerlinKnot);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.generateButton);
            this.tabPage1.Controls.Add(this.textMapSize);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(184, 110);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Генерация";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Размер карты";
            // 
            // textPerlinKnot
            // 
            this.textPerlinKnot.Location = new System.Drawing.Point(145, 10);
            this.textPerlinKnot.Name = "textPerlinKnot";
            this.textPerlinKnot.Size = new System.Drawing.Size(33, 20);
            this.textPerlinKnot.TabIndex = 24;
            this.textPerlinKnot.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Узлы сетки Перлина";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(64, 68);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(63, 36);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // textMapSize
            // 
            this.textMapSize.Location = new System.Drawing.Point(145, 36);
            this.textMapSize.Name = "textMapSize";
            this.textMapSize.Size = new System.Drawing.Size(33, 20);
            this.textMapSize.TabIndex = 26;
            this.textMapSize.Text = "300";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Gray;
            this.tabPage2.Controls.Add(this.textBoxPerlinAdditional);
            this.tabPage2.Controls.Add(this.textBoxAdditionalDeviation);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.buttonAdditionalPerlin);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(184, 110);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Изменение";
            // 
            // textBoxPerlinAdditional
            // 
            this.textBoxPerlinAdditional.Location = new System.Drawing.Point(145, 9);
            this.textBoxPerlinAdditional.Name = "textBoxPerlinAdditional";
            this.textBoxPerlinAdditional.Size = new System.Drawing.Size(33, 20);
            this.textBoxPerlinAdditional.TabIndex = 34;
            this.textBoxPerlinAdditional.Text = "2";
            // 
            // textBoxAdditionalDeviation
            // 
            this.textBoxAdditionalDeviation.Location = new System.Drawing.Point(145, 35);
            this.textBoxAdditionalDeviation.Name = "textBoxAdditionalDeviation";
            this.textBoxAdditionalDeviation.Size = new System.Drawing.Size(33, 20);
            this.textBoxAdditionalDeviation.TabIndex = 35;
            this.textBoxAdditionalDeviation.Text = "0.1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Вносимое отклонение";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Узлы сетки Перлина";
            // 
            // buttonAdditionalPerlin
            // 
            this.buttonAdditionalPerlin.Location = new System.Drawing.Point(64, 68);
            this.buttonAdditionalPerlin.Name = "buttonAdditionalPerlin";
            this.buttonAdditionalPerlin.Size = new System.Drawing.Size(63, 36);
            this.buttonAdditionalPerlin.TabIndex = 34;
            this.buttonAdditionalPerlin.Text = "Add grid";
            this.buttonAdditionalPerlin.UseVisualStyleBackColor = true;
            this.buttonAdditionalPerlin.Click += new System.EventHandler(this.buttonAdditionalPerlin_Click);
            // 
            // buttonColorized
            // 
            this.buttonColorized.Location = new System.Drawing.Point(856, 326);
            this.buttonColorized.Name = "buttonColorized";
            this.buttonColorized.Size = new System.Drawing.Size(74, 34);
            this.buttonColorized.TabIndex = 34;
            this.buttonColorized.Text = "Изменение закраски";
            this.buttonColorized.UseVisualStyleBackColor = true;
            this.buttonColorized.Click += new System.EventHandler(this.buttonColorized_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(945, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 25);
            this.button1.TabIndex = 35;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(999, 680);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonColorized);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.animation);
            this.Controls.Add(this.lightToCamera);
            this.Controls.Add(this.groupBox2);
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
            this.Controls.Add(this.buttonRotate);
            this.Controls.Add(this.mainCanvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainCanvas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainCanvas;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button buttonRotate;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPolygonStep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textMaxHeight;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button lightToCamera;
        private System.Windows.Forms.Button animation;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mapSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapLoadToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textPerlinKnot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox textMapSize;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxPerlinAdditional;
        private System.Windows.Forms.TextBox textBoxAdditionalDeviation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonAdditionalPerlin;
        private System.Windows.Forms.Button buttonColorized;
        private System.Windows.Forms.Button button1;
    }
}

