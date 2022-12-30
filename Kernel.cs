using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Drawing;
using Cosmos.System.Graphics;
//using Cosmos.Debug.Kernel;
using Point = Cosmos.System.Graphics.Point;
using Cosmos.System.Graphics.Fonts;
using System.Threading;
using System.Diagnostics;


namespace Cosmos_Graphic_Subsytem
{
   
    public class VirtualReality
    {
        
        public int maxx = 320;
        public int maxy = 200;
        public int x=50;
        public int y = 50;
        public int movesx = 10;
        public int movesy = 10;
        public Color backs = Color.Green;
        public Pen fore = new Pen(Color.Black);
        public int Tag = 1000;
        //private Debugger debugger = new Debugger();
        public int rais=10;
        public VirtualReality()
        {
            //Debugger.Log(0, "System", "PASS create=");
            
        }
        public void draw(Canvas c)
        {
            c.Clear(backs);
            c.DrawFilledCircle(fore, x+rais,y+rais,rais);
            


            c.Display();
        }
        public void MoveNext(Canvas c)
        {

            while (true)
            {

                x = x + movesx;
                y = y + movesy;
                
                if (x < rais*2 || x > maxx - rais*2)
                {
                    movesx = -movesx;
                    x = x + movesx;
                   

                }
                if (y < rais*2 || y > maxy - rais*2)
                {
                    movesy = -movesy;
                    y = y + movesy;


                }
                draw(c);
                Thread.Sleep(Tag);
            }


        }
    }
    public class Kernel : Sys.Kernel
    {

        

        private Canvas canvas;
        private Bitmap bitmap;

        protected override void BeforeRun()
        {
            
            Mode start = new Mode(320, 200, ColorDepth.ColorDepth32);

  
           
            
            canvas = FullScreenCanvas.GetFullScreenCanvas(start); 

           
            canvas.Clear(Color.Green);
        }

        protected override void Run()
        {
            try
            {
                
                VirtualReality vr = new VirtualReality();
                
                while (true)
                {
                    vr.MoveNext(canvas);
                    
                }



                Console.ReadKey();

               
                Console.ReadKey(true);


                Sys.Power.Shutdown();
            }
            catch (Exception e)
            {
                
                
            }
        }
    }
}