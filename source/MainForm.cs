using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerlinLandscape
{
    public partial class MainForm : Form
    {
        Bitmap bitmap;
        Scene scene;

        public MainForm()
        {
            InitializeComponent();
            scene = new Scene();
            bitmap = new Bitmap(mainCanvas.Width, mainCanvas.Height);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            HeightMap newHeightMap = new HeightMap(100, 100);
            newHeightMap.FillTriangle();

            Landscape landscape = new Landscape(newHeightMap);
            scene.AddObject(landscape);
            scene.camera.Rotate(0, 0, 10);
            UpdateBitmap(scene);
        }

        private void UpdateBitmap(Scene scene)
        {
            bitmap = new Bitmap(mainCanvas.Width, mainCanvas.Height);
            ZBuffer.Process(bitmap, scene);
            mainCanvas.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scene.camera.Rotate(0, 10, 0);
            UpdateBitmap(scene);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scene.camera.Move(0, 0, 10);
            UpdateBitmap(scene);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            scene.camera.Move(0, 10, 0);
            UpdateBitmap(scene);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            scene.camera.Move(10, 0, 0);
            UpdateBitmap(scene);
        }
    }
}
