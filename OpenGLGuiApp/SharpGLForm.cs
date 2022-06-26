using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using PdbLib;

namespace GettingStartedWithSharpGL
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        /// <summary>
        /// The current rotation.
        /// </summary>
        private float rotation = 0.0f;

        PdbLib.PdbFile pdbFile;
        List<PdbLib.PdbAtom> atomsList;
        OpenGL gl;

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();

            pdbFile = PdbLib.PdbFile.FromFile("3nir.pdb");

            atomsList = pdbFile.GetAtomsList();

            //gl = new OpenGL();

            setup();
        }

        // Initialization routine.
        void setup()
        {
            gl.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            gl.Enable(OpenGL.GL_DEPTH_TEST); // Enable depth testing.
            

            // Turn on OpenGL lighting.
            gl.Enable(OpenGL.GL_LIGHTING);

            // Light property vectors.
            float []lightAmb = { 0.2f, 0.2f, 0.2f, 0.0f };
            float[]lightDifAndSpec0 = { 0.0f, 1.0f, 0.0f, 0.0f };
            float[]lightDifAndSpec1 = { 0.0f, 1.0f, 0.0f, 0.0f };
            float[]globAmb = { 0.2f, 0.2f, 0.2f, 0.0f };

            // Light0 properties.
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, lightAmb);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, lightDifAndSpec0);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, lightDifAndSpec0);

            // Light1 properties.
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_AMBIENT, lightAmb);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_DIFFUSE, lightDifAndSpec1);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_SPECULAR, lightDifAndSpec1);

            gl.Enable(OpenGL.GL_LIGHT0); // Enable particular light source.
            gl.Enable(OpenGL.GL_LIGHT1); // Enable particular light source.
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, globAmb); // Global ambient light.
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_LOCAL_VIEWER, OpenGL.GL_TRUE); // Enable local viewpoint

            // Hidder surface removal.
            gl.Enable(OpenGL.GL_CULL_FACE);
            gl.CullFace(OpenGL.GL_BACK);
        }

        //http://www.java2s.com/example/java/javax.media.opengl/opengl-method-to-draw-a-sphere-in-opengl.html
        void drawSphere(Point3d c, double r, int n)
        {
            int i, j;
            double theta1, theta2, theta3;
            Point3d e = new Point3d();
            Point3d p = new Point3d();

            if (c == null)
            {
                c = new Point3d(0, 0, 0);
            }//from w ww  .j  ava2 s .  c o m

            double twoPi = Math.PI * 2;
            double piD2 = Math.PI / 2;
            if (r < 0)
                r = -r;
            if (n < 0)
                n = -n;
            if (n < 4 || r <= 0)
            {
                gl.Begin(OpenGL.GL_POINTS);
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
                    gl.Vertex(p.X, p.Y, p.Z);

                    e.X = Math.Cos(theta1) * Math.Cos(theta3);
                    e.Y = Math.Sin(theta1);
                    e.Z = Math.Cos(theta1) * Math.Sin(theta3);
                    p.X = c.X + r * e.X;
                    p.Y = c.Y + r * e.Y;
                    p.Z = c.Z + r * e.Z;

                    gl.Normal(e.X, e.Y, e.Z);
                    gl.TexCoord(i / (double)n, 2 * j / (double)n);
                    gl.Vertex(p.X, p.Y, p.Z);
                }
                gl.End();
            }
        }

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object.
            gl = openGLControl.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Load the identity matrix.
            gl.LoadIdentity();

            //  Rotate around the Y axis.
            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            for (int i=0; i<atomsList.Count; i++)
            {
                PdbAtom item = atomsList[i];

                drawSphere(item.Coordinate, 5.0f, 20);
            }            

            //  Nudge the rotation.
            rotation += 3.0f;
        }



        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  TODO: Initialise OpenGL here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(90.0f, (double)Width / (double)Height, 1.0f, 100.0f);

            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(-5, 30, -5, 0, 0, 0, 0, 300, 0);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
    }
}
