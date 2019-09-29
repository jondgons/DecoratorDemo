using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TextField txt = new TextField(1920, 1080);

            new BorderDecorator(new ScrollDecorator(new BorderDecorator(new BackgroundDecorator(txt)))).draw();

            Console.ReadKey();
        }
    }

    interface Widget
    {
        void draw();
    }

    class TextField : Widget
    {
        private int width;
        private int height;

        public TextField(int w, int h)
        {
            width = w;
            height = h;
        }

        public void draw()
        {
            Console.Write("I am a " + width + "x" + height + " TextField.");
        }
    }

    abstract class Decorator : Widget
    {
        private Widget wid;

        public Decorator(Widget w)
        {
            wid = w;
        }

        public virtual void draw()
        {
            Console.Write("I am a Decorator, holding a: ");
        }
    }

    class BorderDecorator : Decorator
    {
        private Widget wid;

        public BorderDecorator(Widget w) : base(w)
        {
            wid = w;
        }

        public override void draw()
        {
            Console.Write("I am a BorderDecorator, holding a: ");
            wid.draw();
        }
    }

    class ScrollDecorator : Decorator
    {
        private Widget wid;

        public ScrollDecorator(Widget w) : base(w)
        {
            wid = w;
        }

        public override void draw()
        {
            Console.Write("I am a ScrollDecorator, holding a: ");
            wid.draw();
        }
    }

    class BackgroundDecorator : Decorator
    {
        private Widget wid;

        public BackgroundDecorator(Widget w) : base(w)
        {
            wid = w;
        }

        public override void draw()
        {
            Console.Write("I am a BackgroundDecorator, holding a: ");
            wid.draw();
        }
    }
}
