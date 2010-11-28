using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime;
using System.Text;
using System.Diagnostics;
using System.Collections;
using System.Xml;
using System.Net;
using System.Xml.Serialization;
namespace Spofity
{
    [XmlRoot("rss")]
    public class RSS
    {
       
        public class Item
        {

            public class Enclosure
            {
                private string url;
                private string type;
                [XmlAttribute("url")]
                public string URL
                {
                    get
                    {
                        return url;
                    }
                    set
                    {
                        url = value;
                    }
                }
                [XmlAttribute("type")]
                public string Type
                {
                    get
                    {
                        return type;
                    }
                    set
                    {
                        type = value;
                    }
                }
            }
            private List<Enclosure> enclos;
            public List<Enclosure> Enclos
            {
                get
                {
                    return enclos;
                }
                set
                {
                    enclos = value;
                }
            }

            private string title;
            private string description;
            private string url;
            private string enclosure;
            [XmlText()]
            public string Description
            {
                get
                {
                    return description;
                }
                set
                {
                    description = value;
                }
            }
            [XmlText()]
            public string Title
            {
                get
                {
                    return title;
                }
                set
                {
                    title = value;
                }
            }
           

        }
        public RSS()
        {
            items = new List<Item>();
        }
        private List<Item> items;

        [XmlElement("item")]
        public List<Item> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }
    }

    public class Theme
    {
        public Color bgColor;
        public Color altBgColor;
        public Color ForeColor;
        public Color AltForeColor;
        public Color descColor;
        public Color menuColor;
        public Color menuForeColor;
        public Color selectedColor;
    }
    public class Helper
    {
        
        public struct Margins
        {
            public int Left, Top, Right, Bottom;
        }
        //if Vista enable non-client painting
        /*
        if (Environment.OSVersion.Version.Major > 6)

        {

        User32.DWMNCRENDERINGPOLICY ncrp = 
        User32.DWMNCRENDERINGPOLICY.DWMNCRP_DISABLED;

        User32.DwmSetWindowAttribute(this.Handle, 
        (uint)User32.DWMWINDOWATTRIBUTE.DWMWA_NCRENDERING_ENABLED, (IntPtr)ncrp, 
        (IntPtr)sizeof(int));

        User32.DwmSetWindowAttribute(this.Handle, 
        (uint)User32.DWMWINDOWATTRIBUTE.DWMWA_ALLOW_NCPAINT, IntPtr.Zero, 
        IntPtr.Zero);

        }


        And in library I used:*/
        public enum DWMWINDOWATTRIBUTE
        {

            DWMWA_NCRENDERING_ENABLED = 1, // [get] Is non-client rendering enabled/disabled

            DWMWA_NCRENDERING_POLICY, // [set] Non-client rendering policy DWMWA_TRANSITIONS_FORCEDISABLED, // [set] Potentially enable/forcibly disable transitions

            DWMWA_ALLOW_NCPAINT, // [set] Allow contents rendered in the non-client area to be visible on the DWM-drawn frame.

            DWMWA_CAPTION_BUTTON_BOUNDS, // [get] Bounds of the caption button area in window-relative space.

            DWMWA_NONCLIENT_RTL_LAYOUT, // [set] Is non-client content RTL mirrored

            DWMWA_FORCE_ICONIC_REPRESENTATION, // [set] Force this window to display iconic thumbnails.

            DWMWA_FLIP3D_POLICY, // [set] Designates how Flip3D will treat the window.

            DWMWA_EXTENDED_FRAME_BOUNDS, // [get] Gets the extended frame bounds rectangle in screen space

            DWMWA_LAST

        };

        // Non-client rendering policy attribute values

        public enum DWMNCRENDERINGPOLICY
        {

            DWMNCRP_USEWINDOWSTYLE, // Enable/disable non-client rendering based on window style

            DWMNCRP_DISABLED, // Disabled non-client rendering; window style is ignored
            DWMNCRP_ENABLED, // Enabled non-client rendering; window style is ignored

            DWMNCRP_LAST

        };

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern string GetWindowTitle(IntPtr hwnd);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, uint dwAttribute, IntPtr pvAttribute, IntPtr uhwnd);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint MSG, object wParam, object lParam);
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        IntPtr Spotify;
        IntPtr ncrp;
        int WS_CAPTION = 12582912;
        int WS_MINIMIZEBOX = 131072;
        int WS_MAXIMIZEBOX = 65536;
        int WS_SYSMENU = 524288;
        int WS_THICKFRAME = 262144;
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int  GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int X;
            public int Y;
            public int Width;
            public int Height;
        }
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(int hWnd, ref Margins Mgns);
        
    }
    static class Program
    {

        
        static string GetURI()
        {
            return "";
        }
        static Theme CurrentTheme;
        static Timer ST = new Timer();
        static Helper.RECT pos = new Helper.RECT();
        static Helper D = new Helper();
        public static IntPtr Spotify = Helper.FindWindowEx((IntPtr)null, (IntPtr)null, null, "Spotify");
     //   static List<Form1> views = new List<Form1>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static string URI = "";
        static Form2 d;
        [STAThread]
        /*static void Main(string[] args)
        {
            Spotify = Helper.FindWindowEx((IntPtr)null, (IntPtr)null, "SpotifyMainWindow",null);
           
            CurrentTheme = new Theme()
            {
                bgColor = Color.FromArgb(55, 55, 55),
                altBgColor = Color.FromArgb(33, 33, 33),
                ForeColor = Color.FromArgb(233, 233, 233),
                AltForeColor = Color.FromArgb(188, 188, 188),
                selectedColor= Color.FromArgb(165, 235, 255)
            };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            Form1 d = new Form1("L:\\Dr. Sounds");
            Application.Run(d);

            
        }*/
        
        static void ST_Tick(object sender, EventArgs e)
        {
            /*  Spotify = Helper.FindWindowEx((IntPtr)null, (IntPtr)null, null, "Spotify");
            
              pos = new Helper.RECT();
              Form1 Form = d;
               
                 
                      Form.TopMost = Helper.GetForegroundWindow() == Spotify;
                    
                      if (Helper.GetWindowRect(Spotify, ref pos)>0)
                      {
                          Form.Left = pos.X + 236;
                          Form.Top = pos.Y + 56;
                          Form.Width = pos.Width - pos.X - 236;
                          Form.Height = pos.Height - pos.Y - 56 - 41;


                      }
                
                  */

        }
            }
    }
