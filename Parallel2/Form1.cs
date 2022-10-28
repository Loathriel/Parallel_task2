namespace Parallel2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void magic_Click(object sender, EventArgs e)
        {
            int n1 = (int)n1_y.Value;
            int n2 = (int)n2_x.Value;

            Working toWork = new Working(n1, n2);

            double seq_time = toWork.sequential();
            double par_time = toWork.parallel();

            printResults(seq_time, par_time);
        }

        private void printResults(double t, double tp)
        {
            results.Text = $"Sequential time:\r\n{t} ms\r\n\r\nParallel time: \r\n{tp} ms";
        }
    }
}