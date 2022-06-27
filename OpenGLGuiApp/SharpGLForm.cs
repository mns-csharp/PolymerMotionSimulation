using System;
using System.Windows.Forms;
using SharpGL;
using PdbLib;
using System.Collections.Generic;

namespace GettingStartedWithSharpGL
{
    public partial class SharpGLForm : Form
    {
        private float rotation = 0.0f;
        private Random random;

        private List<Pair<Point3d, Rgb>> beads;

        public SharpGLForm()
        {
            InitializeComponent();

            random = new Random();
            beads = new List<Pair<Point3d, Rgb>>();

            for(int i=0; i<100; i++)
            {
                double x = random.NextDouble();
                double y = random.NextDouble();
                double z = random.NextDouble();

                double r = random.NextDouble();
                double g = random.NextDouble();
                double b = random.NextDouble();

                Pair<Point3d, Rgb> pair = new Pair<Point3d, Rgb>();
                pair.First = new Point3d(x, y, z);
                pair.Second = new Rgb(r, g, b);

                beads.Add(pair);
            }

            setup();
        }

        void setup()
        {
            OpenGL gl = openGLControl.OpenGL;        

            float[] mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] mat_shininess = { 50.0f };
            float[] light_position = { 0.5f, 0.5f, 0.750f, 0.0f };
            gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.ShadeModel(OpenGL.GL_SMOOTH);

            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SPECULAR, mat_specular);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, mat_shininess);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light_position);

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_DEPTH_TEST);


            // Hidden surface removal
            gl.Enable(OpenGL.GL_CULL_FACE);
            gl.CullFace(OpenGL.GL_BACK);
            gl.FrontFace(OpenGL.GL_CW);
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;        
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();           
            gl.Translate(0.0f, 0.0f, -4.0f);
            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            foreach (var item in beads)
            {
                drawSphere(gl, item.First, item.Second, 0.5, 20);
            }

            gl.Flush();

            rotation += 3.0f;
        }

        #region drawSphere()
        private static void drawSphere(OpenGL gl, Point3d c, Rgb color, double r, int n)
        {
            int i, j;
            double theta1, theta2, theta3;
            Point3d e = new Point3d();
            Point3d p = new Point3d();

            if (c == null)
            {
                c = new Point3d(0, 0, 0);
            }

            double twoPi = Math.PI * 2;
            double piD2 = Math.PI / 2;
            if (r < 0)
                r = -r;
            if (n < 0)
                n = -n;
            if (n < 4 || r <= 0)
            {
                gl.Begin(OpenGL.GL_POINTS);
                gl.Color(color.Red, color.Green, color.Blue);
                gl.Vertex(c.X, c.Y, c.Z);
                gl.End();
                return;
            }

            for (j = 0; j < n / 2; j++)
            {
                theta1 = j * twoPi / n - piD2;
                theta2 = (j + 1) * twoPi / n - piD2;

                gl.Begin(OpenGL.GL_QUAD_STRIP);
                for (i = 0; i <= n; i++)
                {
                    theta3 = i * twoPi / n;

                    e.X = Math.Cos(theta2) * Math.Cos(theta3);
                    e.Y = Math.Sin(theta2);
                    e.Z = Math.Cos(theta2) * Math.Sin(theta3);
                    p.X = c.X + r * e.X;
                    p.Y = c.Y + r * e.Y;
                    p.Z = c.Z + r * e.Z;

                    gl.Normal(e.X, e.Y, e.Z);
                    gl.TexCoord(i / (double)n, 2 * (j + 1) / (double)n);
                    gl.Color(color.Red, color.Green, color.Blue);
                    gl.Vertex(p.X, p.Y, p.Z);

                    e.X = Math.Cos(theta1) * Math.Cos(theta3);
                    e.Y = Math.Sin(theta1);
                    e.Z = Math.Cos(theta1) * Math.Sin(theta3);
                    p.X = c.X + r * e.X;
                    p.Y = c.Y + r * e.Y;
                    p.Z = c.Z + r * e.Z;

                    gl.Normal(e.X, e.Y, e.Z);
                    gl.TexCoord(i / (double)n, 2 * j / (double)n);
                    gl.Color(color.Red, color.Green, color.Blue);
                    gl.Vertex(p.X, p.Y, p.Z);
                }
                gl.End();
            }
        }
        #endregion
    }
}
