using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

using Juntendo.MedPhys.Esapi.DepthCalculator;

namespace Juntendo.MedPhys.DepthCalculatorTest
{
    class DepthCalculatorTest
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                using (var app = Application.CreateApplication())
                {
                    Execute(app);
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Console.ReadLine();
            }
        }
        static void Execute(VMS.TPS.Common.Model.API.Application app)
        {
            
            var patientId = "29106509";
            var courseId = "C1";
            var planId = "xHM7";

            var PatientId = patientId;

            var selectedPatient = app.OpenPatientById(patientId);

            var CourseId = courseId;
            var PlanId = planId;

            var selectedCourse = Helpers.GetCourse(selectedPatient, CourseId);
            var selectedPlanSetup = Helpers.GetPlanSetup(selectedCourse, PlanId);

            var depthCalculatorViewModel = new DepthCalculatorViewModel(selectedPlanSetup);

            var depthCalculatorView = new DepthCalculatorView(depthCalculatorViewModel);
            depthCalculatorView.ShowDialog();
        }

    }
}
