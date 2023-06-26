using OpenQA.Selenium;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MouseAmulation
{
    public static class Mouse
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void MouseLeftClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }
        public static void MouseLeftClick(Point target)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, target.X, target.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, target.X, target.Y, 0, 0);
        }
        public static void MouseLeftClick(IWebElement element)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, element.Location.X, element.Location.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, element.Location.X, element.Location.Y, 0, 0);
        }
        public static void MouseLeftClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        //
        public static void MouseLeftHold(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        }
        public static void MouseLeftHold(Point target)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, target.X, target.Y, 0, 0);
        }
        public static void MouseLeftHold(IWebElement element)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, element.Location.X, element.Location.Y, 0, 0);
        }
        //
        public static void MouseLeftRelease(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }
        public static void MouseLeftRelease(Point target)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, target.X, target.Y, 0, 0);
        }
        public static void MouseLeftRelease(IWebElement element)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, element.Location.X, element.Location.Y, 0, 0);
        }
        //
        public static void MouseMove(int x, int y)
        {
            mouse_event(MOUSEEVENTF_MOVE, x, y, 0, 0);
        }
        public static void MouseMoveTo(int x, int y)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
        }
        public static void MouseMoveTo(Point target)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, target.X, target.Y, 0, 0);
        }
        public static void MouseMoveTo(IWebElement element)
        {
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, element.Location.X, element.Location.Y, 0, 0);
        }
        //
        public static void MouseRightClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
        }
        public static void MouseRightClick(Point target)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, target.X, target.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, target.X, target.Y, 0, 0);
        }
        public static void MouseRightClick(IWebElement element)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, element.Location.X, element.Location.Y, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, element.Location.X, element.Location.Y, 0, 0);
        }
    }
}
