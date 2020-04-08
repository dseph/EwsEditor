using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
 
// IMAP 4
// https://tools.ietf.org/html/rfc1730
//	[MS-OXIMAP4]: Internet Message Access Protocol Version 4 (IMAP4) Extensions
//	https://msdn.microsoft.com/en-us/library/cc463913(v=exchg.80).aspx 
// IMAP Client library using C#
// https://www.codeproject.com/Articles/8008/IMAP-Client-library-using-C


namespace EWSEditor.Forms.IMAP
{
    public partial class ImapTest : Form
    {

        //static System.IO.StreamWriter sw = null;
        //static System.Net.Sockets.TcpClient tcpc = null;
        //static System.Net.Security.SslStream ssl = null;
        //static string username, password;
        //static string path;
        //static int bytes = -1;
        //static byte[] buffer;
        //static StringBuilder sb = new StringBuilder();
        //static byte[] dummy;

        public ImapTest()
        {
            InitializeComponent();
        }

        private void ImapTest_Load(object sender, EventArgs e)
        {

        }


        //private void DownloadEmail()
        //{
 
        //    try
        //    {
        //        path = Environment.CurrentDirectory + "\\emailresponse.txt";

        //        if (System.IO.File.Exists(path))
        //            System.IO.File.Delete(path);

        //        sw = new System.IO.StreamWriter(System.IO.File.Create(path));
        //        // there should be no gap between the imap command and the \r\n       
        //        // ssl.read() -- while ssl.readbyte!= eof does not work because there is no eof from server 
        //        // cannot check for \r\n because in case of larger response from server ex:read email message 
        //        // there are lot of lines so \r \n appears at the end of each line 
        //        //ssl.timeout sets the underlying tcp connections timeout if the read or write 
        //        //time out exceeds then the undelying connection is closed 
        //        tcpc = new System.Net.Sockets.TcpClient("imap.gmail.com", 993);

        //        ssl = new System.Net.Security.SslStream(tcpc.GetStream());
        //        ssl.AuthenticateAsClient("imap.gmail.com");
        //        receiveResponse("");

        //        Console.WriteLine("username : ");
        //        username = Console.ReadLine();

        //        Console.WriteLine("password : ");
        //        password = Console.ReadLine();
        //        receiveResponse("$ LOGIN " + username + " " + password + "  \r\n");
        //        Console.Clear();

        //        receiveResponse("$ LIST " + "\"\"" + " \"*\"" + "\r\n");

        //        receiveResponse("$ SELECT INBOX\r\n");

        //        receiveResponse("$ STATUS INBOX (MESSAGES)\r\n");


        //        Console.WriteLine("enter the email number to fetch :");
        //        int number = int.Parse(Console.ReadLine());

        //        receiveResponse("$ FETCH " + number + " body[header]\r\n");
        //        receiveResponse("$ FETCH " + number + " body[text]\r\n");


        //        receiveResponse("$ LOGOUT\r\n");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (sw != null)
        //        {
        //            sw.Close();
        //            sw.Dispose();
        //        }
        //        if (ssl != null)
        //        {
        //            ssl.Close();
        //            ssl.Dispose();
        //        }
        //        if (tcpc != null)
        //        {
        //            tcpc.Close();
        //        }
        //    }


        //    Console.ReadKey();
        //}
        //static void receiveResponse(string command)
        //{
        //    try
        //    {
        //        if (command != "")
        //        {
        //            if (tcpc.Connected)
        //            {
        //                dummy = Encoding.ASCII.GetBytes(command);
        //                ssl.Write(dummy, 0, dummy.Length);
        //            }
        //            else
        //            {
        //                throw new ApplicationException("TCP CONNECTION DISCONNECTED");
        //            }
        //        }
        //        ssl.Flush();


        //        buffer = new byte[2048];
        //        bytes = ssl.Read(buffer, 0, 2048);
        //        sb.Append(Encoding.ASCII.GetString(buffer));


        //        Console.WriteLine(sb.ToString());
        //        sw.WriteLine(sb.ToString());
        //        sb = new StringBuilder();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException(ex.Message);
        //    }
        //}

    //}

    }
}
