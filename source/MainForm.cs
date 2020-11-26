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
        int typeView = 0;

        bool isMoving = false;
        Point firstMove;
        double cameraSpeed = 10;
        public MainForm()
        {
            InitializeComponent();
            scene = new Scene();
            bitmap = new Bitmap(mainCanvas.Width, mainCanvas.Height);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            HeightMap newHeightMap = new HeightMap(new PerlinNoize(), 300, 300);
            newHeightMap.Generate();

            Landscape landscape = new Landscape(newHeightMap, 500, 20);
            scene.AddObject(landscape);
            //scene.AddObject(new Cube(5));
            //scene.camera.Rotate(0, 0, 10);
            UpdateBitmap(scene);
        }

        private void UpdateBitmap(Scene scene)
        {
            bitmap = new Bitmap(mainCanvas.Width, mainCanvas.Height);

            new Drawer(new ZBuffer()).Draw(bitmap, scene, typeView);
            mainCanvas.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            typeView++;
            typeView %= 3;
            UpdateBitmap(scene);
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            double x = Convert.ToDouble(textBoxXMove.Text.Replace('.',','));
            double y = Convert.ToDouble(textBoxYMove.Text.Replace('.', ','));
            double z = Convert.ToDouble(textBoxZMove.Text.Replace('.', ','));
            scene.camera.Move(new Vector3d(x, y, z));
            UpdateBitmap(scene);
        }

        private void mainCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            firstMove = e.Location;
            isMoving = true;
        }

        private void mainCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMoving)
            {
                Point lastMove = e.Location;
                isMoving = false;
                scene.camera.Rotate((lastMove.X - firstMove.X) / cameraSpeed, (lastMove.Y - firstMove.Y) / cameraSpeed, 0);
                UpdateBitmap(scene);
            }
        }
    }
}
