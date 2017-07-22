using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anuitex.Library.Models;
using Anuitex.Library.Models.Repositories;
using Anuitex.Library.Presenters;

namespace Anuitex.Library
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MainPresenter mainPresenter = new MainPresenter(new MainForm(), new BookRepository(), new JournalRepository(), new NewspaperRepository(), new XmlRepository(), new RawFileRepository());
            mainPresenter.Run();            
        }
    }
}
