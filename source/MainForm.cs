using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
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

        int countOfGridKnot = 1;
        int polygonStep = 20;
        int maxHeight = 100;
        int sizeMap = 300;


        bool isMoving = false;
        Point firstMove;
        int cameraSens = 20;
        int cameraSpeed = 5;

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
            heightMap = new HeightMap(sizeMap, sizeMap);
            heightMap.Generate(noize);
            heightMap.Normilize();

            UpdateLandscape();
            //scene.AddObject(new Cube(300));
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
            coordinatesLabel.Text = String.Format("( {0}, {1} )", e.Location.X, e.Location.Y);
            if (isMoving)
            {
                Point lastMove = e.Location;
                if (((lastMove.Y - firstMove.Y) / cameraSens != 0) || ((lastMove.X - firstMove.X) / cameraSens != 0))
                {
                    scene.camera.Rotate(-(lastMove.Y - firstMove.Y) / cameraSens * cameraSpeed, (lastMove.X - firstMove.X) / cameraSens * cameraSpeed, 0);
                    UpdateBitmap(scene);
                }
                if ((lastMove.Y - firstMove.Y) / cameraSens != 0)
                {
                    firstMove.Y = lastMove.Y;
                }
                if ((lastMove.X - firstMove.X) / cameraSens != 0)
                {
                    firstMove.X = lastMove.X;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scene.SetLight(scene.camera.place.ToDot());
            UpdateBitmap(scene);
        }

        private void animation_Click(object sender, EventArgs e)
        {
            scene.SetLight(new Dot3d(10000, 0, 0));
            double dx = 10000 / 30.0;
            double dy = Math.Tan(MathSupport.ToRadian(3)) * dx;
            Thread thread = new Thread(() => {
            for (int i = 0; i < 30; i += 1)
            {
                scene.lightSource = new LightSource(new Dot3d(), new Vector3d(), Color.White);
                if (i < 30)
                {
                    scene.lightSource = new LightSource(new Dot3d(), new Vector3d(), Color.LightGoldenrodYellow);
                }
                if (i < 10)
                {
                    scene.lightSource = new LightSource(new Dot3d(), new Vector3d(), Color.Orange);
                }
                    scene.SetLight(new Dot3d(10000 - dx * i, 0, -dx * i));
                UpdateBitmap(scene);
            }
            scene.lightSource = new LightSource(new Dot3d(), new Vector3d(), Color.White);
            for (int i = 0; i < 30; i += 1)
            {
                scene.SetLight(new Dot3d(0 - dx * i, 0, -10000 + dx * i));
                UpdateBitmap(scene);
            }
            });
            thread.Start();
        }

        private void mapSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            saveFileDialog.Filter = "*.png|*.png";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap myBitmap = new Bitmap(heightMap.Width, heightMap.Height);
                for (int i = 0; i < heightMap.Width; i++)
                {
                    for (int j = 0; j < heightMap.Height; j++)
                    {
                        myBitmap.SetPixel(i, j, Color.FromArgb((int)(heightMap[i, j] * 255), (int)(heightMap[i, j] * 255), (int)(heightMap[i, j] * 255)));
                    }
                }
                myBitmap.Save(saveFileDialog.OpenFile(), ImageFormat.Png);
            }
        }

        private void mapLoadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            openFileDialog.Filter = "*.png|*.png";// "*.png|*.txt";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                Bitmap myBitmap = new Bitmap(selectedFileName);
                heightMap = new HeightMap(myBitmap.Width, myBitmap.Height);
                for (int i = 0; i < heightMap.Width; i++)
                {
                    for (int j = 0; j < heightMap.Height; j++)
                    {
                        heightMap[i, j] = myBitmap.GetPixel(i, j).R / 255.0;
                    }
                }
                heightMap.Normilize();
                UpdateLandscape();
                UpdateBitmap(scene);
            }
        }

        private void buttonAdditionalPerlin_Click(object sender, EventArgs e)
        {
            int gridAdditional = Convert.ToInt32(textBoxPerlinAdditional.Text);
            double deviation = Convert.ToDouble(textBoxAdditionalDeviation.Text.Replace('.', ','));
            Perlin2d noizeNoize = new Perlin2d(gridAdditional, gridAdditional, 0, sizeMap);
            HeightMap heightMapNoize = new HeightMap(sizeMap, sizeMap, deviation);
            heightMapNoize.Generate(noizeNoize);

            for (int i = 0; i < heightMap.Width; i++)
            {
                for (int j = 0; j < heightMap.Height; j++)
                {
                    heightMap[i, j] += heightMapNoize[i, j];
                }
            }
            UpdateLandscape();
            UpdateBitmap(scene);
        }

        private void buttonColorized_Click(object sender, EventArgs e)
        {
            scene.isPolygonColorized = !scene.isPolygonColorized;
        }
    }
}
