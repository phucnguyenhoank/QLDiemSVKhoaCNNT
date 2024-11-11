using QLDiemSVKhoaCNNT.DBConnection;

namespace QLDiemSVKhoaCNNT
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            QLDSVCNTTConnection qLDSVCNTTConnection = new QLDSVCNTTConnection(frmLogin.getUserName(), frmLogin.getPassword());
            Application.Run(new FrmControl());
        }
    }
}