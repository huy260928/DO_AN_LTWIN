using AFP.BLL.Services;
using AFP.DAL.Entities;
using AFP.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFixPicture
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize data context and unit of work
            var context = new PictureFixModel();
            IUnitOfWork unitOfWork = new UnitOfWork(context);

            // Initialize BLL services
            IProjectService projectService = new ProjectService(unitOfWork);
            IEditHistoryService historyService = new EditHistoryService(unitOfWork);

            // Run the main Form1 and pass dependencies
            Application.Run(new Form1(unitOfWork, projectService, historyService));
        }
    }
}
