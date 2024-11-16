using System.Threading;

namespace ThreadPriority
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            lbIndicator.Text = "-Thread Starts-";
            Threads();
        }
        private void Threads()
        {
            Thread threadA = new Thread(MyThreadClass.Thread1) { Name = "Thread A" , Priority = System.Threading.ThreadPriority.Highest };
            Thread threadB = new Thread(MyThreadClass.Thread2) { Name = "Thread B" , Priority = System.Threading.ThreadPriority.Normal};
            Thread threadC = new Thread(MyThreadClass.Thread1) { Name = "Thread C" , Priority = System.Threading.ThreadPriority.AboveNormal };
            Thread threadD = new Thread(MyThreadClass.Thread2) { Name = "Thread D" , Priority = System.Threading.ThreadPriority.BelowNormal};

            threadA.Start();
            threadB.Start();
            threadC.Start();
            threadD.Start();

            threadA.Join();
            threadB.Join();
            threadC.Join();
            threadD.Join();

            lbIndicator.Text = "-End of Thread-";
        }

    }
    class MyThreadClass
    {
        public static void Thread1(){
            for (int i = 0; i<=2; i++) {
                Thread thread = Thread.CurrentThread;
                System.Diagnostics.Debug.WriteLine("Name of Thread: " + thread.Name + " Process = " + i);
            }
        }
        public static void Thread2() 
        {
            for (int i = 1; i <6; i++)
            {
                Thread.Sleep(1500);
                Thread thread = Thread.CurrentThread;
                System.Diagnostics.Debug.WriteLine("Name of Thread: " + thread.Name + " Process = " + i);
            }
        }
    }
}
