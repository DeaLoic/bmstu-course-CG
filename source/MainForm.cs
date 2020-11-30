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
        Drawer drawer = new Drawer(new ZBuffer());
        Bitmap bitmap;
        Scene scene;
        HeightMap heightMap;
        Landscape landscape;
        Noize noize = new Perlin2d(1, 1, 0, 300);
        int typeView = 0;

        int countOfGridKnot = 1;
        int polygonStep = 20;
        int maxHeight = 100;
        int sizeMap = 300;


        bool isMoving = false;
        Point firstMove;
        int cameraSpeed = 10;
        public MainForm()
        {
            InitializeComponent();
            scene = new Scene();
            bitmap = new Bitmap(mainCanvas.Width, mainCanvas.Height);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            countOfGridKnot = Convert.ToInt32(textPerlinKnot.Text);
            sizeMap = Convert.ToInt32(textMapSize.Text);

            noize = new Perlin2d(countOfGridKnot, countOfGridKnot, 0, sizeMap);
            heightMap = new HeightMap(noize, sizeMap, sizeMap);
            heightMap.Generate();
            UpdateLandscape();
            scene.AddObject(new Cube(300));
            //scene.camera.Rotate(0, 0, 10);
            UpdateBitmap(scene);
        }

        private void UpdateLandscape()
        {
            landscape = new Landscape(heightMap, maxHeight, polygonStep);
            scene.DeleteObjects();
            scene.AddObject(landscape);
            scene.camera.SetLookAtDot(landscape.CentralDot);
        }

        private void UpdateBitmap(Scene scene)
        {
            bitmap = new Bitmap(mainCanvas.Width, mainCanvas.Height);

            drawer.Draw(bitmap, scene);
            mainCanvas.Image = bitmap;
        }

        private void update_Click(object sender, EventArgs e)
        {
            maxHeight = Convert.ToInt32(textMaxHeight.Text);
            polygonStep = Convert.ToInt32(textPolygonStep.Text);
            UpdateLandscape();
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
            isMoving = false;
        }

        private void mainCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            coordinatesLabel.Text = String.Format("( {0}, {1}, {2} )", e.Location.X, e.Location.Y, drawer.GetZ(e.Location.Y, e.Location.X));
            if (isMoving)
            {
                Point lastMove = e.Location;
                scene.camera.Rotate(-(lastMove.Y - firstMove.Y) / cameraSpeed, (lastMove.X - firstMove.X) / cameraSpeed, 0);
                if ((lastMove.Y - firstMove.Y) / cameraSpeed != 0)
                {
                    firstMove.Y = lastMove.Y;
                }
                if ((lastMove.X - firstMove.X) / cameraSpeed != 0)
                {
                    firstMove.X = lastMove.X;
                }
                UpdateBitmap(scene);
            }
        }
    }
}
