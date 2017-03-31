using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MandachordEncode
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

#pragma warning disable 649
        internal struct INPUT
        {
            public UInt32 Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;
        }

        internal struct MOUSEINPUT
        {
            public Int32 X;
            public Int32 Y;
            public UInt32 MouseData;
            public UInt32 Flags;
            public UInt32 Time;
            public IntPtr ExtraInfo;
        }

#pragma warning restore 649


        public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint)
        {
            var oldPos = Cursor.Position;

            /// get screen coordinates
            ClientToScreen(wndHandle, ref clientPoint);

            /// set cursor on coords, and press mouse
            Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

            var inputMouseDown = new INPUT();
            inputMouseDown.Type = 0; /// input type mouse
            inputMouseDown.Data.Mouse.Flags = 0x0002; /// left button down

            var inputMouseUp = new INPUT();
            inputMouseUp.Type = 0; /// input type mouse
            inputMouseUp.Data.Mouse.Flags = 0x0004; /// left button up

            var inputs = new INPUT[] { inputMouseDown, inputMouseUp };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

            /// return mouse 
            Cursor.Position = oldPos;
        }


        string encode_wheel = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()[];',./¢£€¥ƒ¤¡¿ÇçŒœßØøÅåÆæÞþÐð«»‹›ŠšŽžàèìòùÀÈÌÒÙáéíóúÁÉÍÓÚÝý";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string result = "";

            Process[] pr = Process.GetProcesses();
            Debug.WriteLine(pr.Length);

            Process p = null;
            foreach (Process prc in pr)
            {
                //Debug.WriteLine(prc.ProcessName);
                if (prc.ProcessName.ToLower().Contains("warframe"))
                {
                    p = prc;
                }
            }

            if (p != null)
            {
                SetForegroundWindow(p.MainWindowHandle);

                string exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                string argsPath = "args.txt";
                ExtractResource("MandachordEncode.activate.txt", argsPath);

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                Process ahk = Process.Start(startInfo);

                ahk.WaitForExit();


                //Run first loop
                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.loop1.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();

                result = result + ReadSec( 707, 662, -25, -30) + ":";
                result = result + ReadSec( 725, 649, -22, -32) + ":";
                result = result + ReadSec( 744, 637, -19, -34) + ":";
                result = result + ReadSec( 763, 626, -16, -36) + ":";
                result = result + ReadSec( 782, 619, -12, -37) + ":";
                result = result + ReadSec( 804, 612, - 9, -38) + ":";
                result = result + ReadSec( 825, 608, - 5, -39) + ":";
                result = result + ReadSec( 846, 606, - 2, -40) + ":";
                result = result + ReadSec( 867, 606,   2, -40) + ":";
                result = result + ReadSec( 888, 606,   5, -39) + ":";
                result = result + ReadSec( 910, 612,   9, -38) + ":";
                result = result + ReadSec( 930, 619,  12, -37) + ":";
                result = result + ReadSec( 950, 626,  16, -36) + ":";
                result = result + ReadSec( 969, 637,  19, -34) + ":";
                result = result + ReadSec( 987, 649,  22, -32) + ":";
                result = result + ReadSec(1003, 662,  25, -30);
                result = result + ":";// + ":";


                //Run second loop
                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.loop2.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();

                result = result + ReadSec(707, 662, -25, -30) + ":";
                result = result + ReadSec(725, 649, -22, -32) + ":";
                result = result + ReadSec(744, 637, -19, -34) + ":";
                result = result + ReadSec(763, 626, -16, -36) + ":";
                result = result + ReadSec(782, 619, -12, -37) + ":";
                result = result + ReadSec(804, 612, -9, -38) + ":";
                result = result + ReadSec(825, 608, -5, -39) + ":";
                result = result + ReadSec(846, 606, -2, -40) + ":";
                result = result + ReadSec(867, 606, 2, -40) + ":";
                result = result + ReadSec(888, 606, 5, -39) + ":";
                result = result + ReadSec(910, 612, 9, -38) + ":";
                result = result + ReadSec(930, 619, 12, -37) + ":";
                result = result + ReadSec(950, 626, 16, -36) + ":";
                result = result + ReadSec(969, 637, 19, -34) + ":";
                result = result + ReadSec(987, 649, 22, -32) + ":";
                result = result + ReadSec(1003, 662, 25, -30);
                result = result + ":";// + ":";


                //Run third loop
                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.loop3.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();

                result = result + ReadSec(707, 662, -25, -30) + ":";
                result = result + ReadSec(725, 649, -22, -32) + ":";
                result = result + ReadSec(744, 637, -19, -34) + ":";
                result = result + ReadSec(763, 626, -16, -36) + ":";
                result = result + ReadSec(782, 619, -12, -37) + ":";
                result = result + ReadSec(804, 612, -9, -38) + ":";
                result = result + ReadSec(825, 608, -5, -39) + ":";
                result = result + ReadSec(846, 606, -2, -40) + ":";
                result = result + ReadSec(867, 606, 2, -40) + ":";
                result = result + ReadSec(888, 606, 5, -39) + ":";
                result = result + ReadSec(910, 612, 9, -38) + ":";
                result = result + ReadSec(930, 619, 12, -37) + ":";
                result = result + ReadSec(950, 626, 16, -36) + ":";
                result = result + ReadSec(969, 637, 19, -34) + ":";
                result = result + ReadSec(987, 649, 22, -32) + ":";
                result = result + ReadSec(1003, 662, 25, -30);
                result = result + ":";// + ":";


                //Run fourth loop
                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.loop4.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();

                result = result + ReadSec(707, 662, -25, -30) + ":";
                result = result + ReadSec(725, 649, -22, -32) + ":";
                result = result + ReadSec(744, 637, -19, -34) + ":";
                result = result + ReadSec(763, 626, -16, -36) + ":";
                result = result + ReadSec(782, 619, -12, -37) + ":";
                result = result + ReadSec(804, 612, -9, -38) + ":";
                result = result + ReadSec(825, 608, -5, -39) + ":";
                result = result + ReadSec(846, 606, -2, -40) + ":";
                result = result + ReadSec(867, 606, 2, -40) + ":";
                result = result + ReadSec(888, 606, 5, -39) + ":";
                result = result + ReadSec(910, 612, 9, -38) + ":";
                result = result + ReadSec(930, 619, 12, -37) + ":";
                result = result + ReadSec(950, 626, 16, -36) + ":";
                result = result + ReadSec(969, 637, 19, -34) + ":";
                result = result + ReadSec(987, 649, 22, -32) + ":";
                result = result + ReadSec(1003, 662, 25, -30);


                Debug.WriteLine(result);

                DoMouseClick(1660, 580);
                

                this.Activate();

                //ClickOnPoint(p.MainWindowHandle, new Point(1660, 580));

                string encoded = Encode(result);

                Debug.WriteLine(encoded);

                string decoded = Decode(encoded);

                Debug.WriteLine(decoded);

                txtSong.Text = encoded;
            }

        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            Process[] pr = Process.GetProcesses();
            Debug.WriteLine(pr.Length);

            Process p = null;
            foreach (Process prc in pr)
            {
                //Debug.WriteLine(prc.ProcessName);
                if (prc.ProcessName.ToLower().Contains("warframe"))
                {
                    p = prc;
                }
            }

            if (p != null)
            {
                SetForegroundWindow(p.MainWindowHandle);

                string exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                string argsPath = "args.txt";
                ExtractResource("MandachordEncode.activate.txt", argsPath);

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                Process ahk = Process.Start(startInfo);

                ahk.WaitForExit();


                string song = Decode(txtSong.Text);
                string[] lines = song.Split(':');

                string write = "";
                int start = 0;
                int end = 0;


                //Write song part 1
                //Run first loop
                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.loop1.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();

                write = "";
                start = 0;
                end = 16;
                for (int i = start; i < end; i++)
                {
                    write = write + lines[i];
                    if (i != end - 1)
                    {
                        write = write + ":";
                    }
                }

                File.WriteAllText(@"song.txt", write);

                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.write1.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();


                //Write song part 2
                //Run second loop
                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.loop2.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();

                write = "";
                start = 16;
                end = 32;
                for (int i = start; i < end; i++)
                {
                    write = write + lines[i];
                    if (i != end - 1)
                    {
                        write = write + ":";
                    }
                }

                File.WriteAllText(@"song.txt", write);

                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.write1.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();


                //Write song part 3
                //Run third loop
                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.loop3.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();

                write = "";
                start = 32;
                end = 48;
                for (int i = start; i < end; i++)
                {
                    write = write + lines[i];
                    if (i != end - 1)
                    {
                        write = write + ":";
                    }
                }

                File.WriteAllText(@"song.txt", write);

                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.write1.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();


                //Write song part 4
                //Run fourth loop
                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.loop4.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();

                write = "";
                start = 48;
                end = 64;
                for (int i = start; i < end; i++)
                {
                    write = write + lines[i];
                    if (i != end - 1)
                    {
                        write = write + ":";
                    }
                }

                File.WriteAllText(@"song.txt", write);

                exePath = "embedded.exe";
                ExtractResource("MandachordEncode.embedded.exe", exePath);

                argsPath = "args.txt";
                ExtractResource("MandachordEncode.write1.txt", argsPath);

                startInfo = new ProcessStartInfo();
                startInfo.FileName = @exePath;
                startInfo.Arguments = @argsPath;
                ahk = Process.Start(startInfo);

                ahk.WaitForExit();


                this.Activate();
            }

        }

        private string ReadSec(int px, int py, int dx, int dy)
        {
            string result = "";

            //Debug.WriteLine("Part 1:");
            for (int i = 0; i < 13; i++)
            {
                int x = px + dx * i;
                int y = py + dy * i;

                Point p = new Point(x, y);
                Color c = GetColorAt(p);

                //Debug.Write(c);

                int R = c.R;
                int G = c.G;
                int B = c.B;

                /*if (i >= 0 && i < 5)
                {
                    if ((R >= 98 && R <= 118) && (G >= 47 && G <= 67) && (B >= 104 && B <= 124))
                    {
                        result = result + "1";
                    }
                    else
                    {
                        result = result + "0";
                    }
                }
                if (i >= 5 && i < 10)
                {
                    if ((R >= 30 && R <= 50) && (G >= 79 && G <= 99) && (B >= 104 && B <= 124))
                    {
                        result = result + "1";
                    }
                    else
                    {
                        result = result + "0";
                    }
                }
                if (i >= 10)
                {
                    if ((R >= 81 && R <= 141) && (G >= 81 && G <= 101) && (B >= 81 && B <= 101))
                    {
                        result = result + "1";
                    }
                    else
                    {
                        result = result + "0";
                    }
                }*/

                if (i != 12)
                {
                    if (G >= 47 && B >= 60)
                    {
                        result = result + "1";
                    }
                    else
                    {
                        result = result + "0";
                    }
                }
                else
                {
                    if (G >= 47 && G >= 89 && B >= 60)
                    {
                        result = result + "1";
                    }
                    else
                    {
                        result = result + "0";
                    }
                }

                if (i == 12)
                {
                    Debug.WriteLine(R + ", " + G + ", " + B);
                }

                /*switch (i)
                {
                    case (0):
                        lblm1.BackColor = c;
                        break;
                    case (1):
                        lblm2.BackColor = c;
                        break;
                    case (2):
                        lblm3.BackColor = c;
                        break;
                    case (3):
                        lblm4.BackColor = c;
                        break;
                    case (4):
                        lblm5.BackColor = c;
                        break;

                    case (5):
                        lblb1.BackColor = c;
                        break;
                    case (6):
                        lblb2.BackColor = c;
                        break;
                    case (7):
                        lblb3.BackColor = c;
                        break;
                    case (8):
                        lblb4.BackColor = c;
                        break;
                    case (9):
                        lblb5.BackColor = c;
                        break;

                    case (10):
                        lblp1.BackColor = c;
                        break;
                    case (11):
                        lblp2.BackColor = c;
                        break;
                    case (12):
                        lblp3.BackColor = c;
                        break;
                }*/
            }

            return result;
        }

        Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
        public Color GetColorAt(Point location)
        {
            using (Graphics gdest = Graphics.FromImage(screenPixel))
            {
                using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    IntPtr hSrcDC = gsrc.GetHdc();
                    IntPtr hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            return screenPixel.GetPixel(0, 0);
        }

        public void DoMouseClick(uint X, uint Y)
        {
            //Call the imported function with the cursor's current position
            //uint X = Cursor.Position.X;
            //uint Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        void ExtractResource(string resource, string path)
        {
            Stream stream = GetType().Assembly.GetManifestResourceStream(resource);
            byte[] bytes = new byte[(int)stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            File.WriteAllBytes(path, bytes);
        }

        private string Encode(string result)
        {
            string encoded = "";
            string[] lines = result.Split(':');
            foreach (string line in lines)
            {
                encoded = encoded + EncodeText(line);
            }

            return encoded;
        }

        private string Decode(string encoded)
        {
            string decoded = "";
            bool toggle = false;
            foreach (char c in encoded.ToCharArray())
            {
                int d = AsciiToInt(c);
                if (toggle == false)
                {
                    decoded = decoded + DecodeText(d, 7);
                }
                else
                {
                    decoded = decoded + DecodeText(d, 6) + ":";
                }

                toggle = !toggle;
            }

            return decoded;
        }

        private string EncodeText(string line)
        {
            int num1 = 0;
            int num2 = 0;

            char[] c = line.ToCharArray();

            if (c[0] == '1')
            {
                num1 += 64;
            }
            if (c[1] == '1')
            {
                num1 += 32;
            }
            if (c[2] == '1')
            {
                num1 += 16;
            }
            if (c[3] == '1')
            {
                num1 += 8;
            }
            if (c[4] == '1')
            {
                num1 += 4;
            }
            if (c[5] == '1')
            {
                num1 += 2;
            }
            if (c[6] == '1')
            {
                num1 += 1;
            }

            if (c[7] == '1')
            {
                num2 += 32;
            }
            if (c[8] == '1')
            {
                num2 += 16;
            }
            if (c[9] == '1')
            {
                num2 += 8;
            }
            if (c[10] == '1')
            {
                num2 += 4;
            }
            if (c[11] == '1')
            {
                num2 += 2;
            }
            if (c[12] == '1')
            {
                num2 += 1;
            }

            string encode = "";
            encode = "" + IntToAscii(num1) + IntToAscii(num2);

            return encode;
        }

        private string DecodeText(int text, int size)
        {
            string ret = "";
            int size2 = text;

            if (size == 7)
            {
                if (size2 / 64 > 0)
                {
                    ret = ret + "1";
                    size2 -= 64;
                }
                else
                {
                    ret = ret + "0";
                }
            }

            if (size2 / 32 > 0)
            {
                ret = ret + "1";
                size2 -= 32;
            }
            else
            {
                ret = ret + "0";
            }

            if (size2 / 16 > 0)
            {
                ret = ret + "1";
                size2 -= 16;
            }
            else
            {
                ret = ret + "0";
            }

            if (size2 / 8 > 0)
            {
                ret = ret + "1";
                size2 -= 8;
            }
            else
            {
                ret = ret + "0";
            }

            if (size2 / 4 > 0)
            {
                ret = ret + "1";
                size2 -= 4;
            }
            else
            {
                ret = ret + "0";
            }

            if (size2 / 2 > 0)
            {
                ret = ret + "1";
                size2 -= 2;
            }
            else
            {
                ret = ret + "0";
            }

            if (size2 / 1 > 0)
            {
                ret = ret + "1";
                size2 -= 1;
            }
            else
            {
                ret = ret + "0";
            }

            //Debug.WriteLine(text + " -> " + ret);

            return ret;
        }

        private char IntToAscii (int i)
        {
            return encode_wheel.ToCharArray()[i];
        }

        private int AsciiToInt (char a)
        {
            char[] c = encode_wheel.ToCharArray();
            int pos = 0;
            foreach(char ch in c)
            {
                if (a == ch)
                {
                    return pos;
                }
                pos++;
            }
            return 0;
        }
    }
}
