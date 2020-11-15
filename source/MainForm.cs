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
            HeightMap newHeightMap = new HeightMap(10, 10);
            newHeightMap.Generate();

            //Landscape landscape = new Landscape(newHeightMap);
            //scene.AddObject(landscape);
            scene.AddObject(new Cube(100));
            //scene.camera.Rotate(0, 0, 10);
            UpdateBitmap(scene);
        }

        private void UpdateBitmap(Scene scene)
        {
            bitmap = new Bitmap(mainCanvas.Width, mainCanvas.Height);

            new Drawer(new ZBuffer()).Draw(bitmap, scene);
            mainCanvas.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scene.camera.Rotate(0, 10, 0);
            UpdateBitmap(scene);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            scene.camera.Rotate(0, 0, 10);
            UpdateBitmap(scene);
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBoxXRotate.Text);
            int y = Convert.ToInt32(textBoxYRotate.Text);
            int z = Convert.ToInt32(textBoxZRotate.Text);
            scene.camera.Rotate(x, y, z);
            UpdateBitmap(scene);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            scene.camera.Scale(2);
            UpdateBitmap(scene);
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBoxXMove.Text);
            int y = Convert.ToInt32(textBoxYMove.Text);
            int z = Convert.ToInt32(textBoxZMove.Text);
            scene.camera.Move(x, y, z);
            UpdateBitmap(scene);
        }
    }
}
